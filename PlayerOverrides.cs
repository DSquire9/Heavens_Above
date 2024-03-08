using SubworldLibrary;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace HeavensAbove
{
    class PlayerOverrides : ModPlayer
    {
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (HeavensAbove.EnterWorldKey.JustPressed)
            {
                SubworldSystem.Enter<HeavensAboveDimension>();
            }
            if (HeavensAbove.LeaveWorldKey.JustPressed)
            {
                SubworldSystem.Exit();

            }
        }

        public override void PostUpdate()
        {
            base.PostUpdate();
            // If the current subworld isnt active, return early
            if (SubworldSystem.Current == null)
                return;
            if(Player.Center.Y / 16 >= SubworldSystem.Current.Height-50 && SubworldSystem.Current.GetType() == typeof(HeavensAboveDimension))
            {
                SubworldSystem.Exit();
                //Player.KillMe(Terraria.DataStructures.PlayerDeathReason.ByCustomReason("Fell Through the World"),100000,1);
            }

        }
    }
}
