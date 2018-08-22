using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.Malachite
{
	public class MalachiteBeam1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Malacite Beam");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;

        }
        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.alpha = 255;
            projectile.timeLeft = 500;
            projectile.light = 0;
            projectile.extraUpdates = 50;

        }
        public override void AI()
        {
            projectile.localAI[0] += 1f;
            {
                for (int num447 = 0; num447 < 2; num447++)
                {
                    Vector2 vector33 = projectile.position;
                    vector33 -= projectile.velocity * ((float)num447 * 0.25f);
                    projectile.alpha = 255;
                    int num448 = Dust.NewDust(vector33, 1, 1, 110, 0f, 0f, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0.25f);
                    Main.dust[num448].noGravity = true;
                    Main.dust[num448].position = vector33;
                    Main.dust[num448].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                    Main.dust[num448].velocity *= 0.2f;
                }
                return;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			 projectile.frameCounter++;
            if (projectile.frameCounter >= 1)
			{
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
                        int p = Terraria.Projectile.NewProjectile(target.Center.X, target.Center.Y, value.X, value.Y, mod.ProjectileType("MalachiteBeam2"), 70, 0f, projectile.owner, 0f, 0f);
                        Main.projectile[p].friendly = true;
                        Main.projectile[p].hostile = false;
                    }
                }
				}
		}
 
        
        
		}
		}