using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.DungeonUpgrade
{
    public class MagnetHoming : ModProjectile
    {
        int target;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astral Bolt");

        }
        public override void SetDefaults()
            {
                projectile.width = 2;       //projectile width
                projectile.height = 2;  //projectile height
                projectile.friendly = true;      //make that the projectile will not damage you
                projectile.magic = true;         // 
                projectile.tileCollide = true;   //make that the projectile will be destroed if it hits the terrain
                projectile.penetrate = 1;      //how many npc will penetrate
                projectile.timeLeft = 300;   //how many time projectile projectile has before disepire // projectile light
                projectile.extraUpdates = 5;
				projectile.alpha = 255;
                projectile.ignoreWater = true;
                projectile.aiStyle = -1;

            }

            public override void AI()
			{
            bool flag25 = false;
            int jim = 1;
            for (int index1 = 0; index1 < 200; index1++)
            {
                if (Main.npc[index1].CanBeChasedBy(projectile, false) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[index1].Center, 1, 1))
                {
                    float num23 = Main.npc[index1].position.X + (float)(Main.npc[index1].width / 2);
                    float num24 = Main.npc[index1].position.Y + (float)(Main.npc[index1].height / 2);
                    float num25 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num23) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num24);
                    if (num25 < 500f)
                    {
                        flag25 = true;
                        jim = index1;
                    }

                }
            }
            if (flag25)
            {


                float num1 = 10f;
                Vector2 vector2 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num2 = Main.npc[jim].Center.X - vector2.X;
                float num3 = Main.npc[jim].Center.Y - vector2.Y;
                float num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                float num5 = num1 / num4;
                float num6 = num2 * num5;
                float num7 = num3 * num5;
                int num8 = 10;
                projectile.velocity.X = (projectile.velocity.X * (float)(num8 - 1) + num6) / (float)num8;
                projectile.velocity.Y = (projectile.velocity.Y * (float)(num8 - 1) + num7) / (float)num8;
            }
            {
                for (int num447 = 0; num447 < 2; num447++)
                {
                    Vector2 vector33 = projectile.position;

                    int num448 = Dust.NewDust(vector33, 1, 1, 267, 0f, 0f, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0.25f);
                    Main.dust[num448].noGravity = true;
                    Main.dust[num448].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                    Main.dust[num448].velocity *= 0.2f;
                }
                return;
            }
			}
        
       
            public override bool OnTileCollide(Vector2 oldVelocity)
            {
                return true;
            }
					
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			   if (Main.rand.Next(3) == 0)
            {
                target.AddBuff(mod.BuffType("PrismShatter1"), 300, true);
            }
		}
        }
    }
