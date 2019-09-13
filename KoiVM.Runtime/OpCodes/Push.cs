#region

using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.OpCodes
{
    internal class PushRByte : IOpCode
    {
        public byte Code => DarksVMConstants.OP_PUSHR_BYTE;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            ctx.Stack.SetTopPosition(++sp);

            var regId = ctx.ReadByte();
            var slot = ctx.Registers[regId];
            ctx.Stack[sp] = new DarksVMSlot {U1 = slot.U1};

            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;
            state = ExecutionState.Next;
        }
    }

    internal class PushRWord : IOpCode
    {
        public byte Code => DarksVMConstants.OP_PUSHR_WORD;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            ctx.Stack.SetTopPosition(++sp);

            var regId = ctx.ReadByte();
            var slot = ctx.Registers[regId];
            ctx.Stack[sp] = new DarksVMSlot {U2 = slot.U2};

            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;
            state = ExecutionState.Next;
        }
    }

    internal class PushRDword : IOpCode
    {
        public byte Code => DarksVMConstants.OP_PUSHR_DWORD;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            ctx.Stack.SetTopPosition(++sp);

            var regId = ctx.ReadByte();
            var slot = ctx.Registers[regId];
            if(regId == DarksVMConstants.REG_SP || regId == DarksVMConstants.REG_BP)
                ctx.Stack[sp] = new DarksVMSlot {O = new StackRef(slot.U4)};
            else
                ctx.Stack[sp] = new DarksVMSlot {U4 = slot.U4};

            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;
            state = ExecutionState.Next;
        }
    }

    internal class PushRQword : IOpCode
    {
        public byte Code => DarksVMConstants.OP_PUSHR_QWORD;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            ctx.Stack.SetTopPosition(++sp);

            var regId = ctx.ReadByte();
            var slot = ctx.Registers[regId];
            ctx.Stack[sp] = new DarksVMSlot {U8 = slot.U8};

            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;
            state = ExecutionState.Next;
        }
    }

    internal class PushRObject : IOpCode
    {
        public byte Code => DarksVMConstants.OP_PUSHR_OBJECT;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            ctx.Stack.SetTopPosition(++sp);

            var regId = ctx.ReadByte();
            var slot = ctx.Registers[regId];
            ctx.Stack[sp] = slot;

            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;
            state = ExecutionState.Next;
        }
    }

    internal class PushIDword : IOpCode
    {
        public byte Code => DarksVMConstants.OP_PUSHI_DWORD;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            ctx.Stack.SetTopPosition(++sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;

            ulong imm = ctx.ReadByte();
            imm |= (ulong) ctx.ReadByte() << 8;
            imm |= (ulong) ctx.ReadByte() << 16;
            imm |= (ulong) ctx.ReadByte() << 24;
            var sx = (imm & 0x80000000) != 0 ? 0xffffffffUL << 32 : 0;
            ctx.Stack[sp] = new DarksVMSlot {U8 = sx | imm};
            state = ExecutionState.Next;
        }
    }

    internal class PushIQword : IOpCode
    {
        public byte Code => DarksVMConstants.OP_PUSHI_QWORD;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            ctx.Stack.SetTopPosition(++sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;

            ulong imm = ctx.ReadByte();
            imm |= (ulong) ctx.ReadByte() << 8;
            imm |= (ulong) ctx.ReadByte() << 16;
            imm |= (ulong) ctx.ReadByte() << 24;
            imm |= (ulong) ctx.ReadByte() << 32;
            imm |= (ulong) ctx.ReadByte() << 40;
            imm |= (ulong) ctx.ReadByte() << 48;
            imm |= (ulong) ctx.ReadByte() << 56;
            ctx.Stack[sp] = new DarksVMSlot {U8 = imm};
            state = ExecutionState.Next;
        }
    }
}