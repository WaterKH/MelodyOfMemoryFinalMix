using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecryptBypassMod
{
    public class DecryptBypassMod
    {
    }

    [HarmonyPatch(typeof(AssetBundles.AssetBundleCryptgraphy), nameof(AssetBundles.AssetBundleCryptgraphy.Decrypt))]
    class AssetBundleManagerPatch
    {
        static bool Prefix(byte[] encrypted, string password, ref byte[] __result)
        {
            __result = encrypted;
            return true;
        }
    }
}
