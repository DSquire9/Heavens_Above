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
    class AetherWoodHelmet : ModItem
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


            Item.value = Item.buyPrice(copper: 1); // Change
            Item.rare = ItemRarityID.Gray; // Change

            Item.defense = 6; // Change
        }

        public override void UpdateEquip(Player player)
        {
            // Give Buffs Here
        }

        public override void AddRecipes()
        {

        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<AetherWoodBreastplate>() && legs.type == ModContent.ItemType<AetherWoodGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Description of bonus";
            //  Add Set bonus here
        }
    }
}
