using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using HeavensAbove.Content.Items.Armor;

namespace HeavensAbove.Content.Items.Weapons
{
    class AetheriumBlade : ModItem
    {
        public override void SetStaticDefaults()
        {

        }
        //https://terraria.fandom.com/wiki/Titanium_Sword
        public override void SetDefaults() { }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<AetheriumBlade>(), 1);

            //recipe.AddIngredient<Aetherium>(13);

            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }
    }
}
