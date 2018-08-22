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

namespace Cascade.Projectiles.DungeonUpgrade
{
	public class ShadowProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Umbra Beam");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;

        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.penetrate = 10;
            projectile.tileCollide = true;
            projectile.alpha = 255;
            projectile.timeLeft = 500;
            projectile.light = 0;
            projectile.extraUpdates = 50;

        }
        public override void AI()
        {
            {
                for (int num447 = 0; num447 < 2; num447++)
                {
                    Vector2 vector33 = projectile.position;
                    vector33 -= projectile.velocity * ((float)num447 * 0.25f);
                    projectile.alpha = 255;
                    int num448 = Dust.NewDust(vector33, 1, 1, 173, 0f, 0f, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0.25f);
                    Main.dust[num448].noGravity = true;
                    Main.dust[num448].position = vector33;
                    Main.dust[num448].scale = (float)Main.rand.Next(70, 110) * 0.0183f;
                    Main.dust[num448].velocity *= 0.2f;
                }
                return;
            }
		
        }
		

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
		if(Main.rand.Next(2) == 0)
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
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("ShadowProj1"), projectile.damage, 2, projectile.owner);
                }
				}
		}
        
		 public override bool OnTileCollide(Vector2 oldVelocity)
	    {
		    projectile.penetrate--;
		    if (projectile.penetrate <= 0)
		    {
			    projectile.Kill();
		    }
       
		    if (projectile.velocity.X != oldVelocity.X)
		    {
			    projectile.velocity.X = -oldVelocity.X;
		    }
		    if (projectile.velocity.Y != oldVelocity.Y)
		    {
			    projectile.velocity.Y = -oldVelocity.Y * 1.3f;
		    }
		    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
		    return false;
	    }
}
}