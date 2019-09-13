#region

using System;

#endregion

namespace KoiVM.VM
{
    public class ArchDescriptor
    {
        public ArchDescriptor(Random random)
        {
            OpCodes = new OpCodeDescriptor(random);
            Flags = new FlagDescriptor(random);
            Registers = new RegisterDescriptor(random);
        }

        public OpCodeDescriptor OpCodes
        {
            get;
        }

        public FlagDescriptor Flags
        {
            get;
        }

        public RegisterDescriptor Registers
        {
            get;
        }
    }
}