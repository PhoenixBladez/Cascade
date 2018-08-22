using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.NatureFire
{
    public class WildfireProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wildfire Blaze");
        }
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
			projectile.melee = true;
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
                projectile.rotation += 0.2f;
                {
                    int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;
                    Main.dust[dust].scale = 1.3f;
					  int dust1 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    Main.dust[dust1].noGravity = true;
                    Main.dust[dust1].velocity *= 0f;
                    Main.dust[dust1].scale = 1.3f;
                }

            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
       {
            {
                target.AddBuff(BuffID.OnFire, 220, false);
            }
			              for (int i = 0; i < 6; ++i)
                    {
                        Vector2 targetDir = ((((float)Math.PI * 2) / 6) * i).ToRotationVector2();
                        targetDir.Normalize();
                        targetDir *= 3;
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 40, targetDir.X, targetDir.Y, mod.ProjectileType("HomingVine"), 35, 1f, projectile.owner, 0f, 0f);
                    }
        }
    }
}
