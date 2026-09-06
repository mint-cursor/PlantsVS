using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlantsVS.Common;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace PlantsVS.Content.Plants.Base
{
	abstract public partial class GenericStemPlant : BasePlant
	{
        public virtual void HeadDrawExtensions(ref DrawData HeadDrawData) {return;}

        public override bool PreDraw(ref Color lightColor)
        {
            StemDraw(out DrawData SteamDrawData);
            Main.EntitySpriteDraw(SteamDrawData);

            LeafDraw(out DrawData LeafDrawData);
            Main.EntitySpriteDraw(LeafDrawData);

            HeadDraw(out DrawData HeadDrawData);
            HeadDrawExtensions(ref HeadDrawData);
            Main.EntitySpriteDraw(HeadDrawData);
            
            return false;
        }
    }
}