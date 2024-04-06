using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace HeavensAbove.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class AetheriumHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = true;
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; //???
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = false;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;


            Item.value = Item.buyPrice(gold: 3); // Change
            Item.rare = ItemRarityID.LightRed; // Change

            Item.defense = 15; // Change
        }

        public override void UpdateEquip(Player player)
        {
            // Give Buffs Here
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<AetheriumHelmet>(), 1);

            recipe.AddIngredient<AetheriumBar>(13);

            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<AetheriumBreastplate>() && legs.type == ModContent.ItemType<AetheriumGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Description of bonus";
            //  Add Set bonus here
        }
    }
}
