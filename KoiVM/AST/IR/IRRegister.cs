#region

using KoiVM.VM;

#endregion

namespace KoiVM.AST.IR
{
    public class IRRegister : IIROperand
    {
        public static readonly IRRegister BP = new IRRegister(DarksVMRegisters.BP, ASTType.I4);
        public static readonly IRRegister SP = new IRRegister(DarksVMRegisters.SP, ASTType.I4);
        public static readonly IRRegister IP = new IRRegister(DarksVMRegisters.IP);
        public static readonly IRRegister FL = new IRRegister(DarksVMRegisters.FL, ASTType.I4);
        public static readonly IRRegister K1 = new IRRegister(DarksVMRegisters.K1, ASTType.I4);
        public static readonly IRRegister K2 = new IRRegister(DarksVMRegisters.K2, ASTType.I4);
        public static readonly IRRegister M1 = new IRRegister(DarksVMRegisters.M1, ASTType.I4);
        public static readonly IRRegister M2 = new IRRegister(DarksVMRegisters.M2, ASTType.I4);

        public IRRegister(DarksVMRegisters reg)
        {
            Register = reg;
            Type = ASTType.Ptr;
        }

        public IRRegister(DarksVMRegisters reg, ASTType type)
        {
            Register = reg;
            Type = type;
        }

        public DarksVMRegisters Register
        {
            get;
            set;
        }

        public IRVariable SourceVariable
        {
            get;
            set;
        }

        public ASTType Type
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Register.ToString();
        }
    }
}