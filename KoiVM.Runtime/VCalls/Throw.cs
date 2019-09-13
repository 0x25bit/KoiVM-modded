#region

using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.VCalls
{
    internal class Throw : IVCall
    {
        public byte Code => DarksVMConstants.VCALL_THROW;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var type = ctx.Stack[sp--].U4;
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;
            if(type == 1)
                state = ExecutionState.Rethrow;
            else
                state = ExecutionState.Throw;
        }
    }
}