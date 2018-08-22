using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.EventEffects
{
	public class Visual : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EventVisual1");
			            Main.projFrames[projectile.type] = 11;
		}
		public bool setSize = false;
		
		public override void SetDefaults()
		{
			projectile.width = 98;
			projectile.height = 98;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 3;
		    projectile.alpha = 75;
			projectile.timeLeft = 36;
			projectile.light = 0.5f;
			projectile.tileCollide = true;
		}
		public override void AI()
		{
		  Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.5f, 0.5f, 0.5f);
               
			projectile.frameCounter++;
			if (projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 11;
			} 
			if (!setSize)
			{
				setSize = true;
				projectile.scale *= (Main.rand.Next(1, 1));
			}
		}
		public override void Kill(int timeLeft)
		{
		                        for (int i = 0; i < 10; ++i)
								{
			   int dust5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 110);
                            Main.dust[dust5].noGravity = true;
							Main.dust[dust5].velocity *= 0f;
					       int dust6 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 206);
                                  Main.dust[dust6].noGravity = true;
							Main.dust[dust6].velocity *= 0f;
											  int dust7 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.GoldCoin);
                                                     Main.dust[dust7].noGravity = true;
							Main.dust[dust7].velocity *= 0f;
							}
		}
	}
}