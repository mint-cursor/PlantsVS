using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlantsVS.Common;
using PlantsVS.Content.PVSystem;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlantsVS.Content.Almanac
{
	public partial class AlmanacBook : ModItem
	{
		public override void SetDefaults() {
            Item.rare = ItemRarityID.Blue;
			Item.width = 20;
			Item.height = 20;
			Item.scale = 2f;
		}

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            PlantsVSCommon.DrawInventoryCustomScale(
                spriteBatch,
                TextureAssets.Item[Type].Value,
                position,
                frame,
                drawColor,
                itemColor,
                origin,
                scale,
                wantedScale: 1f
            );
            return false;
        }
    }
}