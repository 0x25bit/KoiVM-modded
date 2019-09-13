#region

using KoiVM.RT;

#endregion

namespace KoiVM.AST.IL
{
    public class ILDataTarget : IILOperand, IHasOffset
    {
        public ILDataTarget(BinaryChunk target)
        {
            Target = target;
        }

        public BinaryChunk Target
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public uint Offset => Target.Offset;

        public override string ToString()
        {
            return Name;
        }
    }
}