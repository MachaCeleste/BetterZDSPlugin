using BetterZDSPlugin;
using HarmonyLib;
using System;

[HarmonyPatch]
public class ZeroDaySystemPatch
{
    [HarmonyPatch(typeof(ZeroDaySystem), "IsRumorTime")]
    class IsRumorTimePatch
    {
        static bool Prefix(ZeroDaySystem __instance, ref bool __result)
        {
            if (!Plugin.disable.Value)
            {
                DateTime dateTime = ClockServer.Singleton.GetDateTime();
                __result = dateTime.Month % Plugin.modMonths.Value == 0 && dateTime.Day < Plugin.daysValid.Value;
            }
            else 
                __result = false;
            return false;
        }
    }
}