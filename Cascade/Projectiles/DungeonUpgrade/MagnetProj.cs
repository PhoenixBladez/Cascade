using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework;

namespace Cascade.Projectiles.DungeonUpgrade
{ 
    public class MagnetProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astral Portal");
			            Main.projFrames[projectile.type] = 5;

        }

        public override void SetDefaults()
        {
            projectile.hostile = false;
            projectile.magic = true;
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.alpha = 255;
            projectile.timeLeft = 600;
        }
  public override bool PreAI()
        {
            projectile.tileCollide = false;
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 107, 0f, 0f);
            Main.dust[dust].scale = 1.5f;
            Main.dust[dust].noGravity = true;

            int dust1 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 206, 0f, 0f);
            Main.dust[dust1].scale = 1.5f;
            Main.dust[dust1].noGravity = true;

            int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 244, 0f, 0f);
            Main.dust[dust2].scale = 1.5f;
            Main.dust[dust2].noGravity = true;
            return true;
        }
		int timer = 0;
        Vector2 offset = new Vector2(115, 115);
        public override void AI()
{
  
	 projectile.frameCounter++;
            if (projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                float num = 8000f;
                int num2 = -1;
                for (int i = 0; i < 200; i++)
                {
                    float num3 = Vector2.Distance(projectile.Center, Main.npc[i].Center);
                    if (num3 < num && num3 < 640f && Main.npc[i].CanBeChasedBy(projectile, false))
                    {
                        num2 = i;
                        num = num3;
                    }
                }
                if (num2 != -1)
                {
                    bool flag = Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num2].position, Main.npc[num2].width, Main.npc[num2].height);
                    if (flag)
                    {
                        Vector2 value = Main.npc[num2].Center - projectile.Center;
                        float num4 = 9f;
                        float num5 = (float)Math.Sqrt((double)(value.X * value.X + value.Y * value.Y));
                        if (num5 > num4)
                        {
                            num5 = num4 / num5;
                        }
                        value *= num5;
                        int p = Terraria.Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value.X, value.Y, mod.ProjectileType("MagnetHoming"), 100, 0f, projectile.owner, 0f, 0f);
                        Main.projectile[p].friendly = true;
                        Main.projectile[p].hostile = false;
                    }
                }
				 if (projectile.localAI[0] >= 10f)
            {
                projectile.localAI[0] = 0f;
                int num416 = 0;
                int num417 = 0;
                float num418 = 0f;
                int num419 = projectile.type;
                for (int num420 = 0; num420 < 1000; num420++)
                {
                    if (Main.projectile[num420].active && Main.projectile[num420].owner == projectile.owner && Main.projectile[num420].type == num419 && Main.projectile[num420].ai[1] < 3600f)
                    {
                        num416++;
                        if (Main.projectile[num420].ai[1] > num418)
                        {
                            num417 = num420;
                            num418 = Main.projectile[num420].ai[1];
                        }
                    }
                }
                if (num416 > 2)
                {
                    Main.projectile[num417].netUpdate = true;
                    Main.projectile[num417].ai[1] = 36000f;
                    return;
                }
            }
            }
}
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 110);
            }
        }
    }
}