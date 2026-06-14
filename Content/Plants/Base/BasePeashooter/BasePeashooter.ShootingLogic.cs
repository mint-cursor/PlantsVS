using System;
using Microsoft.Xna.Framework;
using PlantsVS.Content.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlantsVS.Content.Plants.Base
{
	abstract public partial class BasePeashooter : GenericStemPlant
	{
        public void ShootingLogic()
        {
            if (ProjTarget != null) {
				if (ShootTimer <= 0) {
					ShootTimer = ShootFrequency;

					SoundEngine.PlaySound(SoundID.Item102 with { Volume = 0.4f }, Projectile.Center);

					if (Main.myPlayer == Projectile.owner) {
						Vector2 shootDirection = (ProjTarget.Center - Projectile.Center).SafeNormalize(Vector2.UnitX);
						Vector2 shootVelocity = shootDirection * FireVelocity;

						int type = ModContent.ProjectileType<CommonPea>();;
                        Vector2 shootPos = new(Projectile.Center.X, Projectile.Center.Y + 2);
                        shootPos += shootDirection * 35;

						Projectile.NewProjectile(Projectile.GetSource_FromThis(), shootPos, shootVelocity, type, Projectile.damage, 3, Projectile.owner);
                        SquishTimer = SquishDuration;
                        BlinkTimer = BlinkWindow;
					}
				}
			}

            ShootTimer--;
        }
    }
}