﻿using HeavensAbove.Content.Buffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace HeavensAbove.Content.Items.Potions
{
    class AetherPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Set DisplayName
            // Set SetDefault
        }

        public override void SetDefaults()
        {
            Item.height = 34;
            Item.width = 30;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 50;
            Item.consumable = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(silver: 75); // Maybe Change
            Item.UseSound = SoundID.Item3;
            Item.buffType = ModContent.BuffType<AquaRing>();
            Item.buffTime = 60 * 240;
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<AetherPotion>(), 2);

            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient<AetherBloom>();
            recipe.AddIngredient<AetheriumOre>();

            recipe.AddTile(TileID.Bottles);

            recipe.Register();
        }
    }
}
