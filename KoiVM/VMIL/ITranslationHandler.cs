#region

using KoiVM.AST.IR;
using KoiVM.VMIR;

#endregion

namespace KoiVM.VMIL
{
    public interface ITranslationHandler
    {
        IROpCode IRCode
        {
            get;
        }

        void Translate(IRInstruction instr, ILTranslator tr);
    }
}