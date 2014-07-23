using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Mars_Raiders
{
    public class EntityCursor : Entity
    {

        private bool BrushToggle;
        private Tile BrushTile = new TileIce();

        public EntityCursor()
            : base()
        {
            defineTexture();
        }

        protected override void defineTexture()
        {
            TextureLocation = new Vector2(0, 0);
        }

        public override void update(GameTime gt, Level level)
        {
            KeyboardState ks = Keyboard.GetState();
            Vector2 MousePosition = Functions.GetMouseCoords();

            if (!level.Paused)
            {
                this.x = (int)(MousePosition.X) - Level.XOffset;
                this.y = (int)(MousePosition.Y) - Level.YOffset;

                 if (Game1.IM["Pause"].IsTapped)
                {
                    Game1.ProgramPosition = (int)ProgramPositions.MenuDeveloperInitiate;
                }
                if (Game1.IM["Raise"].IsTapped)
                {
                   // level.Map[Functions.toGridCoords(x), Functions.toGridCoords(y)].Raised = !level.Map[Functions.toGridCoords(x), Functions.toGridCoords(y)].Raised;
                    BrushToggle = !level.Map[Functions.toGridCoords(x), Functions.toGridCoords(y)].Raised;
                }
                if (Game1.IM["Raise"].IsDown)
                {
                    // level.Map[Functions.toGridCoords(x), Functions.toGridCoords(y)].Raised = !level.Map[Functions.toGridCoords(x), Functions.toGridCoords(y)].Raised;
                    level.Map[Functions.toGridCoords(x), Functions.toGridCoords(y)].Raised = BrushToggle ;
                }
              
                if (Game1.IM["ZoomOut"].IsTapped)
                {
                    Game1.Zoom -= 0.1f;
                }
                if (Game1.IM["ZoomIn"].IsTapped)
                {
                    Game1.Zoom += 0.1f;
                }
                if (Game1.IM["PlaceBlock1"].IsTapped)
                {
                    level.Map[Functions.toGridCoords(x), Functions.toGridCoords(y)] = new TileGritIce();
                }
                if (Game1.IM["PlaceBlock2"].IsTapped)
                {
                    level.Map[Functions.toGridCoords(x), Functions.toGridCoords(y)] = new TileIceRock();
                }
                if (Game1.IM["PlaceBlock3"].IsTapped)
                {
                     level.Map[Functions.toGridCoords(x), Functions.toGridCoords(y)] =  new TileStone();
                }
                if (Game1.IM["PlaceBlock4"].IsTapped)
                {
                    level.Map[Functions.toGridCoords(x), Functions.toGridCoords(y)] = new TileIce();
                }
                if (Game1.IM["Save"].IsTapped)
                {
                    level.save();  
                }
                if (Game1.IM["Load"].IsTapped)
                {
                    level.load();
                }

            }
        }
 
    }
}
