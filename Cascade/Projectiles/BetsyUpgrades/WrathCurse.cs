using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.BetsyUpgrades
{
    public class WrathCurse : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon Fire");
        }
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = -1;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.alpha = 255;
            projectile.timeLeft = 10;
            projectile.height = 100;
            projectile.width = 100;
            aiType = ProjectileID.Bullet;
            projectile.extraUpdates = 1;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
		   projectile.velocity *= 0f;
		   target.AddBuff(BuffID.ShadowFlame, 240);
		   				                target.AddBuff(mod.BuffType("ShadowCurse"), 240, true);
        }
		
    }
}
