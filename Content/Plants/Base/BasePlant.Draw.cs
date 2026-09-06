using System;
using System.Collections.Generic;
using Daybreak.Common.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;

namespace PlantsVS.Content.Plants.Base
{
	public abstract partial class BasePlant
	{

        // Drawing related variable and functions
        public Texture2D RequestTexture { get => TextureAssets.Projectile[Type].Value; }
        public float GeneralAnimSpeed = 3;
        public float GlobalTimeRandomOffset = Main.rand.Next(0, 200);
        public float GlobalTimer => Main.GlobalTimeWrappedHourly + GlobalTimeRandomOffset;

        public Vector2 BasePos =>
            Projectile.position - Main.screenPosition + 
            new Vector2(Projectile.width / 2, Projectile.height);

		// Base Predraw
		public Texture2D? LeaseTexture;
		public SpriteBatchSnapshot PreviousSpriteBatchSnapshot;
        public override bool PreDraw(ref Color lightColor)
        {
	        Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, Main.Rasterizer, null, Main.GameViewMatrix.TransformationMatrix);
	        Main.spriteBatch.Draw(
		        LeaseTexture, 
		        Projectile.Center - Main.screenPosition + new Vector2(0, 0), 
		        LeaseTexture.Frame(), 
		        Color.White, 
		        0, //(float) Math.Sin(Main.timeForVisualEffects / 10) / 2, 
		        new Vector2(15, 16), 
		        new Vector2(2, 2),
		        SpriteEffects.None, 
		        0f);
			
	        Main.spriteBatch.Restart(PreviousSpriteBatchSnapshot);
	        return false;
        }
        
    }
}