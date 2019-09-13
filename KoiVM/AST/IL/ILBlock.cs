#region

using dnlib.DotNet;
using KoiVM.CFG;
using KoiVM.RT;

#endregion

namespace KoiVM.AST.IL
{
    public class ILBlock : BasicBlock<ILInstrList>
    {
        public ILBlock(int id, ILInstrList content)
            : base(id, content)
        {
        }

        public virtual IKoiChunk CreateChunk(DarksVMRuntime rt, MethodDef method)
        {
            return new BasicBlockChunk(rt, method, this);
        }
    }
}