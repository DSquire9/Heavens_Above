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
    public class Zephyr : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Zephyr");
            Main.npcFrameCount[NPC.type] = 3;
        }

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 14;
            NPC.defense = 6;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 60f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = NPCID.Harpy;
            AIType = NPCID.Harpy;
            AnimationType = NPCID.Harpy;
            Banner = Item.NPCtoBanner(NPCID.Harpy);
            BannerItem = Item.BannerToItem(Banner);

            SpawnModBiomes = new int[1] { ModContent.GetInstance<HeavenBiome>().Type };
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return ModContent.GetInstance<HeavenBiome>().IsBiomeActive(spawnInfo.Player) ? 0 : 0;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            int buffType = BuffID.Slow;

            int timeToAdd = 3 * 60; //This makes it 3 seconds, one second is 60 ticks
            target.AddBuff(buffType, timeToAdd);
        }

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

