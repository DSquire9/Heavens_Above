using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;

namespace Heavens_Above
{
	public class HeavensAbove : Mod
	{
        // Dev keys to be removed later
        public static ModKeybind EnterWorldKey;
        public static ModKeybind LeaveWorldKey;

        // Sets up default keybindings for dev keys
        public override void Load()
        {
            base.Load();
            EnterWorldKey = KeybindLoader.RegisterKeybind(this, "Enter SubWorld", Keys.OemPeriod);
            LeaveWorldKey = KeybindLoader.RegisterKeybind(this, "Leave SubWorld", Keys.OemComma);
        }

        public override void Unload()
        {
            base.Unload();
            EnterWorldKey = null;
            LeaveWorldKey = null;
        }
    }
}