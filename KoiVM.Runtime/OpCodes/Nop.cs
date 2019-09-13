#region

using KoiVM.Runtime.Dynamic;
using KoiVM.Runtime.Execution;

#endregion

namespace KoiVM.Runtime.OpCodes
{
    internal class Nop : IOpCode
    {
        public byte Code => DarksVMConstants.OP_NOP;

        public void Load(DarksVMContext ctx, out ExecutionState state)
        {
            state = ExecutionState.Next;
        }
    }
}