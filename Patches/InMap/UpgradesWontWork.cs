using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloonsArchipelago.Patches.InMap
{
    //Reference to Wall Kicks Wont Work from SM64DS which in of itself is a play on the original star, Wall Kicks Will Work
    [HarmonyPatch(typeof(UpgradeButton), nameof(UpgradeButton.HasUnlockedUpgrade))]
    internal class UpgradesWontWork
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result)
        {
            if (BloonsArchipelago.sessionHandler.ready)
            {
                __result = true;
                return false;
            }
            return true;
        }
    }
}
