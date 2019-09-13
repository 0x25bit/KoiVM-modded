#region

using System;

#endregion

namespace KoiVM.Runtime.Execution
{
    internal interface IReference
    {
        DarksVMSlot GetValue(DarksVMContext ctx, PointerType type);
        void SetValue(DarksVMContext ctx, DarksVMSlot slot, PointerType type);
        IReference Add(uint value);
        IReference Add(ulong value);

        void ToTypedReference(DarksVMContext ctx, TypedRefPtr typedRef, Type type);
    }
}