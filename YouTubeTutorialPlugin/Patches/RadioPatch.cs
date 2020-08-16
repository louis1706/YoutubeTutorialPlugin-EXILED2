using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
