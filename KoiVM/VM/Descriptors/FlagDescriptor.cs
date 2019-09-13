#region

using System;
using System.Linq;

#endregion

namespace KoiVM.VM
{
    public class FlagDescriptor
    {
        private readonly int[] flagOrder = Enumerable.Range(0, (int)DarksVMFlags.Max).ToArray();

        public FlagDescriptor(Random random)
        {
            random.Shuffle(flagOrder);
        }

        public int this[DarksVMFlags flag] => flagOrder[(int) flag];

        public int OVERFLOW => flagOrder[0];

        public int CARRY => flagOrder[1];

        public int ZERO => flagOrder[2];

        public int SIGN => flagOrder[3];

        public int UNSIGNED => flagOrder[4];

        public int BEHAV1 => flagOrder[5];

        public int BEHAV2 => flagOrder[6];

        public int BEHAV3 => flagOrder[7];
    }
}