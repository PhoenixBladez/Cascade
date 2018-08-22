using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.DungeonUpgrade
{
    public class ShadowProj1 : ModProjectile
    {
        int target;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Umbra Bolt");

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
                projectile.extraUpdates = 50;
				projectile.alpha = 255;
                projectile.ignoreWater = true;
                projectile.aiStyle = -1;

            }

            public override void AI()
            {
 projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 9f)
            {
                for (int num447 = 0; num447 < 2; num447++)
                {
                    Vector2 vector33 = projectile.position;
                    vector33 -= projectile.velocity * ((float)num447 * 0.25f);
                    projectile.alpha = 255;
                    int num448 = Dust.NewDust(vector33, 1, 1, 173, 0f, 0f, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0.25f);
                    Main.dust[num448].noGravity = true;
                    Main.dust[num448].position = vector33;
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
	
        }
    }
