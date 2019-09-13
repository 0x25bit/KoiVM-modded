#region

using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.VCalls
{
    internal class Exit : IVCall
    {
        public byte Code => DarksVMConstants.VCALL_EXIT;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            state = ExecutionState.Exit;
        }
    }
}