#region

using System;
using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.OpCodes
{
    internal class Leave : IOpCode
    {
        public byte Code => DarksVMConstants.OP_LEAVE;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var handler = ctx.Stack[sp--].U8;

            var frameIndex = ctx.EHStack.Count - 1;
            var frame = ctx.EHStack[frameIndex];

            if(frame.HandlerAddr != handler)
                throw new InvalidProgramException();
            ctx.EHStack.RemoveAt(frameIndex);

            if(frame.EHType == DarksVMConstants.EH_FINALLY)
            {
                ctx.Stack[++sp] = ctx.Registers[DarksVMConstants.REG_IP];
                ctx.Registers[DarksVMConstants.REG_K1].U1 = 0;
                ctx.Registers[DarksVMConstants.REG_IP].U8 = frame.HandlerAddr;
            }

            ctx.Stack.SetTopPosition(sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;

            state = ExecutionState.Next;
        }
    }
}