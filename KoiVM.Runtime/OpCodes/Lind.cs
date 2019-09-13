#region

using System;
using What_a_great_VM;
using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.OpCodes
{
    internal class LindByte : IOpCode
    {
        public byte Code => DarksVMConstants.OP_LIND_BYTE;

        public unsafe void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var adrSlot = ctx.Stack[sp];

            DarksVMSlot valSlot;
            if(adrSlot.O is IReference)
            {
                valSlot = ((IReference) adrSlot.O).GetValue(ctx, PointerType.BYTE);
            }
            else
            {
                var ptr = (byte*) adrSlot.U8;
                valSlot = new DarksVMSlot {U1 = *ptr};
            }
            ctx.Stack[sp] = valSlot;

            state = ExecutionState.Next;
        }
    }

    internal class LindWord : IOpCode
    {
        public byte Code => DarksVMConstants.OP_LIND_WORD;

        public unsafe void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var adrSlot = ctx.Stack[sp];

            DarksVMSlot valSlot;
            if(adrSlot.O is IReference)
            {
                valSlot = ((IReference) adrSlot.O).GetValue(ctx, PointerType.WORD);
            }
            else
            {
                var ptr = (ushort*) adrSlot.U8;
                valSlot = new DarksVMSlot {U2 = *ptr};
            }
            ctx.Stack[sp] = valSlot;

            state = ExecutionState.Next;
        }
    }

    internal class LindDword : IOpCode
    {
        public byte Code => DarksVMConstants.OP_LIND_DWORD;

        public unsafe void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var adrSlot = ctx.Stack[sp];

            DarksVMSlot valSlot;
            if(adrSlot.O is IReference)
            {
                valSlot = ((IReference) adrSlot.O).GetValue(ctx, PointerType.DWORD);
            }
            else
            {
                var ptr = (uint*) adrSlot.U8;
                valSlot = new DarksVMSlot {U4 = *ptr};
            }
            ctx.Stack[sp] = valSlot;

            state = ExecutionState.Next;
        }
    }

    internal class LindQword : IOpCode
    {
        public byte Code => DarksVMConstants.OP_LIND_QWORD;

        public unsafe void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var adrSlot = ctx.Stack[sp];

            DarksVMSlot valSlot;
            if(adrSlot.O is IReference)
            {
                valSlot = ((IReference) adrSlot.O).GetValue(ctx, PointerType.QWORD);
            }
            else
            {
                var ptr = (ulong*) adrSlot.U8;
                valSlot = new DarksVMSlot {U8 = *ptr};
            }
            ctx.Stack[sp] = valSlot;

            state = ExecutionState.Next;
        }
    }

    internal class LindObject : IOpCode
    {
        public byte Code => DarksVMConstants.OP_LIND_OBJECT;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var adrSlot = ctx.Stack[sp];

            DarksVMSlot valSlot;
            if(adrSlot.O is IReference) valSlot = ((IReference) adrSlot.O).GetValue(ctx, PointerType.OBJECT);
            else throw new ExecutionEngineException();
            ctx.Stack[sp] = valSlot;

            state = ExecutionState.Next;
        }
    }

    internal class LindPtr : IOpCode
    {
        public byte Code => DarksVMConstants.OP_LIND_PTR;

        public unsafe void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var adrSlot = ctx.Stack[sp];

            DarksVMSlot valSlot;
            if(adrSlot.O is IReference)
            {
                valSlot = ((IReference) adrSlot.O).GetValue(ctx, Platform.x64 ? PointerType.QWORD : PointerType.DWORD);
            }
            else
            {
                if(Platform.x64)
                {
                    var ptr = (ulong*) adrSlot.U8;
                    valSlot = new DarksVMSlot {U8 = *ptr};
                }
                else
                {
                    var ptr = (uint*) adrSlot.U8;
                    valSlot = new DarksVMSlot {U4 = *ptr};
                }
            }
            ctx.Stack[sp] = valSlot;

            state = ExecutionState.Next;
        }
    }
}