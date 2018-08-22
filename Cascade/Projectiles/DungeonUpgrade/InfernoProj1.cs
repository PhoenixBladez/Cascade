using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.DungeonUpgrade
{
    public class InfernoProj1 : ModProjectile
    {
        int target;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Inferno Bolt");

        }
        public override void SetDefaults()
            {
                projectile.width = 2;       //projectile width
                projectile.height = 2;  //projectile height
                projectile.friendly = true;      //make that the projectile will not damage you
                projectile.magic = true;         // 
                projectile.tileCollide = false;   //make that the projectile will be destroed if it hits the terrain
                projectile.penetrate = 1;      //how many npc will penetrate
                projectile.timeLeft = 300;   //how many time projectile projectile has before disepire // projectile light
                projectile.extraUpdates = 1;
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
                        if (num25 < 300f)
                        {
                            flag25 = true;
                            jim = index1;
                        }

                    }
                }
                if (flag25)
                {


                    float num1 = 20f;
                    Vector2 vector2 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                    float num2 = Main.npc[jim].Center.X - vector2.X;
                    float num3 = Main.npc[jim].Center.Y - vector2.Y;
                    float num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                    float num5 = num1 / num4;
                    float num6 = num2 * num5;
                    float num7 = num3 * num5;
                    int num8 = 30;
                    projectile.velocity.X = (projectile.velocity.X * (float)(num8 - 1) + num6) / (float)num8;
                    projectile.velocity.Y = (projectile.velocity.Y * (float)(num8 - 1) + num7) / (float)num8;
                }

           
            }
       
            public override bool OnTileCollide(Vector2 oldVelocity)
            {
                return true;
            }
		public override void Kill(int timeLeft)
		{
				 Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, 296, projectile.damage, 5, projectile.owner);
            

		}
        }
    }
