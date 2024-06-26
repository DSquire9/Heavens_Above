﻿using HeavensAbove.Content.Enemies;
using HeavensAbove.Content.NPCs;
using HeavensAbove.Content.Bosses;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace HeavensAbove.Content.Tiles
{
    public class SunSpiritAltar : ModTile
    {
        int npcIndex = -1;
        public override void SetStaticDefaults()
        {
            MinPick = 1000;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.AnchorBottom = new AnchorData(Terraria.Enums.AnchorType.SolidTile, 1, 0);
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
        }

        public override bool RightClick(int i, int j)
        {
            SpawnBoss(i,j);
            return true;
        }

        private void SpawnBoss(int i, int j)
        {
            npcIndex = NPC.NewNPC(Entity.GetSource_NaturalSpawn(), (int)i*16, (int)j*16, ModContent.NPCType<SunSpirit>());
            Main.npc[npcIndex].value = 0f;
            Main.npc[npcIndex].npcSlots = 0f;

            System.Console.WriteLine("NPC index: " + npcIndex);
        }
    }
}
