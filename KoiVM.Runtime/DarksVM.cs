#region

using System;
using System.Reflection;

#endregion

namespace What_a_great_VM
{
    public class DarksVM
    {
        public static Module a;

        public static object Load(uint s1, uint id, RuntimeTypeHandle type, uint s2, uint s3, object[] args)
        {
            uint[] y = new uint[0x10], k = new uint[0x10];
            s1 = (uint)923123u; uint x = (uint)7384832u; uint f = (uint)15643201u; uint v = (uint)905487329u;
            for (int i = 0; i < 0; i++)
            {
                s1 = (f >> 2) | (x << 34);
                x = (f >> 3) | (f << 29);
                s3 = f / v * v / f * 2 * 45 / x;
                f = (v >> 7) | (v << 25);
                s2 = (f >> 2) | (x << 14);
                v = (s1 >> 11) | (s1 << 21);
                f = f * 67 / s2 >> 6;
                s3 = (v >> 6) | (f << 9);
                s1 = (f >> 2) | (x << 34);
                x = (f >> 3) | (f << 29);
                f = (v >> 7) | (v << 25);
                s2 = (f >> 2) | (x << 14);
                v = (s1 >> 11) | (s1 << 21);
                x = f * 67 / s2 >> 6;
                s3 = (v >> 6) | (f << 9);
                s1 = (f >> 2) | (x << 34);
                v = f / v * v / f * 2 * 45 / x;
                x = (f >> 3) | (f << 29);
                f = (v >> 7) | (v << 25);
                s2 = (f >> 2) | (x << 14);
                v = (s1 >> 11) | (s1 << 21);
                v = f * 67 / s2 >> 6;
                f = f / v * v / f * 2 * 45 / x;
                s3 = (v >> 6) | (f << 9);
            }

            if (s3 == s3)
                a = Type.GetTypeFromHandle(type).Module;

            return DarksVMInstance.Instance(s1, a).Load(s2, s3, id, args);
        }

        public static unsafe void Load(uint s1, uint id, RuntimeTypeHandle type, uint s2, uint s3, void*[] typedRefs, void* retTypedRef)
        {
            s1 = (uint)923123u; uint x = (uint)7384832u; uint f = (uint)15643201u; uint v = (uint)905487329u;
            for (int i = 0; i < 0; i++)
            {
                s1 = (f >> 2) | (x << 34);
                x = (f >> 3) | (f << 29);
                s3 = f / v * v / f * 2 * 45 / x;
                f = (v >> 7) | (v << 25);
                s2 = (f >> 2) | (x << 14);
                v = (s1 >> 11) | (s1 << 21);
                f = f * 67 / s2 >> 6;
                s3 = (v >> 6) | (f << 9);
                s1 = (f >> 2) | (x << 34);
                x = (f >> 3) | (f << 29);
                f = (v >> 7) | (v << 25);
                s2 = (f >> 2) | (x << 14);
                v = (s1 >> 11) | (s1 << 21);
                x = f * 67 / s2 >> 6;
                s3 = (v >> 6) | (f << 9);
                s1 = (f >> 2) | (x << 34);
                v = f / v * v / f * 2 * 45 / x;
                x = (f >> 3) | (f << 29);
                f = (v >> 7) | (v << 25);
                s2 = (f >> 2) | (x << 14);
                v = (s1 >> 11) | (s1 << 21);
                v = f * 67 / s2 >> 6;
                f = f / v * v / f * 2 * 45 / x;
                s3 = (v >> 6) | (f << 9);
            }

            if (s3 == s3)
                a = Type.GetTypeFromHandle(type).Module;

            DarksVMInstance.Instance(s1, a).Load(s2, s3, id, typedRefs, retTypedRef);
        }

        internal static object OpenIntance(int c, ulong d, uint e, uint j, object[] h)
        {
            uint[] y = new uint[0x10], k = new uint[0x10];
            uint s1 = (uint)923123u; uint s2 = (uint)768342u; uint s3 = (uint)497293243u; uint b = (uint)76836482u;  uint x = (uint)7384832u; uint f = (uint)15643201u; uint v = (uint)905487329u;
            for (int i = 0; i < 0; i++)
            {
                s1 = (f >> 2) | (x << 34);
                x = (f >> 3) | (f << 29);
                s3 = f / v * v / f * 2 * 45 / x;
                f = (v >> 7) | (v << 25);
                s2 = (f >> 2) | (x << 14);
                v = (s1 >> 11) | (s1 << 21);
                f = f * 67 / s2 >> 6;
                s3 = (v >> 6) | (f << 9);
                s1 = (f >> 2) | (x << 34);
                x = (f >> 3) | (f << 29);
                f = (v >> 7) | (v << 25);
                s2 = (f >> 2) | (x << 14);
                v = (s1 >> 11) | (s1 << 21);
                x = f * 67 / s2 >> 6;
                s3 = (v >> 6) | (f << 9);
                s1 = (f >> 2) | (x << 34);
                v = f / v * v / f * 2 * 45 / x;
                x = (f >> 3) | (f << 29);
                f = (v >> 7) | (v << 25);
                s2 = (f >> 2) | (x << 14);
                v = (s1 >> 11) | (s1 << 21);
                v = f * 67 / s2 >> 6;
                f = f / v * v / f * 2 * 45 / x;
                s3 = (v >> 6) | (f << 9);
            }

            return DarksVMInstance.Instance(b, c).Load(d, e, j, h);
        }

        internal static unsafe void OpenIntance(int c, ulong d, uint e, uint j, void*[] h,
            void* m)
        {
            uint[] y = new uint[0x10], k = new uint[0x10];
            uint s1 = (uint)923123u; uint s2 = (uint)768342u; uint s3 = (uint)497293243u; uint b = (uint)76836482u;  uint x = (uint)7384832u; uint f = (uint)15643201u; uint v = (uint)905487329u;
            for (int i = 0; i < 0; i++)
            {
                s1 = (f >> 2) | (x << 34);
                x = (f >> 3) | (f << 29);
                s3 = f / v * v / f * 2 * 45 / x;
                f = (v >> 7) | (v << 25);
                s2 = (f >> 2) | (x << 14);
                v = (s1 >> 11) | (s1 << 21);
                f = f * 67 / s2 >> 6;
                s3 = (v >> 6) | (f << 9);
                s1 = (f >> 2) | (x << 34);
                x = (f >> 3) | (f << 29);
                f = (v >> 7) | (v << 25);
                s2 = (f >> 2) | (x << 14);
                v = (s1 >> 11) | (s1 << 21);
                x = f * 67 / s2 >> 6;
                s3 = (v >> 6) | (f << 9);
                s1 = (f >> 2) | (x << 34);
                v = f / v * v / f * 2 * 45 / x;
                x = (f >> 3) | (f << 29);
                f = (v >> 7) | (v << 25);
                s2 = (f >> 2) | (x << 14);
                v = (s1 >> 11) | (s1 << 21);
                v = f * 67 / s2 >> 6;
                f = f / v * v / f * 2 * 45 / x;
                s3 = (v >> 6) | (f << 9);
            }

            DarksVMInstance.Instance(b, c).Load(d, e, j, h, m);
        }
    }
}