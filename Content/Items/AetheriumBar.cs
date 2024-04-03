﻿using System;
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
    public class AetheriumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 59; // Influences the inventory sort order. 59 is PlatinumBar, higher is more valuable.

            // The Chlorophyte Extractinator can exchange items. Here we tell it to allow a one-way exchanging of 5 AetheriumBar for 2 ChlorophyteBar.
            ItemTrader.ChlorophyteExtractinator.AddOption_OneWay(Type, 5, ItemID.ChlorophyteBar, 2);
        }

        public override void SetDefaults()
        {
            // ModContent.TileType returns the ID of the tile that this item should place when used. ModContent.TileType<T>() method returns an integer ID of the tile provided to it through its generic type argument (the type in angle brackets)
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.AetheriumBar>());
            Item.width = 20;
            Item.height = 20;
            Item.value = 750; // The cost of the item in copper coins. (1 = 1 copper, 100 = 1 silver, 1000 = 1 gold, 10000 = 1 platinum)
        }

        
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<AetheriumOre>(4)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}