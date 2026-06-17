using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace PlantsVS.Common
{
    public static class PlantsVSCommon
    {
		public static Vector2 PlantPlacePosition
        { 
            get => new Vector2(Player.tileTargetX, Player.tileTargetY) * 16f - new Vector2(6);
        }

        public static Vector2 PlantPlacePositionWithoutScreen
        { 
            get => new Vector2(Player.tileTargetX, Player.tileTargetY) * 16f;
        }

        public static void EnterShaderRegion(this SpriteBatch spriteBatch, BlendState newBlendState = null, Effect effect = null, Matrix? matrix = null)
        {
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, newBlendState ?? BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, effect, matrix ?? Main.GameViewMatrix.TransformationMatrix);
        }

        public static void ExitShaderRegion(this SpriteBatch spriteBatch, Matrix? matrix = null)
        {
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, matrix ?? Main.GameViewMatrix.TransformationMatrix);
        }

        public static void DrawInventoryCustomScale(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale, float wantedScale = 1f, Vector2 drawOffset = default, SpriteEffects spriteEffects = SpriteEffects.None, float rotation = 0f)
        {
            wantedScale = System.Math.Max(scale, wantedScale * Main.inventoryScale);
            float scaleDifference = wantedScale - scale;
            position += drawOffset * wantedScale;
            if (itemColor == Color.Transparent) itemColor = Color.White;
            spriteBatch.Draw(texture, position, frame, itemColor.MultiplyRGB(drawColor), 0f, origin, wantedScale, SpriteEffects.None, 0);
        }

    }
}
