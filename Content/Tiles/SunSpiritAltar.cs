using HeavensAbove.Content.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace HeavensAbove.Content.Tiles
{
    public class SunSpiritAltar : ModTile
    {
        int npcIndex = -1;
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
            TileObjectData.addTile(Type);
        }

        public override bool RightClick(int i, int j)
        {
            SpawnBoss(i,j);
            return true;
        }

        private void SpawnBoss(int i, int j)
        {
            npcIndex = NPC.NewNPC(Entity.GetSource_NaturalSpawn(), (int)i*16, (int)j*16, ModContent.NPCType<QuestGuy>());
            Main.npc[npcIndex].value = 0f;
            Main.npc[npcIndex].npcSlots = 0f;

            System.Console.WriteLine("NPC index: " + npcIndex);
        }
    }
}
