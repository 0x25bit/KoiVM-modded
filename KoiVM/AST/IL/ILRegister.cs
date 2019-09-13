#region

using System.Collections.Generic;
using KoiVM.VM;

#endregion

namespace KoiVM.AST.IL
{
    public class ILRegister : IILOperand
    {
        private static readonly Dictionary<DarksVMRegisters, ILRegister> regMap = new Dictionary<DarksVMRegisters, ILRegister>();

        public static readonly ILRegister R0 = new ILRegister(DarksVMRegisters.R0);
        public static readonly ILRegister R1 = new ILRegister(DarksVMRegisters.R1);
        public static readonly ILRegister R2 = new ILRegister(DarksVMRegisters.R2);
        public static readonly ILRegister R3 = new ILRegister(DarksVMRegisters.R3);
        public static readonly ILRegister R4 = new ILRegister(DarksVMRegisters.R4);
        public static readonly ILRegister R5 = new ILRegister(DarksVMRegisters.R5);
        public static readonly ILRegister R6 = new ILRegister(DarksVMRegisters.R6);
        public static readonly ILRegister R7 = new ILRegister(DarksVMRegisters.R7);

        public static readonly ILRegister BP = new ILRegister(DarksVMRegisters.BP);
        public static readonly ILRegister SP = new ILRegister(DarksVMRegisters.SP);
        public static readonly ILRegister IP = new ILRegister(DarksVMRegisters.IP);
        public static readonly ILRegister FL = new ILRegister(DarksVMRegisters.FL);
        public static readonly ILRegister K1 = new ILRegister(DarksVMRegisters.K1);
        public static readonly ILRegister K2 = new ILRegister(DarksVMRegisters.K2);
        public static readonly ILRegister M1 = new ILRegister(DarksVMRegisters.M1);
        public static readonly ILRegister M2 = new ILRegister(DarksVMRegisters.M2);

        private ILRegister(DarksVMRegisters reg)
        {
            Register = reg;
            regMap.Add(reg, this);
        }

        public DarksVMRegisters Register
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Register.ToString();
        }

        public static ILRegister LookupRegister(DarksVMRegisters reg)
        {
            return regMap[reg];
        }
    }
}