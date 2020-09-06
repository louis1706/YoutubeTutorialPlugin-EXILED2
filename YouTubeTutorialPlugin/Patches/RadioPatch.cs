using HarmonyLib;

namespace YouTubeTutorialPlugin.Patches
{
	[HarmonyPatch(typeof(Radio))]
	[HarmonyPatch(nameof(Radio.UseBattery))]
	internal static class RadioPatch
	{
		static bool Prefix(Radio __instance)
		{
			return false;
		}
	}
}
