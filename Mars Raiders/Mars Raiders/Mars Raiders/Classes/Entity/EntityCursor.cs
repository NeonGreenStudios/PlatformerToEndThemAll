using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

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

           
   

            
            if (ks.IsKeyDown(Keys.Up) &  y > 0)
            {
                y--;
                lastPressedTime = gt.ElapsedGameTime.Milliseconds;
            }
            if (ks.IsKeyDown(Keys.Down) & y < level.MapDimensions.Y)
            {
                y++;
                lastPressedTime = gt.ElapsedGameTime.Milliseconds;
            }
            if (ks.IsKeyDown(Keys.Right) & x < level.MapDimensions.X)
            {
                x++;
                lastPressedTime = gt.ElapsedGameTime.Milliseconds;
            }
            if (ks.IsKeyDown(Keys.Left) & x > 0)
            {
                x--;
                lastPressedTime = gt.ElapsedGameTime.Milliseconds;
            }
            if (ks.IsKeyDown(Keys.Space))
            {
                level.Map[x, y].Raised = !level.Map[x, y].Raised;
                lastPressedTime = gt.ElapsedGameTime.Milliseconds;
            }
            if (ks.IsKeyDown(Keys.Z))
            {
                Game1.Zoom -= 0.1f;
                lastPressedTime = gt.ElapsedGameTime.Milliseconds;
            }
            if (ks.IsKeyDown(Keys.X))
            {
                Game1.Zoom += 0.1f;
                lastPressedTime = gt.ElapsedGameTime.Milliseconds;
            }
            if (ks.IsKeyDown(Keys.D1))
            {
                level.Map[x, y] = new TileStone();
            }
        
        }
 
    }
}
