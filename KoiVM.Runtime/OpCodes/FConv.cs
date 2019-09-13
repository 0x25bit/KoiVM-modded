#region

using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.OpCodes
{
    internal class FConvR32 : IOpCode
    {
        public byte Code => DarksVMConstants.OP_FCONV_R32;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var valueSlot = ctx.Stack[sp];

            valueSlot.R4 = (long) valueSlot.U8;

            ctx.Stack[sp] = valueSlot;

            state = ExecutionState.Next;
        }
    }

    internal class FConvR64 : IOpCode
    {
        public byte Code => DarksVMConstants.OP_FCONV_R64;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var valueSlot = ctx.Stack[sp];

            var fl = ctx.Registers[DarksVMConstants.REG_FL].U1;
            if((fl & DarksVMConstants.FL_UNSIGNED) != 0) valueSlot.R8 = valueSlot.U8;
            else valueSlot.R8 = (long) valueSlot.U8;
            ctx.Registers[DarksVMConstants.REG_FL].U1 = (byte) (fl & ~DarksVMConstants.FL_UNSIGNED);

            ctx.Stack[sp] = valueSlot;

            state = ExecutionState.Next;
        }
    }

    internal class FConvR32R64 : IOpCode
    {
        public byte Code => DarksVMConstants.OP_FCONV_R32_R64;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var valueSlot = ctx.Stack[sp];
            valueSlot.R8 = valueSlot.R4;
            ctx.Stack[sp] = valueSlot;

            state = ExecutionState.Next;
        }
    }

    internal class FConvR64R32 : IOpCode
    {
        public byte Code => DarksVMConstants.OP_FCONV_R64_R32;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var valueSlot = ctx.Stack[sp];
            valueSlot.R4 = (float) valueSlot.R8;
            ctx.Stack[sp] = valueSlot;

            state = ExecutionState.Next;
        }
    }
}