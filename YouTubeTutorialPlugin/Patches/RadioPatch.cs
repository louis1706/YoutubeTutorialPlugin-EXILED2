using HarmonyLib;
using InventorySystem.Items.Radio;
using PlayerRoles;

namespace YouTubeTutorialPlugin.Patches
{
	[HarmonyPatch(typeof(RadioItem))]
	[HarmonyPatch(nameof(RadioItem.BatteryPercent))]
	internal static class RadioPatch
	{
		static bool Prefix(RadioItem __instance)
		{
			return __instance.Owner.GetRoleId().GetTeam() == Team.ChaosInsurgency;
		}
	}
}
