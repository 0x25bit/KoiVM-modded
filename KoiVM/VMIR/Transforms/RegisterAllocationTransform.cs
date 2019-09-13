#region

using KoiVM.VMIR.RegAlloc;

#endregion

namespace KoiVM.VMIR.Transforms
{
    public class RegisterAllocationTransform : ITransform
    {
        public static readonly object RegAllocatorKey = new object();
        private RegisterAllocator allocator;

        public void Initialize(IRTransformer tr)
        {
            allocator = new RegisterAllocator(tr);
            allocator.Initialize();
            tr.Annotations[RegAllocatorKey] = allocator;
        }

        public void Transform(IRTransformer tr)
        {
            allocator.Allocate(tr.Block);
        }
    }
}