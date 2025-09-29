using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using HeavensAbove.Content.Items.Armor;

namespace HeavensAbove.Content.Items.Weapons
{
    class AetheriumBow : ModItem
    {
        public override void SetStaticDefaults() { }

        //https://terraria.fandom.com/wiki/Titanium_Repeater
        public override void SetDefaults() {
            Item.DefaultToBow(19,10.5f,true);

            Item.rare = ItemRarityID.LightRed;
            Item.damage = 48;
            Item.knockBack = 3;
            Item.crit = 6;
            Item.useTime = Item.useAnimation / 2;
            Item.consumeAmmoOnLastShotOnly = true;
            Item.reuseDelay = 16;
            Item.value = Item.buyPrice(gold: 2, silver: 80);
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<AetheriumBow>(), 1);

            recipe.AddIngredient<AetheriumBar>(13);

            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }

        public override Vector2? HoldoutOffset()
        {
            // TODO: Change for nonplaceholder Art
            return new Vector2(5f, 0);
        }
    }
}
