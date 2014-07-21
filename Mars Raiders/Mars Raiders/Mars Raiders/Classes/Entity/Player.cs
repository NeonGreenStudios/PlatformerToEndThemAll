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
    public class Player : Entity
    {

        int direction = 0; //0 = down
                           //1 = left
                           //2 = right
                           //3 = up
        //1 = stationary, 0 and 2 = walking
        bool stationary = true;
        float TransitionTime = Tile.TileSideLengthInPixels * 10f;
        float elapsed;
        private Vector2 TargetPos;

          public Player()
            : base()
        {
            defineTexture();
        }

        protected override void defineTexture()
        {
            TextureLocation = new Vector2(0, 1);
            this.x = FrameSizeInPixels * 10;
            this.y = FrameSizeInPixels * 10;
        }

        public override void update(GameTime gt, Level level)
        {

            Frame.Y = direction;
            elapsed += (float)gt.ElapsedGameTime.TotalMilliseconds;

            if (stationary)
            {
                Frame.X = 1;
                if (Game1.IM["UP"].IsDown)
                {
                    stationary = false;
                    direction = 3;
                    TargetPos = new Vector2(x, y - Tile.TileSideLengthInPixels);
                }
                else if (Game1.IM["DOWN"].IsDown)
                {

                    stationary = false;
                    direction = 0;
                    TargetPos = new Vector2(x, y + Tile.TileSideLengthInPixels);
                }
                else if (Game1.IM["LEFT"].IsDown)
                {
                    stationary = false;
                    direction = 1;
                    TargetPos = new Vector2(x - Tile.TileSideLengthInPixels, y);
                }
                else if (Game1.IM["RIGHT"].IsDown)
                {
                    TargetPos = new Vector2(x + Tile.TileSideLengthInPixels, y);
                    stationary = false;
                    direction = 2;
                }
            }

            else  //if the player is transitioning
            {
         
        
                elapsed += (float)gt.ElapsedGameTime.TotalMilliseconds;
                long TimeBetweenPixels = (long)TransitionTime / Tile.TileSideLengthInPixels;
                if (elapsed >= TimeBetweenPixels)
                {
                    if (Frame.X == 0)
                    {
                        Frame.X = 2;
                    }
                    else
                    {
                        Frame.X = 0;
                    }

                    if (this.direction == 3)
                    {
                        this.y -= 1;
                    }
                    else if (direction == 0)
                    {
                        this.y += 1;
                    }
                    else if (direction == 1)
                    {
                        this.x -= 1;
                    }
                    else if (direction == 2)
                    {
                        this.x += 1;
                    }
                    if (new Vector2(x, y) == TargetPos) stationary = true;

                }
            }
        }
        }
        }
    

