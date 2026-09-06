using System;
using System.Collections.Generic;
using Daybreak.Common.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlantsVS.Content.Plants.Base;
using Terraria;
using Terraria.ModLoader;

namespace PlantsVS.Content.Plants.Nuts
{
	public class Wallnut : BasePlant
	{
        public override int SunCost => 30;
        public int Defense = 3;

        public override void SetDefaults() {
            base.SetDefaults();
			Projectile.width = 24;
			Projectile.height = 24;
		}

		private static readonly Rectangle BodySource = new(0, 0, 26, 29);
		private static readonly Rectangle LeftEyeSource = new(27, 0, 8, 8);
		private static readonly Rectangle RightEyeSource = new(35, 0, 5, 8);

		public override bool PreDraw(ref Color lightColor)
		{
			Main.spriteBatch.End(out var ss);
			
			using var lease = ScreenspaceTargetPool.Shared.Rent(Main.instance.GraphicsDevice);
			using (lease.Scope(clearColor: Color.Transparent))
			{
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, Main.Rasterizer);
				{
					Main.spriteBatch.Draw(RequestTexture, Vector2.Zero, BodySource, lightColor);
					Main.spriteBatch.Draw(RequestTexture, Vector2.Zero, LeftEyeSource, lightColor);
					Main.spriteBatch.Draw(RequestTexture, Vector2.Zero, RightEyeSource, lightColor);
				}
				Main.spriteBatch.End();
			}

			LeaseTexture = lease.Target;
			PreviousSpriteBatchSnapshot = ss;
			
			return base.PreDraw(ref lightColor);
		}
	}

	public class WallnutItem: BaseSummonItem
	{
		public override void SetDefaults() {
			base.SetDefaults();
			Item.shoot = ModContent.ProjectileType<Wallnut>();
		}
	}

}