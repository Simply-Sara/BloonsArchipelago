using HarmonyLib;
using Il2CppAssets.Scripts.Unity.Player;

namespace BloonsArchipelago.Patches.BTD6Player
{
    [HarmonyPatch(typeof(Btd6Player), nameof(Btd6Player.HasUnlockedHero))]
    internal class HeroUnlocker
    {
        [HarmonyPrefix]
        public static bool Prefix(string towerId, ref bool __result)
        {
            if (BloonsArchipelago.sessionHandler.ready)
            {

                if (BloonsArchipelago.sessionHandler.HeroesUnlocked.Contains(towerId))
                {
                    __result = true;
                    if (!BloonsArchipelago.sessionHandler.LocationChecked(towerId))
                    {
                        BloonsArchipelago.sessionHandler.CompleteCheck(towerId);
                    }
                }
                else
                {
                    __result = false;
                }
                return false;
            }
            return true;
        }
    }
}
