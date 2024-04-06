using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HeavensAbove.Content.Buffs
{
    internal class GoToSpace : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Aqua Ring");
            //Description.SetDefault("Description of buff");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GravityMultiplier *= -1;
        }
    }
}
