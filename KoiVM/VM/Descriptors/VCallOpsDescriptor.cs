#region

using System;

#endregion

namespace KoiVM.VM
{
    public class VCallOpsDescriptor
    {
        private readonly uint[] ecallOrder = {0, 1, 2, 3};

        public VCallOpsDescriptor(Random random)
        {
            random.Shuffle(ecallOrder);
        }

        public uint ECALL_CALL => ecallOrder[0];

        public uint ECALL_CALLVIRT => ecallOrder[1];

        public uint ECALL_NEWOBJ => ecallOrder[2];

        public uint ECALL_CALLVIRT_CONSTRAINED => ecallOrder[3];
    }
}