using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;

namespace PlantsVS.Content.Plants.Base
{
	abstract public partial class GenericStemPlant : BasePlant
	{
        // Blinking stuff
        public float BlinkTimer;
        public int BlinkMaxTime => 200;
        public int BlinkWindow => BlinkMaxTime / 6;
        protected void ResetBlinking() => BlinkTimer = Main.rand.Next(BlinkMaxTime, (int)(BlinkMaxTime * 1.5));
        protected void BlinkingLogic()
        {
            if (BlinkTimer < 0) { ResetBlinking(); }
            BlinkTimer -= (float)(120 * Main.gameTimeCache.ElapsedGameTime.TotalSeconds);
        }

        // Head stuff
        public Vector2 HeadPos;
        public Vector2 HeadScale;
        public Vector2 HeadOrigin;
        public float HeadRotation;
        public SpriteEffects HeadEffect = SpriteEffects.None;

        public void HeadDraw(out DrawData HeadDrawdata)
        {
            BlinkingLogic();

            HeadPos = BasePos;
            HeadPos.Y -= 29;
            HeadPos.Y += (float)Math.Abs(Math.Sin(GlobalTimer * GeneralAnimSpeed / 2) * 3);
            HeadPos.X += (float)(Math.Sin(GlobalTimer * GeneralAnimSpeed) * 3);
            HeadPos.X -= 1;
            HeadScale = new (2);
            HeadOrigin = new (14,16);
            HeadRotation = (float)(Math.Cos(GlobalTimer * GeneralAnimSpeed / 2) / 15f);
            HeadEffect = SpriteEffects.None;

            // Define if plant should blink
            Rectangle HeadSourceRect = new(0, 0, 30, 30);
            if (BlinkTimer < BlinkWindow)
            {
                HeadSourceRect.Y = 90;
                HeadScale.Y = MathHelper.Lerp(2, 1.8f, 0f + BlinkTimer / BlinkWindow);
            }

            HeadDrawdata = new()
            {
                texture = RequestTexture,
                position = HeadPos,
                sourceRect = HeadSourceRect,
                color = Color.White,
                rotation = HeadRotation,
                scale = HeadScale,
                origin = HeadOrigin,
                effect = HeadEffect
            };
        }
    }
}