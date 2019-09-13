#region

using dnlib.DotNet.Emit;
using KoiVM.AST.ILAST;
using KoiVM.AST.IR;

#endregion

namespace KoiVM.VMIR
{
    public interface ITranslationHandler
    {
        Code ILCode
        {
            get;
        }

        IIROperand Translate(ILASTExpression expr, IRTranslator tr);
    }
}