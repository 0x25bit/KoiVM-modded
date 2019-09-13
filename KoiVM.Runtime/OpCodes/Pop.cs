#region

using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.OpCodes
{
    internal class Pop : IOpCode
    {
        public byte Code => DarksVMConstants.OP_POP;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var slot = ctx.Stack[sp];
            ctx.Stack.SetTopPosition(--sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;

            var regId = ctx.ReadByte();
            if((regId == DarksVMConstants.REG_SP || regId == DarksVMConstants.REG_BP) && slot.O is StackRef)
                ctx.Registers[regId] = new DarksVMSlot {U4 = ((StackRef) slot.O).StackPos};
            else
                ctx.Registers[regId] = slot;
            state = ExecutionState.Next;
        }
    }
}