#region

using System;

#endregion

namespace KoiVM.VM
{
    public class RuntimeDescriptor
    {
        public RuntimeDescriptor(Random random)
        {
            VMCall = new VMCallDescriptor(random);
            VCallOps = new VCallOpsDescriptor(random);
            RTFlags = new RTFlagDescriptor(random);
        }

        public VMCallDescriptor VMCall
        {
            get;
        }

        public VCallOpsDescriptor VCallOps
        {
            get;
        }

        public RTFlagDescriptor RTFlags
        {
            get;
        }
    }
}