#region

using System;
using System.Collections.Generic;

#endregion

namespace KoiVM.AST.IL
{
    public class ILInstrList : List<ILInstruction>
    {
        public override string ToString()
        {
            return string.Join(Environment.NewLine, this);
        }

        public void VisitInstrs<T>(VisitFunc<ILInstrList, ILInstruction, T> visitFunc, T arg)
        {
            for(var i = 0; i < Count; i++)
                visitFunc(this, this[i], ref i, arg);
        }
    }
}