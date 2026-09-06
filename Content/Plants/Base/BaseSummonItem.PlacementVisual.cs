using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlantsVS.Common;
using PlantsVS.Content.PVSystem;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace PlantsVS.Content.Plants.Base
{
	public abstract partial class BaseSummonItem
    {
        private sealed class PlacementVisual : ModSystem
        {
            private static readonly Asset<Texture2D> placementArea =
                ModContent.Request<Texture2D>("PlantsVS/Content/Plants/Base/PlantPlaceCheck");

            public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
            {
                int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Tile Grid Option"));
                if (mouseTextIndex == -1)
                {
                    return;
                }

                layers.Insert(
                    mouseTextIndex,
                    new LegacyGameInterfaceLayer(
                        $"{nameof(PlantsVS)}: {nameof(PlacementVisual)}",
                        () =>
                        {
                            if (Main.LocalPlayer.HeldItem.ModItem is BaseSummonItem && !Main.gamePaused)
                            {
                                DrawPlacementVisual(Main.spriteBatch);
                            }
                            return true;
                        },
                        InterfaceScaleType.None
                    )
                );

                return;

                static void DrawPlacementVisual(SpriteBatch sb)
                {
                    sb.End();
                    sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);
                    {
                        var drawPos = PlantsVSCommon.PlantPlacePositionWithoutScreen;
                        drawPos -= Main.screenPosition;
                        drawPos -= new Vector2(16);

                        var blink = (float)Math.Abs(Math.Sin(Main.timeForVisualEffects / 50));
                        var drawColor = Color.White * blink;

                        var source = new Rectangle(
                            0,
                            (int)(24 * (Math.Round(Main.timeForVisualEffects / 15) % 4)),
                            24,
                            24
                        );

                        sb.Draw(
                            placementArea.Value,
                            drawPos,
                            source,
                            drawColor,
                            0,
                            Vector2.Zero,
                            2f,
                            SpriteEffects.None,
                            0f
                        );
                    }
                    sb.End();
                    sb.Begin(); // Doesn't matter what's used here
                }
            }
        }
    }
}