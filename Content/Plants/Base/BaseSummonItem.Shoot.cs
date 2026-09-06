using Microsoft.Xna.Framework;
using PlantsVS.Content.PVSystem;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlantsVS.Content.Plants.Base
{
	public abstract partial class BaseSummonItem
	{
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            // Check if you have enough sun remaning to spawn the plant
            BasePlant PlantToSummon = (BasePlant) ContentSamples.ProjectilesByType[type].ModProjectile;

            if(player.GetModPlayer<PlantPlayer>().CurrentSun < PlantToSummon.SunCost)
            {
                Main.NewText("Not enough sun!");
                return false;
            }

			Projectile ProjectileRef = ContentSamples.ProjectilesByType[type];

            if (!FindSpotToPlacePlant(type, out int worldX, out int worldY)) { 
				return false; 
			}

		    player.GetModPlayer<PlantPlayer>().CurrentSun -= PlantToSummon.SunCost;

			position = new Vector2(worldX + PlantToSummon.Projectile.width / 3, worldY + PlantToSummon.Projectile.height / 3 - 2);

			Projectile.NewProjectile(source, position, Vector2.Zero, type, damage, knockback, Main.myPlayer);

			for (int i = 0; i < 5; i++) 
			{ 
				int dust = Dust.NewDust(position, -ProjectileRef.width, ProjectileRef.height / 2, DustID.Dirt);
				Main.dust[dust].velocity.Y -= 1.2f;
			}

			return false;
		}
    }
}