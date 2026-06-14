using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace PlantsVS.Content.Plants.Base
{
	public abstract partial class BaseSummonItem : ModItem
	{
        private sealed class GlobalTilePlant : GlobalTile
        {
            public override bool CanPlace(int i, int j, int type)
            {
                Vector2 tileWorldPos = new (i * 16, j * 16);
                for (int p = 0; p < Main.maxProjectiles; p++)
                {
                    Projectile proj = Main.projectile[p];
                    if (!proj.active) continue;
                    if (proj.ModProjectile is not BasePlant) continue;

                    Rectangle ProjCheckReck = new((int)proj.position.X - 16, (int)proj.position.Y, proj.width, proj.height);
                    if (ProjCheckReck.Contains(tileWorldPos.ToPoint()))
                    {
                        return false;
                    }
                }
                return true;
            }

            public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
            {
                Vector2 tileWorldPos = new (i * 16, j * 16);
                for (int p = 0; p < Main.maxProjectiles; p++)
                {
                    Projectile proj = Main.projectile[p];

                    Rectangle ProjCheckReck = new((int)proj.position.X - 16, (int)proj.position.Y + 48, proj.width, proj.height / 3);

                    if (!proj.active) continue;
                    if (proj.ModProjectile is not BasePlant) continue;

                    if (ProjCheckReck.Contains(tileWorldPos.ToPoint()))
                    {
                        blockDamaged = true;
                        return false;
                    }
                }
                return true;
            }
        }
    }
}