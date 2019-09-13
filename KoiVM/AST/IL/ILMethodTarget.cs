#region

using dnlib.DotNet;
using KoiVM.RT;

#endregion

namespace KoiVM.AST.IL
{
    public class ILMethodTarget : IILOperand, IHasOffset
    {
        private ILBlock methodEntry;

        public ILMethodTarget(MethodDef target)
        {
            Target = target;
        }

        public MethodDef Target
        {
            get;
            set;
        }

        public uint Offset => methodEntry == null ? 0 : methodEntry.Content[0].Offset;

        public void Resolve(DarksVMRuntime runtime)
        {
            runtime.LookupMethod(Target, out methodEntry);
        }

        public override string ToString()
        {
            return Target.ToString();
        }
    }
}