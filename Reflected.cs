using System.Reflection;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Effects;

namespace HiddenSettings
{
	public static class Reflected
	{
		/// <summary>
		/// tModLoader setting for Attack Speed Effects Tooltips
		/// </summary>
		/// <param name="newValue"></param>
		/// <returns></returns>
		public static int GetSet_ModLoader_attackSpeedScalingTooltipVisibility(int? newValue = null)
		{
			FieldInfo field = typeof(Terraria.ModLoader.ModLoader).GetField("attackSpeedScalingTooltipVisibility", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (int)field.GetValue(Main.instance);
		}

		/// <summary>
		/// tModLoader setting for Remove Forced Minimum Zoom
		/// </summary>
		/// <param name="newValue"></param>
		/// <returns></returns>
		public static bool GetSet_ModLoader_removeForcedMinimumZoom(bool? newValue = null)
		{
			FieldInfo field = typeof(Terraria.ModLoader.ModLoader).GetField("removeForcedMinimumZoom", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (bool)field.GetValue(Main.instance);
		}

		/// <summary>
		/// Terraria config for unlocking the Otherworldly music
		/// </summary>
		/// <param name="newValue"></param>
		/// <returns></returns>
		public static bool GetSet_Main_TOWMusicUnlocked(bool? newValue = null)
		{
			FieldInfo field = Terraria.Main.instance.GetType().GetField("TOWMusicUnlocked", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (bool)field.GetValue(Main.instance);
		}

		/// <summary>
		/// Terraria config for filter (shader) limit
		/// </summary>
		/// <param name="newValue"></param>
		/// <returns></returns>
		public static int GetSet_FilterManager__filterLimit(int? newValue = null)
		{
			Terraria.Graphics.Effects.FilterManager instance = Terraria.Graphics.Effects.Filters.Scene;
			FieldInfo field = instance.GetType().GetField("_filterLimit", BindingFlags.NonPublic | BindingFlags.Instance);
			if (newValue != null)
			{
				field.SetValue(instance, newValue);
			}
			return (int)field.GetValue(instance);
		}

		/// <summary>
		/// Terraria config for filter (shader) priority
		/// </summary>
		/// <param name="newValue"></param>
		/// <returns></returns>
		public static Terraria.Graphics.Effects.EffectPriority GetSet_FilterManager__priorityThreshold(EffectPriority? newValue = null)
		{
			Terraria.Graphics.Effects.FilterManager instance = Terraria.Graphics.Effects.Filters.Scene;
			FieldInfo field = instance.GetType().GetField("_priorityThreshold", BindingFlags.NonPublic | BindingFlags.Instance);
			if (newValue != null)
			{
				field.SetValue(instance, newValue);
			}
			return (EffectPriority)field.GetValue(instance);
		}

		/// <summary>
		/// Terraria config for task bar notification flashing
		/// </summary>
		/// <param name="newValue"></param>
		/// <returns></returns>
		public static GameNotificationType GetSet_Main__flashNotificationType(GameNotificationType? newValue = null)
		{
			FieldInfo field = Terraria.Main.instance.GetType().GetField("_flashNotificationType", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (GameNotificationType)field.GetValue(Main.instance);
		}

		/// <summary>
		/// Terraria config for Razer RGB
		/// </summary>
		/// <param name="newValue"></param>
		/// <returns></returns>
		public static bool GetSet_ChromaInitializer__useRazer(bool? newValue = null)
		{
			FieldInfo field = typeof(Terraria.Initializers.ChromaInitializer).GetField("_useRazer", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (bool)field.GetValue(Main.instance);
		}

		/// <summary>
		/// Terraria config for Corsair RGB
		/// </summary>
		/// <param name="newValue"></param>
		/// <returns></returns>
		public static bool GetSet_ChromaInitializer__useCorsair(bool? newValue = null)
		{
			FieldInfo field = typeof(Terraria.Initializers.ChromaInitializer).GetField("_useCorsair", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (bool)field.GetValue(Main.instance);
		}

		/// <summary>
		/// Terraria config for Logitech RGB
		/// </summary>
		/// <param name="newValue"></param>
		/// <returns></returns>
		public static bool GetSet_ChromaInitializer__useLogitech(bool? newValue = null)
		{
			FieldInfo field = typeof(Terraria.Initializers.ChromaInitializer).GetField("_useLogitech", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (bool)field.GetValue(Main.instance);
		}

		/// <summary>
		/// Terraria config for Steel Series RGB
		/// </summary>
		/// <param name="newValue"></param>
		/// <returns></returns>
		public static bool GetSet_ChromaInitializer__useSteelSeries(bool? newValue = null)
		{
			FieldInfo field = typeof(Terraria.Initializers.ChromaInitializer).GetField("_useSteelSeries", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (bool)field.GetValue(Main.instance);
		}

		/// <summary>
		/// Terraria config for RBG update rate
		/// </summary>
		/// <param name="newValue"></param>
		/// <returns></returns>
		public static float GetSet_ChromaInitializer__rgbUpdateRate(float? newValue = null)
		{
			FieldInfo field = typeof(Terraria.Initializers.ChromaInitializer).GetField("_rgbUpdateRate", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (float)field.GetValue(Main.instance);
		}

		/*
		public static Terraria.UI.UIElement? Invoke_HandlePanelCreation(Terraria.GameContent.UI.States.UIManageControls self, string bind, InputMode currentInputMode, Color color)
		{
			// Private, so use reflection to invoke it.
			MethodInfo method = self.GetType().GetMethod("HandlePanelCreation", BindingFlags.NonPublic | BindingFlags.Instance);
			return (Terraria.UI.UIElement?)method.Invoke(self, [bind, currentInputMode, color]);
		}
		*/

		/*
		public static IDictionary<string, ModKeybind> Get_KeybindLoader_modKeybinds()
		{
			FieldInfo field = typeof(Terraria.ModLoader.KeybindLoader).GetField("modKeybinds", BindingFlags.NonPublic | BindingFlags.Static);
			return (IDictionary<string, ModKeybind>)field.GetValue(null);
		}

		public static string Get_ModKeybind_FullName(ModKeybind instance)
		{
			PropertyInfo property = typeof(Terraria.ModLoader.ModKeybind).GetProperty("FullName", BindingFlags.NonPublic | BindingFlags.Instance);
			return (string)property.GetValue(instance);
		}
		*/
	}
}
