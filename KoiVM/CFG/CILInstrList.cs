#region

using System;
using System.Collections.Generic;
using dnlib.DotNet.Emit;

#endregion

namespace KoiVM.CFG
{
    public class CILInstrList : List<Instruction>
    {
        public override string ToString()
        {
            return string.Join(Environment.NewLine, this);
        }
    }
}