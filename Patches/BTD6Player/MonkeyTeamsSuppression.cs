using HarmonyLib;
using Il2CppAssets.Scripts.Unity.Player;

namespace BloonsArchipelago.Patches.BTD6Player
{
    [HarmonyPatch(typeof(Btd6Player), nameof(Btd6Player.UpdateMonkeyTeamsMaps))]
    internal class MonkeyTeamsSuppression
    {
        [HarmonyPrefix]
        private static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(Btd6Player), nameof(Btd6Player.RotateMonkeyTeamsMap))]
    internal class RotateMonkeyTeamsSuppression
    {
        [HarmonyPrefix]
        private static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(Btd6Player), nameof(Btd6Player.GenerateNewMonkeyTeamsMap))]
    internal class GenerateMonkeyTeamsSuppression
    {
        [HarmonyPrefix]
        private static bool Prefix()
        {
            return false;
        }
    }
}
