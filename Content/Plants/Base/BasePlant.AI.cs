using Microsoft.Xna.Framework;
using Terraria;

namespace PlantsVS.Content.Plants.Base
{
	public abstract partial class BasePlant
	{
        // Ai related variable and functions
        public NPC ProjTarget = null;

        protected bool JustSpawned {
			get => Projectile.localAI[0] == 0;
			set => Projectile.localAI[0] = value ? 0 : 1;
		}

		// Targeting logic
        protected void TryTargeting(NPC npc, ref float closestTargetDistance, ref NPC targetNPC) {
			if (npc.CanBeChasedBy(this)) {
				float distanceToTargetNPC = Vector2.Distance(Projectile.Center, npc.Center);
				if (distanceToTargetNPC < closestTargetDistance && Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height)) {
					closestTargetDistance = distanceToTargetNPC;
					targetNPC = npc;
				}
			}
		}
        
        public virtual void JustSpawnedExtensions() {return;}
        public override void AI()
        {
            if (JustSpawned) {
                JustSpawnedExtensions();
				JustSpawned = false;
            }
            
            // Make Projectile last forever
            Projectile.timeLeft += 2;

            // Gravity moment
            Projectile.velocity.X = 0f;
		    Projectile.velocity.Y += 0.2f;
		    if (Projectile.velocity.Y > 16f) { 
                Projectile.velocity.Y = 16f; 
            }
        }

    }
}