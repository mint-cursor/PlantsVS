using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PlantsVS.Content.Plants.Base
{
	abstract public partial class GenericStemPlant : BasePlant
	{
        public void StemDraw(out DrawData StemDrawData)
        {
            float StemRotation = (float)(Math.Sin(GlobalTimer * GeneralAnimSpeed) / 10f);
            StemDrawData = new()
            {
                texture = RequestTexture,
                position = BasePos,
                sourceRect = new(0, 30, 30, 30),
                color = Color.White,
                rotation = StemRotation,
                scale = new(2),
                origin = new(17,17),
            };
        }
    }
}