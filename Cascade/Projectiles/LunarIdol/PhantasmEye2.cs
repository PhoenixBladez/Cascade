using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.LunarIdol
{
    public class PhantasmEye2 : ModProjectile
    {
        int target;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantasm Bolt");

        }
        public override void SetDefaults()
            {
                projectile.width = 80;       //projectile width
                projectile.height = 80;  //projectile height
                projectile.friendly = true;      //make that the projectile will not damage you
                projectile.magic = true;         // 
                projectile.tileCollide = false;   //make that the projectile will be destroed if it hits the terrain
                projectile.penetrate = 1;      //how many npc will penetrate
                projectile.timeLeft = 20;
				projectile.alpha = 255;   //how many time projectile projectile has before disepire // projectile light
                projectile.extraUpdates = 1;
                projectile.ignoreWater = true;
                projectile.aiStyle = -1;

            }

         }
		 }