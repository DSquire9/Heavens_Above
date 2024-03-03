using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace HeavensAbove.Content.Enemies
{
    public class Valkyrie : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Valkyrie");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            //NPC.width = 18;
            //NPC.height = 40;
            //NPC.damage = 14;
            //NPC.defense = 6;
            //NPC.lifeMax = 200;
            //NPC.HitSound = SoundID.NPCHit1;
            //NPC.DeathSound = SoundID.NPCDeath2;
            //NPC.value = 60f;
            //NPC.knockBackResist = 0.5f;
            //NPC.aiStyle = 3;
            //aiType = NPCID.Zombie;
            //animationType = NPCID.Zombie;
            //banner = Item.NPCtoBanner(NPCID.Zombie);
            //bannerItem = Item.BannerToItem(banner);
        }

        //public override float SpawnChance(NPCSpawnInfo spawnInfo)
        //{
        //    return SpawnCondition.OverworldNightMonster.Chance * 0.5f;
        //}

        //public override void HitEffect(int hitDirection, double damage)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        int dustType = Main.rand.Next(139, 143);
        //        int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
        //        Dust dust = Main.dust[dustIndex];
        //        dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
        //        dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
        //        dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
        //    }
        //}
    }
}
