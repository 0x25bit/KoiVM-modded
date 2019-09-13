#region

using System;
using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;
using KoiVM.Runtime.Execution.Internal;

#endregion

namespace KoiVM.Runtime.VCalls
{
    internal class Sizeof : IVCall
    {
        public byte Code => DarksVMConstants.VCALL_SIZEOF;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[DarksVMConstants.REG_SP].U4;
            var bp = ctx.Registers[DarksVMConstants.REG_BP].U4;
            var type = (Type) ctx.Instance.Data.LookupReference(ctx.Stack[sp].U4);
            ctx.Stack[sp] = new DarksVMSlot
            {
                U4 = (uint) SizeOfHelper.SizeOf(type)
            };

            state = ExecutionState.Next;
        }
    }
}