using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.Malachite
{
    public class MalachiteScythe : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Malachite Scythe");
        }
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = -1;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.alpha = 100;
            projectile.timeLeft = 300;
            projectile.height = 52;
            projectile.width = 52;
            aiType = ProjectileID.Bullet;
            projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            {
                projectile.rotation += 0.2f;
				projectile.velocity *= 0.98f;
                {
                    int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 110, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;
                    Main.dust[dust].scale = .9f;
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
            if (Main.rand.Next(7) == 0)
            {
                player.AddBuff(mod.BuffType("MalachiteBurst"), 220, false);
            }
			if (crit)
			{
				player.statLife += 2;
				player.HealEffect(2);
			}
        }
    }
}
