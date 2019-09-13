#region

using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.OpCodes
{
    internal class Call : IOpCode
    {
        public byte Code => DarksVMConstants.OP_CALL;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var slot = ctx.Stack[sp];
            ctx.Stack[sp] = ctx.Registers[DarksVMConstants.REG_IP];
            ctx.Registers[DarksVMConstants.REG_IP].U8 = slot.U8;
            state = ExecutionState.Next;
        }
    }
}