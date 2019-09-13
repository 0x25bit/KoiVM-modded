#region

using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.OpCodes
{
    internal class SubR32 : IOpCode
    {
        public byte Code => DarksVMConstants.OP_SUB_R32;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var op1Slot = ctx.Stack[sp - 1];
            var op2Slot = ctx.Stack[sp];
            sp -= 1;
            ctx.Stack.SetTopPosition(sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;

            var slot = new DarksVMSlot();
            slot.R4 = op1Slot.R4 - op2Slot.R4;
            ctx.Stack[sp] = slot;

            var mask = (byte) (DarksVMConstants.FL_ZERO | DarksVMConstants.FL_SIGN | DarksVMConstants.FL_OVERFLOW | DarksVMConstants.FL_CARRY);
            var fl = (byte) (ctx.Registers[DarksVMConstants.REG_FL].U1 & ~mask);
            if(slot.R4 == 0)
                fl |= DarksVMConstants.FL_ZERO;
            else if(slot.R4 < 0)
                fl |= DarksVMConstants.FL_SIGN;
            ctx.Registers[DarksVMConstants.REG_FL].U1 = fl;

            state = ExecutionState.Next;
        }
    }

    internal class SubR64 : IOpCode
    {
        public byte Code => DarksVMConstants.OP_SUB_R64;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var op1Slot = ctx.Stack[sp - 1];
            var op2Slot = ctx.Stack[sp];
            sp -= 1;
            ctx.Stack.SetTopPosition(sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;

            var slot = new DarksVMSlot();
            slot.R8 = op1Slot.R8 - op2Slot.R8;
            ctx.Stack[sp] = slot;

            var mask = (byte) (DarksVMConstants.FL_ZERO | DarksVMConstants.FL_SIGN | DarksVMConstants.FL_OVERFLOW | DarksVMConstants.FL_CARRY);
            var fl = (byte) (ctx.Registers[DarksVMConstants.REG_FL].U1 & ~mask);
            if(slot.R8 == 0)
                fl |= DarksVMConstants.FL_ZERO;
            else if(slot.R8 < 0)
                fl |= DarksVMConstants.FL_SIGN;
            ctx.Registers[DarksVMConstants.REG_FL].U1 = fl;

            state = ExecutionState.Next;
        }
    }
}