namespace KoiVM.AST.ILAST
{
    public class ILASTVariable : ASTVariable, IILASTNode
    {
        public ILASTVariableType VariableType
        {
            get;
            set;
        }

        public object Annotation
        {
            get;
            set;
        }

        ASTType? IILASTNode.Type => base.Type;
    }
}