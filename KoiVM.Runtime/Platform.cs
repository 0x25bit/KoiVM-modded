#region

using System;

#endregion

namespace What_a_great_VM
{
    internal static class Platform
    {
        public static readonly bool x64 = IntPtr.Size == 8;
        public static readonly bool LittleEndian = BitConverter.IsLittleEndian;
    }
}