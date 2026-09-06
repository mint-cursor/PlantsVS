using PlantsVS.Content.Plants.Base;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using BasePeashooter = PlantsVS.Content.Plants.Base.BasePeashooter;

namespace PlantsVS.Content.Plants
{
	using BasePeashooter = global::PlantsVS.Content.Plants.Base.BasePeashooter;

	public class Peashooter : BasePeashooter
	{
        public override int SunCost => 25;

        public override void HeadDrawExtensions(ref DrawData HeadDrawData){
			HeadRotationToTargetDraw(ref HeadDrawData);
			ShootSquish(ref HeadDrawData);
        }

        public override void SetDefaults() {
            base.SetDefaults();
			Projectile.width = 24;
			Projectile.height = 24;
		}
    }


	public class PeashooterItem: BaseSummonItem
	{
		public override void SetDefaults() {
			base.SetDefaults();
			Item.damage = 2;
			Item.shoot = ModContent.ProjectileType<Peashooter>();
		}
	}

}