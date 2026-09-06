namespace PlantsVS.Content.Plants.Base
{
	public abstract partial class BasePeashooter : GenericStemPlant
	{
        public ref float ShootTimer => ref Projectile.ai[0];

        const int TargetingRange = 50 * 16;
        const int ShootFrequency = 60;
        const float FireVelocity = 6f;

        public override void AI()
        {
            base.AI();
			TargetLogic();
			ShootingLogic();
        }
    }
}