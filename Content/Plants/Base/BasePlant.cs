using Microsoft.Xna.Framework;
using PlantsVS.Content.Almanac;
using PlantsVS.Content.PVSystem;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace PlantsVS.Content.Plants.Base
{
	public abstract partial class BasePlant : ModProjectile
	{
        public override void OnKill(int timeLeft)
        {
	        Main.LocalPlayer.GetModPlayer<PlantPlayer>().CurrentSun += SunCost;
        }
        
        // Interaction with the cursor and stuff
        public override void PostDraw(Color lightColor)
        {
            if (Main.gamePaused) return;
            if (Projectile.Hitbox.Contains(Main.MouseWorld.ToPoint())) {

                Main.LocalPlayer.cursorItemIconEnabled = true;

                if (Main.LocalPlayer.HeldItem.ModItem is AlmanacBook)
                {
                    Main.LocalPlayer.cursorItemIconID = -1;
                    LocalizedText BaseText = Language.GetText("Mods.PlantsVS.Almanac.Base");

                    string? DamageText = null;
                    if (Projectile.damage > 0){
                        DamageText = "\n  Damage: " + Projectile.damage.ToString();
                    }

                    Main.LocalPlayer.cursorItemIconText = BaseText.Format([DisplayName, DamageText, ""]);
                    return;
                }

                Main.LocalPlayer.cursorItemIconID = ModContent.ItemType<PeashooterItem>();

                if (Main.mouseRight && Main.mouseRightRelease && Player.BlockInteractionWithProjectiles == 0) Projectile.Kill();
            }
        }

        // Boilerplate stuff
        public virtual int SunCost => 0;
        public override void SetDefaults() {
			Projectile.DamageType = ModContent.GetInstance<PlantClass>();
			Projectile.ignoreWater = true;
			Projectile.netImportant = true;
            Projectile.scale = 2f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity) => false;
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac) 
        {
            fallThrough = false; 
            return true;
        }

    }
}