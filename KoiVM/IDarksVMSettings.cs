#region

using dnlib.DotNet;

#endregion

namespace KoiVM
{
    public interface IDarksVMSettings
    {
        int Seed
        {
            get;
        }

        bool IsDebug
        {
            get;
        }

        bool ExportDbgInfo
        {
            get;
        }

        bool DoStackWalk
        {
            get;
        }

        bool IsVirtualized(MethodDef method);
        bool IsExported(MethodDef method);
    }
}