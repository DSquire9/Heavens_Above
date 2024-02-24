using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HeavensAbove.Content.Buffs
{
    internal class AquaRing : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Aqua Ring");
            //Description.SetDefault("Description of buff");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // Add the actual buff here
        }
    }
}
