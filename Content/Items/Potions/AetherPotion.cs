using HeavensAbove.Content.Buffs;
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
            Item.rare = ItemRarityID.Gray; // Change
            Item.value = Item.buyPrice(silver: 75); // Maybe Change
            Item.UseSound = SoundID.Item3;
            Item.buffType = ModContent.BuffType<AquaRing>();
            Item.buffTime = 240;
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = Recipe.Create(ModContent.ItemType<AetherPotion>(), 4);

            recipe1.AddIngredient(ItemID.BottledWater);
            recipe1.AddIngredient<AetherBloom>();
            //recipe.AddIngredient<AetheriumOre>();

            recipe1.AddTile(TileID.Bottles);

            recipe1.Register();


            Recipe recipe2 = Recipe.Create(ModContent.ItemType<AetherPotion>(), 4);

            recipe2.AddIngredient(ItemID.BottledWater);
            recipe2.AddIngredient<AetherBloom>();
            //recipe.AddIngredient<AetheriumOre>();

            recipe2.AddTile(TileID.AlchemyTable);

            recipe2.Register();
        }
    }
}
