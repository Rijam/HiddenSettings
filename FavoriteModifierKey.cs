using System.Collections.Generic;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.UI;

namespace HiddenSettings
{
	public class FavoriteModifierKey : ModSystem
	{
		/// <summary>
		/// The mod's Favorite Modifier mod key bind.
		/// </summary>
		public static ModKeybind FavoriteModifier { get; set; }

		public override void Load()
		{
			FavoriteModifier = KeybindLoader.RegisterKeybind(Mod, "FavoriteModifier", "LeftAlt"); // Create the mod key bind.
			Terraria.GameInput.On_PlayerInput.ListenFor += Hook_PlayerInput_ListenFor;
			Terraria.GameInput.On_PlayerInput.ResetKeyBinding += Hook_PlayerInput_ResetKeyBinding;
			Terraria.GameContent.UI.States.On_UIManageControls.CreatePanel += Hook_UIManageControls_CreatePanel;
		}
		public override void Unload()
		{
			FavoriteModifier = null;
		}

		/// <summary>
		/// Adds OnLeftClick delegates to the global reset, global clear, and FavoriteModifier reset buttons.
		/// </summary>
		/// <returns></returns>
		private UIElement Hook_UIManageControls_CreatePanel(Terraria.GameContent.UI.States.On_UIManageControls.orig_CreatePanel orig, Terraria.GameContent.UI.States.UIManageControls self, string bind, InputMode currentInputMode, Microsoft.Xna.Framework.Color color)
		{
			// Run orig to get the results of the UI elements.
			Terraria.UI.UIElement result = orig(self, bind, currentInputMode, color);

			// Reset and Clear buttons at the very bottom of the mod key binds list.
			if (bind == "ResetModKeybinds" || bind == "ClearModKeybinds")
			{
				// Add delegate to reset the key when reset or clear is pressed.
				result.OnLeftClick += delegate (UIMouseEvent evt, UIElement listeningElement)
				{
					HiddenSettingsConfig.SetFavoriteModifier("LeftAlt");
#if DEBUG
					ModContent.GetInstance<HiddenSettings>().Logger.Debug($"  Added delegate for the global reset or clear buttons.");
#endif
				};
			}
			// This mod's Favorite Modifier key bind.
			if (bind == "HiddenSettings/FavoriteModifier")
			{
				// Each mod key bind has two elements.
				// The left is the part that shows the current key and is UIKeybindingListItem type.
				// The right is the part that says "Reset to default ()" and is UIKeybindingSimpleListItem type.
				// This is found in UIManageControls.TML.cs
				foreach (UIElement child in result.Children)
				{
#if DEBUG
					ModContent.GetInstance<HiddenSettings>().Logger.Debug($"        Child {child}");
#endif
					if (child is UIKeybindingSimpleListItem right)
					{
						right.OnLeftClick += FavoriteModifierKeyResetButton;
						// Works, but thows the error "Delegates must be of the same type"
						// right.OnLeftClick += delegate (UIMouseEvent evt, UIElement listeningElement)
						// {
						//	HiddenSettingsConfig.SetFavoriteModifier("LeftAlt");
						//	ModContent.GetInstance<HiddenSettings>().Logger.Debug($"  Added delegate for the right side of the mod key bind.");
						// };
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Delegate for the "Reset to default ()" button of this mod's Favorite Modifier mod key bind.
		/// </summary>
		private void FavoriteModifierKeyResetButton(UIMouseEvent evt, UIElement listeningElement)
		{
			HiddenSettingsConfig.SetFavoriteModifier("LeftAlt");
#if DEBUG
			ModContent.GetInstance<HiddenSettings>().Logger.Debug($"  Added delegate for the right side of the mod key bind.");
#endif
		}

		/// <summary>
		/// This is only called by PlayerInput.FixDerpedRebinds() which is only called by PlayerInput.CheckRebindingProcessKeyboard() and PlayerInput.CheckRebindingProcessGamepad()
		/// The keyboard one is only called when pressing Left or Right Alt or not pressing Shift (on Steam) nor Tab?
		/// </summary>
		private void Hook_PlayerInput_ResetKeyBinding(Terraria.GameInput.On_PlayerInput.orig_ResetKeyBinding orig, InputMode inputMode, string trigger)
		{
			if (trigger == "HiddenSettings/FavoriteModifier")
			{
				HiddenSettingsConfig.SetFavoriteModifier("LeftAlt");
			}
			orig(inputMode, trigger);
		}

		/// <summary>
		/// Sets the favorite modifier key to what the player set the mod's Favorite Modifier mod key bind.
		/// </summary>
		private void Hook_PlayerInput_ListenFor(Terraria.GameInput.On_PlayerInput.orig_ListenFor orig, string triggerName, InputMode inputmode)
		{
#if DEBUG
			ModContent.GetInstance<HiddenSettings>().Logger.Debug($"ListenFor triggername is {triggerName}; inputmode {inputmode}; ListeningTrigger {Terraria.GameInput.PlayerInput.ListeningTrigger}");
#endif
			if (PlayerInput.ListeningTrigger == "HiddenSettings/FavoriteModifier") // Current key that the key binding system is listening for.
			{
				List<string> keyStatus = PlayerInput.CurrentProfile.InputModes[inputmode].KeyStatus[PlayerInput.ListeningTrigger]; // Get the current status of the key.
#if DEBUG
				foreach (string key in keyStatus)
				{
					ModContent.GetInstance<HiddenSettings>().Logger.Debug($"ListenFor keystatus is {key}");
				}
#endif
				HiddenSettingsConfig.SetFavoriteModifier(keyStatus[0]?? "LeftAlt"); // If for some reason the status isn't set, set it to LeftAlt.
			}
			orig(triggerName, inputmode); // Calling orig after (instead of before) is important somehow.
		}
	}
}
