using Microsoft.Xna.Framework;
using PlantsVS.Common;
using PlantsVS.Content.PVSystem;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlantsVS.Content.Plants.Base
{
	public abstract partial class BaseSummonItem : ModItem
	{
        public int SunCost;

		public override void SetStaticDefaults() {
			ItemID.Sets.GamepadWholeScreenUseRange[Type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Type] = true;
		}

		public override void SetDefaults() {
			Item.DamageType = ModContent.GetInstance<PlantClass>();
			Item.sentry = true;
			Item.scale = 2;
			Item.width = 25;
			Item.height = 25;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item83;
		}

		public static bool FindSpotToPlacePlant(int checkProj, out int worldX, out int worldY)
		{
			const int verticalFloorCheck = 3;

			Vector2 CheckPosition = PlantsVSCommon.PlantPlacePosition;
			int posX = (int)(CheckPosition.X / 16f);
			int posY = (int)(CheckPosition.Y / 16f);

			worldX = (int) PlantsVSCommon.PlantPlacePosition.X;
            worldY = (int) PlantsVSCommon.PlantPlacePosition.Y;

            // Check if the place is already occupied by other plant
            Rectangle CheckRect = new ((int)PlantsVSCommon.PlantPlacePositionWithoutScreen.X, (int)PlantsVSCommon.PlantPlacePositionWithoutScreen.Y, 22, 22);
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile proj = Main.projectile[i];
                if (!proj.active) continue;
                if (proj.ModProjectile is not BasePlant) continue;

                if (CheckRect.Intersects(proj.Hitbox))
                {
                    Rectangle WarnRect = new((int)CheckPosition.X, (int)CheckPosition.Y, 1, 1);
					CombatText.NewText(WarnRect, Color.Red, "Space is already occupied!", false, true);
                    return false;
                }
            }

            // Check if there's free place to place the plant
            for (int i = 0; i < 3; i++){
 			    for (int j = 0; j < 3; j++){
                    if (!(Main.tile[posX + i, posY + j] == null || !WorldGen.SolidTile2(posX + i, posY + j))){
                        Rectangle WarnRect = new((int)CheckPosition.X, (int)CheckPosition.Y, 1, 1);
					    CombatText.NewText(WarnRect, Color.Red, "No free place to place plant!", false, true);
                        return false;
                    }
				}
            }
                
			// Check if there's valid floor to place the plant
 			for (int i = 0; i < 3; i++){
				if (Main.tile[posX + i, posY + verticalFloorCheck] == null || !WorldGen.SolidTile2(posX + i, posY + verticalFloorCheck)){
					Rectangle WarnRect = new((int)CheckPosition.X, (int)CheckPosition.Y, 1, 1);
					CombatText.NewText(WarnRect, Color.Red, "Invalid floor to place plant!", false, true);
					return false;
				}
			}

			return true;
		}
    }
}