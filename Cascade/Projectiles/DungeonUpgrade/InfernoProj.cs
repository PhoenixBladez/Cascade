using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.DungeonUpgrade
{
    public class InfernoProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infernal Blaze");
        }
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
			projectile.magic = true;
			projectile.tileCollide = true;
			projectile.alpha = 100;
            projectile.timeLeft = 300;
            projectile.height = 22;
            projectile.width = 22;
            aiType = ProjectileID.Bullet;
            projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            {
              				 for (int index1 = 0; index1 < 5; ++index1)
                {
                    float num1 = projectile.velocity.X * 0.2f * (float)index1;
                    float num2 = (float)-((double)projectile.velocity.Y * 0.200000002980232) * (float)index1;
                    int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 1.3f);
                    Main.dust[index2].noGravity = true;
                    Main.dust[index2].velocity *= 0.0f;
                    Main.dust[index2].scale = 1.0f;
                    Main.dust[index2].position.X -= num1;
                    Main.dust[index2].position.Y -= num2;
                }

            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
		        Player player = Main.player[projectile.owner];
target.AddBuff(BuffID.OnFire, 1200);
     
			
        }
		public override void Kill(int timeLeft)
		{
			int n = 4;
                int deviation = Main.rand.Next(0, 300);
                for (int i = 0; i < n; i++)
                {
                    float rotation = MathHelper.ToRadians(270 / n * i + deviation);
                    Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(rotation);
                    perturbedSpeed.Normalize();
                    perturbedSpeed.X *= 5.5f;
                    perturbedSpeed.Y *= 5.5f;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("InfernoProj1"), 70, 2, projectile.owner);
                }
				 Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, 296, projectile.damage / 3 * 2, 5, projectile.owner);
            

		}
    }
}
