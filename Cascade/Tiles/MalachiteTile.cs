using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Cascade.Tiles
{
    public class MalachiteTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSpelunker[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = false;  //true for block to emit light
            Main.tileLighted[Type] = false;
            drop = mod.ItemType("Malachite");   //put your CustomBlock name
			ModTranslation name = CreateMapEntryName();
            name.SetDefault("Malachite Ore");
            AddMapEntry(new Color(65, 200, 65), name);
			soundType = 21;
            minPick = 225;
            dustType = 110;
            
        }
		 public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            {
                r = 0.028f;
                g = 0.253f;
                b = 0.081f;
            }
        }
	
       
    }
}