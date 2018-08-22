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
	public class MalachiteBeam2 : ModProjectile
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
		
 
        
        
		}
		}