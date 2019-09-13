#region

using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.OpCodes
{
    internal class Ret : IOpCode
    {
        public byte Code => DarksVMConstants.OP_RET;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var slot = ctx.Stack[sp];
            ctx.Stack.SetTopPosition(--sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;

            ctx.Registers[DarksVMConstants.REG_IP].U8 = slot.U8;
            state = ExecutionState.Next;
        }
    }
}