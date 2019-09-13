#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using dnlib.DotNet;
using dnlib.DotNet.Writer;
using KoiVM.AST;
using KoiVM.AST.IL;
using KoiVM.CFG;
using KoiVM.RT.Mutation;
using KoiVM.VM;

#endregion

namespace KoiVM.RT
{
    public class DarksVMRuntime
    {
        private List<Tuple<MethodDef, ILBlock>> basicBlocks;

        internal DbgWriter dbgWriter;

        private List<IKoiChunk> extraChunks;
        private List<IKoiChunk> finalChunks;
        internal Dictionary<MethodDef, Tuple<ScopeBlock, ILBlock>> methodMap;

        private RuntimeMutator rtMutator;
        internal BasicBlockSerializer serializer;
        private readonly IDarksVMSettings settings;

        public DarksVMRuntime(IDarksVMSettings settings, ModuleDef rt)
        {
            this.settings = settings;
            Init(rt);
        }

        public ModuleDef Module => rtMutator.RTModule;

        public VMDescriptor Descriptor
        {
            get;
            private set;
        }

        public byte[] RuntimeLibrary
        {
            get;
            private set;
        }

        public byte[] RuntimeSymbols
        {
            get;
            private set;
        }

        public byte[] DebugInfo => dbgWriter.GetDbgInfo();

        [Obfuscation(Exclude = false, Feature = "+koi;-ref proxy")]
        private void Init(ModuleDef rt)
        {
            Descriptor = new VMDescriptor(settings);
            methodMap = new Dictionary<MethodDef, Tuple<ScopeBlock, ILBlock>>();
            basicBlocks = new List<Tuple<MethodDef, ILBlock>>();

            extraChunks = new List<IKoiChunk>();
            finalChunks = new List<IKoiChunk>();
            serializer = new BasicBlockSerializer(this);

            rtMutator = new RuntimeMutator(rt, this);
            rtMutator.RequestKoi += OnKoiRequested;
        }

        public void AddMethod(MethodDef method, ScopeBlock rootScope)
        {
            ILBlock entry = null;
            foreach(ILBlock block in rootScope.GetBasicBlocks())
            {
                if(block.Id == 0)
                    entry = block;
                basicBlocks.Add(Tuple.Create(method, block));
            }
            Debug.Assert(entry != null);
            methodMap[method] = Tuple.Create(rootScope, entry);
        }

        internal void AddHelper(MethodDef method, ScopeBlock rootScope, ILBlock entry)
        {
            methodMap[method] = Tuple.Create(rootScope, entry);
        }

        public void AddBlock(MethodDef method, ILBlock block)
        {
            basicBlocks.Add(Tuple.Create(method, block));
        }

        public ScopeBlock LookupMethod(MethodDef method)
        {
            var m = methodMap[method];
            return m.Item1;
        }

        public ScopeBlock LookupMethod(MethodDef method, out ILBlock entry)
        {
            var m = methodMap[method];
            entry = m.Item2;
            return m.Item1;
        }

        public void AddChunk(IKoiChunk chunk)
        {
            extraChunks.Add(chunk);
        }

        public void ExportMethod(MethodDef method)
        {
            rtMutator.ReplaceMethodStub(method);
        }

        public IModuleWriterListener CommitModule(ModuleDefMD module)
        {
            return rtMutator.CommitModule(module);
        }

        public void CommitRuntime(ModuleDef targetModule = null)
        {
            rtMutator.CommitRuntime(targetModule);
            RuntimeLibrary = rtMutator.RuntimeLib;
            RuntimeSymbols = rtMutator.RuntimeSym;
        }

        [Obfuscation(Exclude = false, Feature = "+koi;-ref proxy")]
        private void OnKoiRequested(object sender, RequestKoiEventArgs e)
        {
            var header = new HeaderChunk(this);

            foreach(var block in basicBlocks) finalChunks.Add(block.Item2.CreateChunk(this, block.Item1));
            finalChunks.AddRange(extraChunks);
            //finalChunks.Add(new BinaryChunk(Watermark.GenerateWatermark((uint) settings.Seed)));
            Descriptor.Random.Shuffle(finalChunks);
            finalChunks.Insert(0, header);

            ComputeOffsets();
            FixupReferences();
            header.WriteData(this);
            e.Heap = CreateHeap();
        }

        private void ComputeOffsets()
        {
            uint offset = 0;
            foreach(var chunk in finalChunks)
            {
                chunk.OnOffsetComputed(offset);
                offset += chunk.Length;
            }
        }

        private void FixupReferences()
        {
            foreach(var block in basicBlocks)
            foreach(var instr in block.Item2.Content)
                if(instr.Operand is ILRelReference)
                {
                    var reference = (ILRelReference) instr.Operand;
                    instr.Operand = ILImmediate.Create(reference.Resolve(this), ASTType.I4);
                }
        }

        private KoiHeap CreateHeap()
        {
            if(settings.ExportDbgInfo)
                dbgWriter = new DbgWriter();

            var heap = new KoiHeap();
            foreach(var chunk in finalChunks) heap.AddChunk(chunk.GetData());
            if(dbgWriter != null)
                using(var serializer = dbgWriter.GetSerializer())
                {
                    foreach(var chunk in finalChunks)
                        serializer.WriteBlock(chunk as BasicBlockChunk);
                }
            return heap;
        }

        public void ResetData()
        {
            methodMap = new Dictionary<MethodDef, Tuple<ScopeBlock, ILBlock>>();
            basicBlocks = new List<Tuple<MethodDef, ILBlock>>();

            extraChunks = new List<IKoiChunk>();
            finalChunks = new List<IKoiChunk>();
            Descriptor.ResetData();

            rtMutator.InitHelpers();
        }
    }
}