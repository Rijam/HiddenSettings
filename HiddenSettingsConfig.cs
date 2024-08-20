using System;
using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;
using Terraria;
using Terraria.UI;
using Terraria.ModLoader.Config;
using Terraria.Graphics.Effects;
using Terraria.GameContent;

namespace HiddenSettings
{
	public class HiddenSettingsConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		public override void OnLoaded()
		{
			
		}

		public override void OnChanged()
		{
			if (Main.temporaryGUIScaleSlider == -1f)
			{
				Main.temporaryGUIScaleSlider = Main.UIScaleWanted;
			}
			Main.UIScale = Main.temporaryGUIScaleSlider;

			if (Main.graphics.IsFullScreen || Main.PendingBorderlessState != Main.screenBorderless || Main.PendingResolutionWidth != Main.screenWidth || Main.PendingResolutionHeight != Main.screenHeight)
			{
				Main.screenBorderless = Main.PendingBorderlessState;
				Main.screenBorderlessPendingResizes = (Main.screenBorderless ? 6 : 0);
				Main.SetResolution(Main.PendingResolutionWidth, Main.PendingResolutionHeight);
			}

			Main.SaveSettings();

			/*Terraria.Graphics.Effects.FilterManager filterManagerInstance = Terraria.Graphics.Effects.Filters.Scene;
			MethodInfo filterManagerMethod = filterManagerInstance.GetType().GetMethod("Configuration_OnSave", BindingFlags.NonPublic | BindingFlags.Instance);
			filterManagerMethod.Invoke(filterManagerInstance, [Main.Configuration]);

			MethodInfo chromaInitializerMethod = typeof(Terraria.Initializers.ChromaInitializer).GetMethod("Configuration_OnSave", BindingFlags.NonPublic | BindingFlags.Static);
			chromaInitializerMethod.Invoke(typeof(Terraria.Initializers.ChromaInitializer), [Main.Configuration]);*/

			// Main.NewText($"Main.cFavoriteKey {Main.cFavoriteKey} Main.FavoriteKey {Main.FavoriteKey}");
		}

