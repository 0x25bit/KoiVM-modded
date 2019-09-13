#region

using System;
using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.VCalls
{
    internal class Ckoverflow : IVCall
    {
        public byte Code => DarksVMConstants.VCALL_CKOVERFLOW;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var fSlot = ctx.Stack[sp--];

            if(fSlot.U4 != 0)
                throw new OverflowException();

            ctx.Stack.SetTopPosition(sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;
            state = ExecutionState.Next;
        }
    }
}