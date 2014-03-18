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
        int lastPressedTime;

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

            this.x = (int)(MousePosition.X / Tile.TileSideLengthInPixels / Game1.Scale / Game1.Zoom);
            this.y = (int)(MousePosition.Y / Tile.TileSideLengthInPixels / Game1.Scale / Game1.Zoom);
            
            if (KeyboardManager.isControlDown(Controls.SPACE, gt))
            {
                level.Map[x, y].Raised = !level.Map[x, y].Raised;
                lastPressedTime = gt.ElapsedGameTime.Milliseconds;
            }
            if (KeyboardManager.isControlDown(Controls.ZOOMOUT, gt))
            {
                Game1.Zoom -= 0.1f;
                lastPressedTime = gt.ElapsedGameTime.Milliseconds;
            }
            if (KeyboardManager.isControlDown(Controls.ZOOMIN, gt))
            {
                Game1.Zoom += 0.1f;
                lastPressedTime = gt.ElapsedGameTime.Milliseconds;
            }
            if (KeyboardManager.isControlDown(Controls.PLACEBLOCK1, gt))
            {
                level.Map[x, y] = new TileStone();
            }

            if (KeyboardManager.isControlDown(Controls.PLACEBLOCK2, gt))
            {
                level.Map[x, y] = new TileStone();
            }
            if (KeyboardManager.isControlDown(Controls.PLACEBLOCK3, gt))
            {
                level.Map[x, y] = new TileWater();
            }
            if (KeyboardManager.isControlDown(Controls.PLACEBLOCK4, gt))
            {
                level.Map[x, y] = new TileSand();
            }

            if (KeyboardManager.isControlDown(Controls.SAVE, gt))
            {
             level.save();
            }
            if (KeyboardManager.isControlDown(Controls.LOAD, gt))
            {
              level.load();
            }
        
        }
 
    }
}