		public int GetSet_ModLoader_attackSpeedScalingTooltipVisibility(int? newValue = null)
		{
			FieldInfo field = typeof(Terraria.ModLoader.ModLoader).GetField("attackSpeedScalingTooltipVisibility", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (int)field.GetValue(Main.instance);
		}

		public bool GetSet_ModLoader_removeForcedMinimumZoom(bool? newValue = null)
		{
			FieldInfo field = typeof(Terraria.ModLoader.ModLoader).GetField("removeForcedMinimumZoom", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (bool)field.GetValue(Main.instance);
		}

		public bool GetSet_Main_TOWMusicUnlocked(bool? newValue = null)
		{
			FieldInfo field = Terraria.Main.instance.GetType().GetField("TOWMusicUnlocked", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (bool)field.GetValue(Main.instance);
		}

		public int GetSet_FilterManager__filterLimit(int? newValue = null)
		{
			Terraria.Graphics.Effects.FilterManager instance = Terraria.Graphics.Effects.Filters.Scene;
			FieldInfo field = instance.GetType().GetField("_filterLimit", BindingFlags.NonPublic | BindingFlags.Instance);
			if (newValue != null)
			{
				field.SetValue(instance, newValue);
			}
			return (int)field.GetValue(instance);
		}

		public Terraria.Graphics.Effects.EffectPriority GetSet_FilterManager__priorityThreshold(EffectPriority? newValue = null)
		{
			Terraria.Graphics.Effects.FilterManager instance = Terraria.Graphics.Effects.Filters.Scene;
			FieldInfo field = instance.GetType().GetField("_priorityThreshold", BindingFlags.NonPublic | BindingFlags.Instance);
			if (newValue != null)
			{
				field.SetValue(instance, newValue);
			}
			return (EffectPriority)field.GetValue(instance);
		}

		public GameNotificationType GetSet_Main__flashNotificationType(GameNotificationType? newValue = null)
		{
			FieldInfo field = Terraria.Main.instance.GetType().GetField("_flashNotificationType", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (GameNotificationType)field.GetValue(Main.instance);
		}

		public bool GetSet_ChromaInitializer__useRazer(bool? newValue = null)
		{
			FieldInfo field = typeof(Terraria.Initializers.ChromaInitializer).GetField("_useRazer", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (bool)field.GetValue(Main.instance);
		}
		public bool GetSet_ChromaInitializer__useCorsair(bool? newValue = null)
		{
			FieldInfo field = typeof(Terraria.Initializers.ChromaInitializer).GetField("_useCorsair", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (bool)field.GetValue(Main.instance);
		}
		public bool GetSet_ChromaInitializer__useLogitech(bool? newValue = null)
		{
			FieldInfo field = typeof(Terraria.Initializers.ChromaInitializer).GetField("_useLogitech", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (bool)field.GetValue(Main.instance);
		}
		public bool GetSet_ChromaInitializer__useSteelSeries(bool? newValue = null)
		{
			FieldInfo field = typeof(Terraria.Initializers.ChromaInitializer).GetField("_useSteelSeries", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (bool)field.GetValue(Main.instance);
		}
		public float GetSet_ChromaInitializer__rgbUpdateRate(float? newValue = null)
		{
			FieldInfo field = typeof(Terraria.Initializers.ChromaInitializer).GetField("_rgbUpdateRate", BindingFlags.NonPublic | BindingFlags.Static);

			if (newValue != null)
			{
				field.SetValue(Main.instance, newValue);
			}

			return (float)field.GetValue(Main.instance);
		}

#pragma warning disable CA1822 // Mark members as static
// ModConfig elements cannot be static!

		[Header("UsuallyOnlyAvailableInGame")]
		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(DoorOpeningHelper.DoorAutoOpeningPreference.EnabledForEverything)]
		[DrawTicks]

		public DoorOpeningHelper.DoorAutoOpeningPreference SmartDoors
		{
			get => DoorOpeningHelper.PreferenceSettings;
			set => DoorOpeningHelper.PreferenceSettings = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(false)]
		public bool Autofire
		{
			get => Main.SettingsEnabled_AutoReuseAllItems;
			set => Main.SettingsEnabled_AutoReuseAllItems = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(100)]
		[Range(100, 200)]
		[Slider]
		public int Zoom
		{
			get => (int)(Main.GameZoomTarget * 100);
			set => Main.GameZoomTarget = (value / 100f);
		}
		
		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(100)]
		[Range(25, 200)]
		[Slider]
		public int UIScale
		{
			get
			{
				// return (int)(Main.UIScaleWanted * 100); // Main._uiScaleWanted
				return (int)(Main.temporaryGUIScaleSlider * 100);
			}
			set
			{
				Main.temporaryGUIScaleSlider = (value / 100f);
				//if (Main.mouseLeftRelease)
				//{
				//	Main.UIScale = (value / 100f);
				//}
			}
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(100)]
		[Range(10, 300)]
		[Slider]
		public int MapScale
		{
			get => (int)(Main.MapScale * 100);
			set => Main.MapScale = (value / 100f);
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool HoverTextBoxes
		{
			get => Main.SettingsEnabled_OpaqueBoxBehindTooltips;
			set => Main.SettingsEnabled_OpaqueBoxBehindTooltips = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool HeatDistortion
		{
			get => Main.UseHeatDistortion;
			set => Main.UseHeatDistortion = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool StormEffects
		{
			get => Main.UseStormEffects;
			set => Main.UseStormEffects = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(WavesQualitySettings.Off)]
		[DrawTicks]
		public WavesQualitySettings WavesQuality
		{
			get
			{
				return Main.WaveQuality switch
				{
					1 => WavesQualitySettings.Low,
					2 => WavesQualitySettings.Medium,
					3 => WavesQualitySettings.High,
					_ => WavesQualitySettings.Off,
				};
			}
			set
			{
				int newValue = (int)value;
				Math.Clamp(newValue, 0, 3);
				Main.WaveQuality = newValue;
			}
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(Player.Settings.HoverControlMode.Hold)]
		[DrawTicks]
		public Player.Settings.HoverControlMode HoverControls
		{
			get => Player.Settings.HoverControl;
			set => Player.Settings.HoverControl = value;
		}

		[Header("UsuallyOnlyAvailableOnMainMenu")]

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		//[DefaultValue(true)]
		public bool Map
		{
			get => Main.mapEnabled; 
			set => Main.mapEnabled = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(PasswordsSettings.Visible)]
		[DrawTicks]
		public PasswordsSettings Passwords
		{
			get
			{
				return Main.HidePassword switch
				{
					true => PasswordsSettings.Visible,
					false => PasswordsSettings.Hidden
				};
			}
			set
			{
				switch (value)
				{
					case PasswordsSettings.Visible:
						Main.HidePassword = true;
						break;
					case PasswordsSettings.Hidden:
						Main.HidePassword = false;
						break;
					default:
						break;
				}
			}
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(false)]
		public bool BorderlessWindow
		{
			get => Main.screenBorderless;
			set => Main.screenBorderless = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool MinersWobble
		{
			get => Main.SettingsEnabled_MinersWobble;
			set => Main.SettingsEnabled_MinersWobble = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(QuickTrashSettings.LeftControl)]
		[DrawTicks]
		public QuickTrashSettings QuickTrash
		{
			get
			{
				if (ItemSlot.Options.DisableQuickTrash)
				{
					return QuickTrashSettings.Disabled;
				}
				else if (ItemSlot.Options.DisableLeftShiftTrashCan)
				{
					return QuickTrashSettings.LeftControl;
				}
				else
				{
					return QuickTrashSettings.LeftShift;
				}
			}
			set
			{
				switch (value)
				{
					case QuickTrashSettings.LeftControl:
						ItemSlot.Options.DisableQuickTrash = false;
						ItemSlot.Options.DisableLeftShiftTrashCan = true;
						break;
					case QuickTrashSettings.LeftShift:
						ItemSlot.Options.DisableQuickTrash = false;
						ItemSlot.Options.DisableLeftShiftTrashCan = false;
						break;
					case QuickTrashSettings.Disabled:
						ItemSlot.Options.DisableQuickTrash = true;
						break;
					default:
						break;
				}
			}
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DrawTicks]
		public AttackSpeedEffectTooltipsSettings AttackSpeedEffectTooltips
		{
			get
			{
				return GetSet_ModLoader_attackSpeedScalingTooltipVisibility() switch
				{
					0 => AttackSpeedEffectTooltipsSettings.ShowAll,
					1 => AttackSpeedEffectTooltipsSettings.ShowAdjustedEffectiveness,
					2 => AttackSpeedEffectTooltipsSettings.Hidden,
					_ => AttackSpeedEffectTooltipsSettings.ShowAll
				};
			}
			set
			{
				switch (value)
				{
					case AttackSpeedEffectTooltipsSettings.ShowAll:
						GetSet_ModLoader_attackSpeedScalingTooltipVisibility(0);
						break;
					case AttackSpeedEffectTooltipsSettings.ShowAdjustedEffectiveness:
						GetSet_ModLoader_attackSpeedScalingTooltipVisibility(1);
						break;
					case AttackSpeedEffectTooltipsSettings.Hidden:
						GetSet_ModLoader_attackSpeedScalingTooltipVisibility(2);
						break;
					default:
						break;
				}
			}
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		public bool RemoveForcedMinimumZoom
		{
			get => GetSet_ModLoader_removeForcedMinimumZoom();
			set => GetSet_ModLoader_removeForcedMinimumZoom(value);
		}

		[Header("HiddenOptions")]

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[BackgroundColor(100, 100, 100)]
		[DefaultValue(false)]
		public bool UseExperimentalFeatures 
		{
			get => Main.UseExperimentalFeatures;
			set => Main.UseExperimentalFeatures = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(false)]
		public bool UseSmartCursorForCommonBlocks
		{
			get => Player.SmartCursorSettings.SmartBlocksEnabled;
			set => Player.SmartCursorSettings.SmartBlocksEnabled = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[BackgroundColor(100, 100, 100)]
		[DefaultValue(false)]
		public bool SettingsUnlock_WorldEvil
		{
			get => Main.SettingsUnlock_WorldEvil;
			set => Main.SettingsUnlock_WorldEvil = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(false)]
		public bool UnlockMusicSwap
		{
			get => GetSet_Main_TOWMusicUnlocked();
			set => GetSet_Main_TOWMusicUnlocked(value); 
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(300)]
		[Range(0, 1500)]
		[Increment(10)]
		//[Slider]
		public int MultiplayerNPCSmoothingRange
		{
			get => Main.multiplayerNPCSmoothingRange;
			set => Main.multiplayerNPCSmoothingRange = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(2000)]
		[Range(0, 10000)]
		[Increment(10)]
		//[Slider]
		public int TeamNameplateDistance
		{
			get => Main.teamNamePlateDistance;
			set => Main.teamNamePlateDistance = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(1000)]
		[Range(0, 10000)]
		[Increment(10)]
		//[Slider]
		public int WaterfallDrawLimit
		{
			get => Main.instance.waterfallManager.maxWaterfallCount;
			set => Main.instance.waterfallManager.maxWaterfallCount = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(false)]
		public bool DisableIntenseVisualEffects
		{
			get => Main.DisableIntenseVisualEffects;
			set => Main.DisableIntenseVisualEffects = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(false)]
		public bool SettingDontScaleMainMenuUp
		{
			get => Main.SettingDontScaleMainMenuUp;
			set => Main.SettingDontScaleMainMenuUp = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(16)]
		[Range(0, 32)]
		[Slider]
		public int FilterLimit
		{
			get => GetSet_FilterManager__filterLimit();
			set => GetSet_FilterManager__filterLimit(value);
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(EffectPriority.VeryLow)]
		[DrawTicks]
		public EffectPriority FilterPriorityThreshold
		{
			get => GetSet_FilterManager__priorityThreshold();
			set => GetSet_FilterManager__priorityThreshold(value);
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool Support4K
		{
			get => Main.Support4K;
			set => Main.Support4K = value;
		}
		
		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool Support8K // Setting added tModLoader
		{
			get => Main.Support8K;
			set => Main.Support8K = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(2)]
		public int WorldRollbacksToKeep
		{
			get => Main.WorldRollingBackupsCountToKeep;
			set => Main.WorldRollingBackupsCountToKeep = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(false)]
		public bool SettingBlockGamepadsEntirely
		{
			get => Main.SettingBlockGamepadsEntirely;
			set => Main.SettingBlockGamepadsEntirely = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue("LeftAlt")]
		public string KeyFavoriteModifier
		{
			get => Main.cFavoriteKey;
			set
			{
				Main.cFavoriteKey = value;
				if (Enum.TryParse<Microsoft.Xna.Framework.Input.Keys>(Main.cFavoriteKey, out var result2))
				{
					Main.FavoriteKey = result2;
				}
				Main.NewText($"Favorite Key now bound to {Main.FavoriteKey}");
			}
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(GameNotificationType.All)]
		[DrawTicks]
		public GameNotificationType FlashIconForEvents
		{
			get => GetSet_Main__flashNotificationType();
			set => GetSet_Main__flashNotificationType(value);
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(false)]
		public bool CloudSavingDefault
		{
			get => Terraria.Social.SocialAPI.Cloud.EnabledByDefault;
			set => Terraria.Social.SocialAPI.Cloud.EnabledByDefault = value;
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool ThrottleWhenInactive
		{
			get => Main.instance.InactiveSleepTime != TimeSpan.Zero;
			set => Main.instance.InactiveSleepTime = TimeSpan.FromMilliseconds(value ? 20 : 0);
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool UseRazerRGB
		{
			get => GetSet_ChromaInitializer__useRazer();
			set => GetSet_ChromaInitializer__useRazer(value);
		}
		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool UseCorsairRGB
		{
			get => GetSet_ChromaInitializer__useCorsair();
			set => GetSet_ChromaInitializer__useCorsair(value);
		}
		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool UseLogitechRGB
		{
			get => GetSet_ChromaInitializer__useLogitech();
			set => GetSet_ChromaInitializer__useLogitech(value);
		}
		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool UseSteelSeriesRGB
		{
			get => GetSet_ChromaInitializer__useSteelSeries();
			set => GetSet_ChromaInitializer__useSteelSeries(value);
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(45.0f)]
		[Range(0f, 120f)]
		[Increment(1f)]
		public float RGBUpdatesPerSecond
		{
			get => GetSet_ChromaInitializer__rgbUpdateRate();
			set => GetSet_ChromaInitializer__rgbUpdateRate(value);
		}

		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(false)]
		public bool QuickLaunch
		{
			get => Main.SkipAssemblyLoad;
			set => Main.SkipAssemblyLoad = value;
		}

#pragma warning restore CA1822 // Mark members as static

		/*
		public enum SmartDoorsSettings
		{ 
			Enabled,
			GamepadOnly,
			Disabled
		}
		*/

		public enum WavesQualitySettings
		{
			Off,
			Low,
			Medium,
			High
		}

		public enum PasswordsSettings
		{
			Visible,
			Hidden
		}

		public enum QuickTrashSettings
		{
			LeftControl,
			LeftShift,
			Disabled
		}
		public enum AttackSpeedEffectTooltipsSettings
		{
			ShowAll,
			ShowAdjustedEffectiveness,
			Hidden
		}
		/*
		public enum FilterPriorityThresholdSettings
		{
			VeryLow,
			Low,
			Medium,
			High,
			VeryHigh
		}
		public enum KeyFavoriteModifierSettings
		{
			LeftAlt,
			LeftShift,
			LeftControl,
			RightAlt,
			RightShift,
			RightControl,
			Other
		}

		public enum FlashIconForEventsSettings
		{
			Damage,
			SpawnOrDeath,
			WorldGen,
			All,
			None
		}
		*/
	}
}