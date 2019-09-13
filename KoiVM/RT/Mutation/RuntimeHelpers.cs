#region

using dnlib.DotNet;
using dnlib.DotNet.Emit;
using KoiVM.AST.IL;
using KoiVM.AST.IR;
using KoiVM.CFG;
using KoiVM.VM;
using KoiVM.VMIL;
using KoiVM.VMIR;

#endregion

namespace KoiVM.RT.Mutation
{
    public class RuntimeHelpers
    {
        private RTConstants constants;

        private MethodDef methodINIT;
        private readonly DarksVMRuntime rt;
        private TypeDef rtHelperType;
        private readonly ModuleDef rtModule;

        public RuntimeHelpers(RTConstants constants, DarksVMRuntime rt, ModuleDef rtModule)
        {
            this.rt = rt;
            this.rtModule = rtModule;
            this.constants = constants;
            rtHelperType = new TypeDefUser("KoiVM.Runtime", "Helpers");
            AllocateHelpers();
        }

        public uint INIT
        {
            get;
            private set;
        }

        private MethodDef CreateHelperMethod(string name)
        {
            var helper = new MethodDefUser(name, MethodSig.CreateStatic(rtModule.CorLibTypes.Void));
            helper.Body = new CilBody();
            return helper;
        }

        private void AllocateHelpers()
        {
            methodINIT = CreateHelperMethod("INIT");
            INIT = rt.Descriptor.Data.GetExportId(methodINIT);
        }

        public void AddHelpers()
        {
            var scope = new ScopeBlock();

            var initBlock = new BasicBlock<IRInstrList>(1, new IRInstrList
            {
                new IRInstruction(IROpCode.RET)
            });
            scope.Content.Add(initBlock);

            var retnBlock = new BasicBlock<IRInstrList>(0, new IRInstrList
            {
                new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(rt.Descriptor.Runtime.VMCall[DarksVMCalls.EXIT]))
            });
            scope.Content.Add(initBlock);

            CompileHelpers(methodINIT, scope);

            var info = rt.Descriptor.Data.LookupInfo(methodINIT);
            scope.ProcessBasicBlocks<ILInstrList>(block =>
            {
                if(block.Id == 1)
                {
                    AddHelper(null, methodINIT, (ILBlock) block);
                    var blockKey = info.BlockKeys[block];
                    info.EntryKey = blockKey.EntryKey;
                    info.ExitKey = blockKey.ExitKey;
                }
                rt.AddBlock(methodINIT, (ILBlock) block);
            });
        }

        private void AddHelper(DarksVMMethodInfo info, MethodDef method, ILBlock block)
        {
            var helperScope = new ScopeBlock();
            block.Id = 0;
            helperScope.Content.Add(block);
            if(info != null)
            {
                var helperInfo = new DarksVMMethodInfo();
                var keys = info.BlockKeys[block];
                helperInfo.RootScope = helperScope;
                helperInfo.EntryKey = keys.EntryKey;
                helperInfo.ExitKey = keys.ExitKey;
                rt.Descriptor.Data.SetInfo(method, helperInfo);
            }
            rt.AddHelper(method, helperScope, block);
        }

        private void CompileHelpers(MethodDef method, ScopeBlock scope)
        {
            var methodCtx = new IRContext(method, method.Body);
            methodCtx.IsRuntime = true;
            var irTransformer = new IRTransformer(scope, methodCtx, rt);
            irTransformer.Transform();

            var ilTranslator = new ILTranslator(rt);
            var ilTransformer = new ILTransformer(method, scope, rt);
            ilTranslator.Translate(scope);
            ilTransformer.Transform();

            var postTransformer = new ILPostTransformer(method, scope, rt);
            postTransformer.Transform();
        }
    }
}