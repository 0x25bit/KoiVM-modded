#region

using System.Reflection;

#endregion

[assembly: Obfuscation(Exclude = true, Feature =
    "name('KoiVM.Confuser.exe'):+anti debug(mode=antinet)"
)]

[assembly: Obfuscation(Exclude = true, Feature =
        "preset(aggressive);+constants(mode=dynamic,decoderCount=4,cfg=false);" +
        //"+ctrl flow;+rename(renPublic=false,mode=sequential);" +
        "+ref proxy(typeErasure=true,internal=true);"

)]

[assembly: Obfuscation(Exclude = true, Feature =
    "module('KoiVM.Confuser.Internal.dll'):-ref proxy"
)]