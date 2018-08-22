using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.GunUpgrades
{
	public class SniperBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rainbow Bullet");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            aiType = ProjectileID.Bullet;
            projectile.alpha = 255;
			projectile.extraUpdates = 5;
			projectile.timeLeft = 1000;
            projectile.penetrate = 3;
            projectile.friendly = true;
            projectile.ranged = true; 

  
        }

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
			}
			return false;
		}
		
		
 public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			   if (Main.rand.Next(3) == 0)
            {
                target.AddBuff(mod.BuffType("PrismShatter1"), 300, true);
            }
		
					target.StrikeNPC(projectile.damage / 2, 0f, 0, crit);
								target.StrikeNPC(projectile.damage / 2, 0f, 0, crit);
		}
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
            {
                for (int i = 0; i < 10; i++)
                {
                    float x = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                    float y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
                    int num = Dust.NewDust(new Vector2(x, y), 26, 26, 206, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num].position.X = x;
                    Main.dust[num].position.Y = y;
                    Main.dust[num].velocity *= 0f;
                    Main.dust[num].noGravity = true;
					
					   int num1 = Dust.NewDust(new Vector2(x, y), 26, 26, 110, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num1].position.X = x;
                    Main.dust[num1].position.Y = y;
                    Main.dust[num1].velocity *= 0f;
                    Main.dust[num1].noGravity = true;
					
						   int num2 = Dust.NewDust(new Vector2(x, y), 26, 26, 244, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num2].position.X = x;
                    Main.dust[num2].position.Y = y;
                    Main.dust[num2].velocity *= 0f;
                    Main.dust[num2].noGravity = true;
                }
            }
        }

    }
}
