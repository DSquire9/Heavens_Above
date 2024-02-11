﻿using SubworldLibrary;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace Heavens_Above
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