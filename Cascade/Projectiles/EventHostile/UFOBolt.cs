using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.EventHostile
{
    public class UFOBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blaster Beam");
        }
        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = -1;
			projectile.tileCollide = false;
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
            projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
			    {

					
					   int dust1 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 206, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    Main.dust[dust1].noGravity = true;
                    Main.dust[dust1].velocity *= 0f;
                    Main.dust[dust1].scale = .9f;

                }

            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}