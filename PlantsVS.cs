using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlantsVS
{
	public class PlantsVS : Mod
	{
		public PlantsVS() {
			MusicAutoloadingEnabled = false;
		}

		public override void Load()
		{
			if (Main.netMode != NetmodeID.Server) {
				Asset<Texture2D> Noise1 = Assets.Request<Texture2D>("Effects/Noise1", AssetRequestMode.ImmediateLoad);

				Asset<Effect> testShader = Assets.Request<Effect>("Effects/TestShader", AssetRequestMode.ImmediateLoad);
				GameShaders.Misc["PlantsVS:TestShader"] = new MiscShaderData(testShader, "TestShaderPass");
				GameShaders.Misc["PlantsVS:TestShader"].UseImage1(Noise1);

				Asset<Effect> fireAuraShader = Assets.Request<Effect>("Effects/FireAura", AssetRequestMode.ImmediateLoad);
				GameShaders.Misc["PlantsVS:FireAura"] = new MiscShaderData(fireAuraShader, "FireAuraPass");
				GameShaders.Misc["PlantsVS:FireAura"].UseImage1(Noise1);
				GameShaders.Misc["PlantsVS:FireAura"].UseSamplerState(SamplerState.PointWrap);
			}
		}
	}
}
