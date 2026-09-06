using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PlantsVS.Content.Plants.Base
{
	public abstract partial class BasePeashooter : GenericStemPlant
	{
        public int SquishTimer = 0;
        const int SquishDuration = 40;

        public void ShootSquish(ref DrawData HeadSquishDrawdata)
        {
            if (SquishTimer < 0){ 
                return;
            }
            
            SquishTimer -= 1;
            
            HeadSquishDrawdata.scale.Y -= MathHelper.SmoothStep(0f, 0.2f, (float)SquishTimer / SquishDuration);
            HeadSquishDrawdata.scale.X += MathHelper.SmoothStep(0f, 0.5f, (float)SquishTimer / SquishDuration);
        }
    }
}