#region

using KoiVM.Runtime.Data;
using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.OpCodes
{
    internal class Vcall : IOpCode
    {
        public byte Code => DarksVMConstants.OP_VCALL;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var slot = ctx.Stack[sp];
            ctx.Stack.SetTopPosition(--sp);
            ctx.Registers[DarksVMConstants.REG_SP].U4 = sp;

            var vCall = VCallMap.Lookup(slot.U1);
            vCall.Load(ctx, out state);
        }
    }
}