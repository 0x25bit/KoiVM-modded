#region

using System.Reflection;

#endregion

[assembly: AssemblyTitle("KoiVM Confuser")]
[assembly: AssemblyDescription("KoiVM Confuser Interface")]
[assembly: AssemblyProduct("DarksVM - KoiVM modded")]
[assembly: AssemblyCompany("d4rk.fr")]
[assembly: AssemblyCopyright("Copyright (C) darkshoz 2019")]

#if DEBUG

[assembly: AssemblyConfiguration("Debug")]
#else

[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyVersion("2.0.0.0")]
[assembly: AssemblyFileVersion("2.0.0.0")]
[assembly: AssemblyInformationalVersion("2.0")]