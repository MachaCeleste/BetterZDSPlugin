using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace BetterZDSPlugin;

[BepInPlugin("com.machaceleste.BetterZDSPlugin", MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    public static ConfigEntry<bool> disable;
    public static ConfigEntry<int> daysValid;
    public static ConfigEntry<int> modMonths;
        
    private void Awake()
    {
        disable = Config.Bind("Main", "Disable zero days", false, "Disable the entire ZDS rumor system.");
        daysValid = Config.Bind("Main", "Days rumors available", 15, new ConfigDescription("Number of days the rumors are available for.", new AcceptableValueRange<int>(1, 25)));
        modMonths = Config.Bind("Main", "Months modulo", 2, new ConfigDescription("Month % n == 0 Determines how often rumors are available.", new AcceptableValueRange<int>(1, 12)));

        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        var harmony = new Harmony("com.machaceleste.BetterZDSPlugin");
        harmony.PatchAll();
    }
}