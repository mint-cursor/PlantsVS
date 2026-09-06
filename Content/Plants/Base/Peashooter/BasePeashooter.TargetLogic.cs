using Terraria;

namespace PlantsVS.Content.Plants.Base
{
	public abstract partial class BasePeashooter : GenericStemPlant
	{
        public void TargetLogic()
        {
            float closestTargetDistance = TargetingRange;
			NPC? targetNPC = null;

			if (Projectile.OwnerMinionAttackTargetNPC != null) {
				TryTargeting(Projectile.OwnerMinionAttackTargetNPC, ref closestTargetDistance, ref targetNPC);
			}

			if (targetNPC == null) {
				foreach (var npc in Main.ActiveNPCs) {
					TryTargeting(npc, ref closestTargetDistance, ref targetNPC);
				}
			}

            ProjTarget = targetNPC;
        }
    }
}