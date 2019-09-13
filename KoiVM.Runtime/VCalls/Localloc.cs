#region

using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.VCalls
{
    internal class Localloc : IVCall
    {
        public byte Code => DarksVMConstants.VCALL_LOCALLOC;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var bp = ctx.Registers[DarksVMConstants.REG_BP].U4;
            var size = ctx.Stack[sp].U4;
            ctx.Stack[sp] = new DarksVMSlot
            {
                U8 = (ulong) ctx.Stack.Localloc(bp, size)
            };

            state = ExecutionState.Next;
        }
    }
}