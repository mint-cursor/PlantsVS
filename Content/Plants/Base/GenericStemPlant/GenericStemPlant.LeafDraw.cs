using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PlantsVS.Content.Plants.Base
{
	abstract public partial class GenericStemPlant : BasePlant
	{
        public void LeafDraw(out DrawData LeafDrawData)
        {
            LeafDrawData = new()
            {
                texture = RequestTexture,
                position = BasePos,
                sourceRect = new(0, 60, 30, 30),
                color = Color.White,
                rotation = 0,
                scale = new(2),
                origin = new(17,17),
            };
        }
    }
}