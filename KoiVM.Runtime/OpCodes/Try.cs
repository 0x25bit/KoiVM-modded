#region

using System;
using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.OpCodes
{
    internal class Try : IOpCode
    {
        public byte Code => DarksVMConstants.OP_TRY;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var type = ctx.Stack[sp--].U1;

            var frame = new EHFrame();
            frame.EHType = type;
            if(type == DarksVMConstants.EH_CATCH) frame.CatchType = (Type) ctx.Instance.Data.LookupReference(ctx.Stack[sp--].U4);
            else if(type == DarksVMConstants.EH_FILTER) frame.FilterAddr = ctx.Stack[sp--].U8;
            frame.HandlerAddr = ctx.Stack[sp--].U8;

            ctx.Stack.SetTopPosition(sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;

            frame.BP = ctx.Registers[DarksVMConstants.REG_BP];
            frame.SP = ctx.Registers[DarksVMConstants.REG_SP];
            ctx.EHStack.Add(frame);

            state = ExecutionState.Next;
        }
    }
}