using SubworldLibrary;
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
    }
}
