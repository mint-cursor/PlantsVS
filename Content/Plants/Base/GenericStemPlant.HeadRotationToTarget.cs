using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;

namespace PlantsVS.Content.Plants.Base
{
	abstract public partial class GenericStemPlant : BasePlant
	{
        public void HeadRotationToTargetDraw(ref DrawData RotatedHeadDrawdata)
        {
            if (ProjTarget != null) {
                if ( ProjTarget.Center.X < Projectile.Center.X){
                    HeadEffect = SpriteEffects.FlipHorizontally;
                    HeadPos.X -= 9;
                    HeadOrigin.X = 17;
                }
                else
                {
                    HeadRotation -= 90 + 45;
                }
            
                HeadRotation += (float)Math.Atan2(Projectile.Center.Y - ProjTarget.Center.Y, Projectile.Center.X - ProjTarget.Center.X);
            }

            RotatedHeadDrawdata.effect = HeadEffect;
            RotatedHeadDrawdata.position.X = HeadPos.X;
            RotatedHeadDrawdata.origin.X = HeadOrigin.X;
            RotatedHeadDrawdata.rotation = HeadRotation;
        }
    }
}