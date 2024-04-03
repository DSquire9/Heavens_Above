using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent;

namespace HeavensAbove.Content.Items
{
    public class AetheriumOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;

            // This ore can spawn in slime bodies like other pre-boss ores. (copper, tin, iron, etch)
            // It will drop in amount from 3 to 13.
            //ItemID.Sets.OreDropsFromSlime[Type] = (3, 13);
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.AetheriumOre>());
            Item.width = 12;
            Item.height = 12;
            Item.value = 3000;
        }
    }
}
