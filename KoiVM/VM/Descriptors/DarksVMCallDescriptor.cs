#region

using System;
using System.Linq;

#endregion

namespace KoiVM.VM
{
    public class VMCallDescriptor
    {
        private readonly int[] callOrder = Enumerable.Range(0, 256).ToArray();

        public VMCallDescriptor(Random random)
        {
            random.Shuffle(callOrder);
        }

        public int this[DarksVMCalls call] => callOrder[(int) call];

        public int EXIT => callOrder[0];

        public int BREAK => callOrder[1];

        public int ECALL => callOrder[2];

        public int CAST => callOrder[3];

        public int CKFINITE => callOrder[4];

        public int CKOVERFLOW => callOrder[5];

        public int RANGECHK => callOrder[6];

        public int INITOBJ => callOrder[7];

        public int LDFLD => callOrder[8];

        public int LDFTN => callOrder[9];

        public int TOKEN => callOrder[10];

        public int THROW => callOrder[11];

        public int SIZEOF => callOrder[12];

        public int STFLD => callOrder[13];

        public int BOX => callOrder[14];

        public int UNBOX => callOrder[15];

        public int LOCALLOC => callOrder[16];
    }
}