using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlantsVS.Content.Plants.Base;
using Terraria;
using Terraria.ModLoader;
using Daybreak.Common.Rendering;
using PlantsVS.Core;

namespace PlantsVS.Content.Plants
{
	public class Torchwood : BasePlant
	{
        public override int SunCost => 50;

        public override void SetDefaults() {
            base.SetDefaults();
			Projectile.width = 24;
			Projectile.height = 24;
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Main.spriteBatch.End(out var ss);
			Texture2D FireAura = Effects.FireAuraMask.Asset.Value;
			
			using var lease = ScreenspaceTargetPool.Shared.Rent(Main.instance.GraphicsDevice);
			using (lease.Scope(clearColor: Color.Transparent))
			{
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, Main.Rasterizer);
				{
					var FireAuraShader = Effects.FireAura.CreateFireAuraPass();
					var Noise = new HlslSampler {
						Texture = Effects.Noise1.Asset.Value
					};
					
					FireAuraShader.Parameters.uImage1 = Noise;
					FireAuraShader.Parameters.uTime = (float)Main.timeForVisualEffects / 100;
					FireAuraShader.Apply();
					Main.spriteBatch.Draw(FireAura, Vector2.Zero, lightColor);
				}
				Main.spriteBatch.End();
				
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, Main.Rasterizer);
				{
					Main.spriteBatch.Draw(RequestTexture, Vector2.Zero, lightColor);
				}
				Main.spriteBatch.End();
			}
			
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, Main.Rasterizer, null, Main.GameViewMatrix.TransformationMatrix);
			Main.spriteBatch.Draw(
				lease.Target, 
				Projectile.Center - Main.screenPosition + new Vector2(0, 24), 
				lease.Target.Frame(), 
				Color.White, 
				0, 
				new Vector2(28,64), 
				new Vector2(2, 1 + (float)Math.Sin(Main.timeForVisualEffects / 10) / 10),
				SpriteEffects.None, 
				0f);
			
			Main.spriteBatch.Restart(ss);
			Lighting.AddLight(Projectile.Center, new Vector3(1.5f,0.75f,0));
			
			return false;
		}
	}

	public class TorchwoodItem: BaseSummonItem
	{
		public override void SetDefaults() {
			base.SetDefaults();
			Item.shoot = ModContent.ProjectileType<Torchwood>();
		}
	}

}


// PlantsVSCommon.EnterShaderRegion(Main.spriteBatch);
// GameShaders.Misc["PlantsVS:FireAura"].Apply();
//
// Texture2D FireAura = ModContent.Request<Texture2D>("PlantsVS/Effects/FireAuraMask").Value;
// DrawData FlameDraw = new()
// {
// 	texture = FireAura,
// 	position = Vector2.Zero,
// 	sourceRect = FireAura.Bounds,
// 	color = Color.White,
// 	rotation = 0,
// 	scale = new(2),
// 	origin = new(27,63),
// };
// //Main.EntitySpriteDraw(FlameDraw);
// Main.spriteBatch.Draw(FireAura, FlameDraw.position, lightColor);
// PlantsVSCommon.ExitShaderRegion(Main.spriteBatch);
//
// DrawData BodyDraw = new()
// {
// 	texture = RequestTexture,
// 	position = Vector2.Zero,
// 	sourceRect = RequestTexture.Bounds,
// 	color = Color.White,
// 	rotation = 0,
// 	scale = new(2),
// 	origin = new(27,63),
// };
// //Main.EntitySpriteDraw(BodyDraw);
// Main.spriteBatch.Draw(RequestTexture, BodyDraw.position, lightColor);