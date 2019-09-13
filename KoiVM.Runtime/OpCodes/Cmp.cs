#region

using What_a_great_VM;
using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.OpCodes
{
    internal class CmpDword : IOpCode
    {
        public byte Code => DarksVMConstants.OP_CMP_DWORD;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var op1Slot = ctx.Stack[sp - 1];
            var op2Slot = ctx.Stack[sp];
            sp -= 2;
            ctx.Stack.SetTopPosition(sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;

            var result = op1Slot.U4 - op2Slot.U4;

            var mask = (byte) (DarksVMConstants.FL_ZERO | DarksVMConstants.FL_SIGN | DarksVMConstants.FL_OVERFLOW | DarksVMConstants.FL_CARRY);
            var fl = ctx.Registers[DarksVMConstants.REG_FL].U1;
            Utils.UpdateFL(result, op2Slot.U4, op1Slot.U4, result, ref fl, mask);
            ctx.Registers[DarksVMConstants.REG_FL].U1 = fl;

            state = ExecutionState.Next;
        }
    }

    internal class CmpQword : IOpCode
    {
        public byte Code => DarksVMConstants.OP_CMP_QWORD;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var op1Slot = ctx.Stack[sp - 1];
            var op2Slot = ctx.Stack[sp];
            sp -= 2;
            ctx.Stack.SetTopPosition(sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;

            var result = op1Slot.U8 - op2Slot.U8;

            var mask = (byte) (DarksVMConstants.FL_ZERO | DarksVMConstants.FL_SIGN | DarksVMConstants.FL_OVERFLOW | DarksVMConstants.FL_CARRY);
            var fl = ctx.Registers[DarksVMConstants.REG_FL].U1;
            Utils.UpdateFL(result, op2Slot.U8, op1Slot.U8, result, ref fl, mask);
            ctx.Registers[DarksVMConstants.REG_FL].U1 = fl;

            state = ExecutionState.Next;
        }
    }

    internal class CmpR32 : IOpCode
    {
        public byte Code => DarksVMConstants.OP_CMP_R32;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var op1Slot = ctx.Stack[sp - 1];
            var op2Slot = ctx.Stack[sp];
            sp -= 2;
            ctx.Stack.SetTopPosition(sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;

            var result = op1Slot.R4 - op2Slot.R4;

            var mask = (byte) (DarksVMConstants.FL_ZERO | DarksVMConstants.FL_SIGN | DarksVMConstants.FL_OVERFLOW | DarksVMConstants.FL_CARRY);
            var fl = (byte) (ctx.Registers[DarksVMConstants.REG_FL].U1 & ~mask);
            if(result == 0)
                fl |= DarksVMConstants.FL_ZERO;
            else if(result < 0)
                fl |= DarksVMConstants.FL_SIGN;
            ctx.Registers[DarksVMConstants.REG_FL].U1 = fl;

            state = ExecutionState.Next;
        }
    }

    internal class CmpR64 : IOpCode
    {
        public byte Code => DarksVMConstants.OP_CMP_R64;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var op1Slot = ctx.Stack[sp - 1];
            var op2Slot = ctx.Stack[sp];
            sp -= 2;
            ctx.Stack.SetTopPosition(sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;

            var result = op1Slot.R8 - op2Slot.R8;

            var mask = (byte) (DarksVMConstants.FL_ZERO | DarksVMConstants.FL_SIGN | DarksVMConstants.FL_OVERFLOW | DarksVMConstants.FL_CARRY);
            var fl = (byte) (ctx.Registers[DarksVMConstants.REG_FL].U1 & ~mask);
            if(result == 0)
                fl |= DarksVMConstants.FL_ZERO;
            else if(result < 0)
                fl |= DarksVMConstants.FL_SIGN;
            ctx.Registers[DarksVMConstants.REG_FL].U1 = fl;

            state = ExecutionState.Next;
        }
    }

    internal class Cmp : IOpCode
    {
        public byte Code => DarksVMConstants.OP_CMP;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var op1Slot = ctx.Stack[sp - 1];
            var op2Slot = ctx.Stack[sp];
            sp -= 2;
            ctx.Stack.SetTopPosition(sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;

            int result;
            if(ReferenceEquals(op1Slot.O, op2Slot.O))
                result = 0;
            else
                result = -1;

            var mask = (byte) (DarksVMConstants.FL_ZERO | DarksVMConstants.FL_SIGN | DarksVMConstants.FL_OVERFLOW | DarksVMConstants.FL_CARRY);
            var fl = (byte) (ctx.Registers[DarksVMConstants.REG_FL].U1 & ~mask);
            if(result == 0)
                fl |= DarksVMConstants.FL_ZERO;
            else if(result < 0)
                fl |= DarksVMConstants.FL_SIGN;
            ctx.Registers[DarksVMConstants.REG_FL].U1 = fl;

            state = ExecutionState.Next;
        }
    }
}