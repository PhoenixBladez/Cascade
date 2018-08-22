using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Cascade.Projectiles.LunarIdol
{
	public class PhantasmEye1 : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantasmal Eye");

        }
        public override void SetDefaults()
		{
			projectile.width = 58;
			projectile.height = 58;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 4;
			projectile.timeLeft = 3600;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override bool PreAI()
		{
			float num = 1f - (float)projectile.alpha / 255f;
			num *= projectile.scale;
			Lighting.AddLight(projectile.Center, 0.5f * num, 0.5f * num, 0.9f * num);
			
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] >= 90f)
			{
				projectile.localAI[0] *= -1f;
			}
			if (projectile.localAI[0] >= 0f)
			{
				projectile.scale += 0.003f;
			}
			else
			{
				projectile.scale -= 0.003f;
			}
			float num2 = 1f;
			float num3 = 1f;
			if (projectile.identity % 6 == 0)
			{
				num3 *= -1f;
			}
			if (projectile.identity % 6 == 1)
			{
				num2 *= -1f;
			}
			if (projectile.identity % 6 == 2)
			{
				num3 *= -1f;
				num2 *= -1f;
			}
			if (projectile.identity % 6 == 3)
			{
				num3 = 0f;
			}
			if (projectile.identity % 6 == 4)
			{
				num2 = 0f;
			}
			projectile.localAI[1] += 1f;
			if (projectile.localAI[1] > 60f)
			{
				projectile.localAI[1] = -180f;
			}
			if (projectile.localAI[1] >= -60f)
			{
				projectile.velocity.X = projectile.velocity.X + 0.002f * num3;
				projectile.velocity.Y = projectile.velocity.Y + 0.002f * num2;
			}
			else
			{
				projectile.velocity.X = projectile.velocity.X - 0.002f * num3;
				projectile.velocity.Y = projectile.velocity.Y - 0.002f * num2;
			}
			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 5400f)
			{
				projectile.damage = 0;
				projectile.ai[1] = 1f;
				if (projectile.alpha < 255)
				{
					projectile.alpha += 5;
					if (projectile.alpha > 255)
					{
						projectile.alpha = 255;
					}
				}
				else if (projectile.owner == Main.myPlayer)
				{
					projectile.Kill();
				}
			}
			else
			{
				float num4 = (projectile.Center - Main.player[projectile.owner].Center).Length() / 100f;
				if (num4 > 4f)
				{
					num4 *= 1.1f;
				}
				if (num4 > 5f)
				{
					num4 *= 1.2f;
				}
				if (num4 > 6f)
				{
					num4 *= 1.3f;
				}
				if (num4 > 7f)
				{
					num4 *= 1.4f;
				}
				if (num4 > 8f)
				{
					num4 *= 1.5f;
				}
				if (num4 > 9f)
				{
					num4 *= 1.6f;
				}
				if (num4 > 10f)
				{
					num4 *= 1.7f;
				}
				if (!Main.player[projectile.owner].GetModPlayer<MyPlayer>(mod).phantasmEye)
				{
					num4 += 100f;
				}
				projectile.ai[0] += num4;
				if (projectile.alpha > 50)
				{
					projectile.alpha -= 10;
					if (projectile.alpha < 50)
					{
						projectile.alpha = 50;
					}
				}
			}
			bool flag = false;
			Vector2 value = Vector2.Zero;
			float num5 = 280f;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].CanBeChasedBy(this, false))
				{
					float num6 = Main.npc[i].position.X + (float)(Main.npc[i].width / 2);
					float num7 = Main.npc[i].position.Y + (float)(Main.npc[i].height / 2);
					float num8 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num6) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num7);
					if (num8 < num5)
					{
						num5 = num8;
						value = Main.npc[i].Center;
						flag = true;
					}
				}
			}
			if (flag)
			{
				Vector2 vector = value - projectile.Center;
				vector.Normalize();
				vector *= 4.95f;
				projectile.velocity = (projectile.velocity * 10f + vector) / 11f;
				return false;
			}
			if ((double)projectile.velocity.Length() > 0.2)
			{
				projectile.velocity *= 0.98f;
			}
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.velocity *= 0f;
			projectile.alpha = 255;
			projectile.timeLeft = 20;
		}

		public override void Kill(int timeLeft)
	
        {
		   Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("PhantasmEye2"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
          
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 58;
            projectile.height = 58;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            for (int num621 = 0; num621 < 20; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 110, 0f, 0f, 100, default(Color), 1f);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num622].scale = 0.5f;
                    Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
        
            for (int num625 = 0; num625 < 3; num625++)
            {
                float scaleFactor10 = 0.33f;
                if (num625 == 1)
                {
                    scaleFactor10 = 0.66f;
                }
                if (num625 == 2)
                {
                    scaleFactor10 = 1f;
                }
                int num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num626].velocity *= scaleFactor10;
                Gore expr_13AB6_cp_0 = Main.gore[num626];
                expr_13AB6_cp_0.velocity.X = expr_13AB6_cp_0.velocity.X + 1f;
                Gore expr_13AD6_cp_0 = Main.gore[num626];
                expr_13AD6_cp_0.velocity.Y = expr_13AD6_cp_0.velocity.Y + 1f;
                num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num626].velocity *= scaleFactor10;
                Gore expr_13B79_cp_0 = Main.gore[num626];
                expr_13B79_cp_0.velocity.X = expr_13B79_cp_0.velocity.X - 1f;
                Gore expr_13B99_cp_0 = Main.gore[num626];
                expr_13B99_cp_0.velocity.Y = expr_13B99_cp_0.velocity.Y + 1f;
                num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num626].velocity *= scaleFactor10;
                Gore expr_13C3C_cp_0 = Main.gore[num626];
                expr_13C3C_cp_0.velocity.X = expr_13C3C_cp_0.velocity.X + 1f;
                Gore expr_13C5C_cp_0 = Main.gore[num626];
                expr_13C5C_cp_0.velocity.Y = expr_13C5C_cp_0.velocity.Y - 1f;
                num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num626].velocity *= scaleFactor10;
                Gore expr_13CFF_cp_0 = Main.gore[num626];
                expr_13CFF_cp_0.velocity.X = expr_13CFF_cp_0.velocity.X - 1f;
                Gore expr_13D1F_cp_0 = Main.gore[num626];
                expr_13D1F_cp_0.velocity.Y = expr_13D1F_cp_0.velocity.Y - 1f;
            }
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 10;
            projectile.height = 10;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
        }
		
	}
}
