using PlantsVS.Content.Plants.Base;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace PlantsVS.Content.Plants
{

	public class Sunflower : GenericStemPlant
	{
        public override int SunCost => 50;

        public override void HeadDrawExtensions(ref DrawData HeadDrawData) {return;}

        public override void SetDefaults() {
            base.SetDefaults();
			Projectile.width = 24;
			Projectile.height = 24;
		}
    }


	public class SunflowerItem: BaseSummonItem
	{
		public override void SetDefaults() {
			base.SetDefaults();
			Item.shoot = ModContent.ProjectileType<Sunflower>();
		}
	}

}