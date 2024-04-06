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
using HeavensAbove.Content.Buffs;

namespace HeavensAbove.Content.Items.Weapons
{
    class AetheriumBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
           
        }
        //https://terraria.fandom.com/wiki/Titanium_Sword
        public override void SetDefaults()
        {
            Item.width = 40; // The item texture's width.
            Item.height = 40; // The item texture's height.

            Item.useStyle = ItemUseStyleID.Swing; // The useStyle of the Item.
            Item.useTime = 20; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
            Item.useAnimation = 20; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
            Item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button.

            Item.DamageType = DamageClass.Melee; // Whether your item is part of the melee class.
            Item.damage = 61; // The damage your item deals.
            Item.knockBack = 6; // The force of knockback of the weapon. Maximum is 20
            Item.crit = 6; // The critical strike chance the weapon has. The player, by default, has a 4% critical strike chance.

            Item.value = Item.buyPrice(gold: 3, silver: 22); // The value of the weapon in copper coins.
            Item.rare = ItemRarityID.LightRed;// Give this item our custom rarity.
            Item.UseSound = SoundID.Item1;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Random random = new Random();
            if (!target.boss && random.Next(10) == 9)
            {
                target.AddBuff(ModContent.BuffType<GoToSpace>(), 60 * 180);
            }
            
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<AetheriumBlade>(), 1);

            recipe.AddIngredient<AetheriumBar>(13);

            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }
    }
}
