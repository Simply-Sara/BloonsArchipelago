﻿using BTD_Mod_Helper;
using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.Main.HeroSelect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloonsArchipelago.Patches
{
    [HarmonyPatch(typeof(HeroButton), nameof(HeroButton.Init))]
    internal class HeroButtonUnifier
    {
        [HarmonyPostfix]
        public static void Postfix(HeroButton __instance)
        {
            if (BloonsArchipelago.sessionHandler.ready)
            {
                __instance.mmCost = 0;
            }
        }
    }

    [HarmonyPatch(typeof(HeroButton), nameof(HeroButton.UpdatePanel))]
    internal class UnifyStyle
    {
        [HarmonyPostfix]
        public static void Postfix(HeroButton __instance)
        {
            if (BloonsArchipelago.sessionHandler.ready)
            {
                if (!BloonsArchipelago.sessionHandler.HeroesUnlocked.Contains(__instance.heroModel.name.Replace("HeroDetailsModel_", "")))
                {
                    __instance.transform.GetChild(2).gameObject.SetActive(true);
                    __instance.lockedLvlUnlockText.text = "";
                }
            }
        }
    }

    [HarmonyPatch(typeof(HeroUpgradeDetails), nameof(HeroUpgradeDetails.Awake))]
    internal class PreventDoubleBuy
    {
        [HarmonyPostfix]
        public static void Postfix(HeroUpgradeDetails __instance)
        {
            if (BloonsArchipelago.sessionHandler.ready)
            {
                __instance.buyHeroButton.gameObject.SetActive(false);
            }
        }
    }
}
