using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;

namespace PlantsVS.Content.Plants.Base
{
	abstract public partial class BasePeashooter : GenericStemPlant
	{
        public float SquishTimer = 0;
        const int SquishDuration = 40;

        public void ShootSquish(ref DrawData HeadSquishDrawdata)
        {
            if (SquishTimer < 0){ 
                return;
            }
            
            SquishTimer -= (float)(180 * Main.gameTimeCache.ElapsedGameTime.TotalSeconds);

            HeadSquishDrawdata.scale.Y -= SquishTimer / SquishDuration * 0.5f;
            HeadSquishDrawdata.scale.X += SquishTimer / SquishDuration * 0.2f;
        }
    }
}