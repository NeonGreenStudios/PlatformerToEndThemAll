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
        float FrameDelay = 600f;
        float elapsed;

          public Player()
            : base()
        {
            defineTexture();
        }

        protected override void defineTexture()
        {
            TextureLocation = new Vector2(0, 1);
            this.x = 10;
            this.y = 10;
        }

        public override void update(GameTime gt, Level level)
        {

            Frame.Y = direction;
            elapsed += (float)gt.ElapsedGameTime.TotalMilliseconds;

            if (elapsed >= FrameDelay)
            {

       
                if (Frame.X < 2)
                {
                    Frame.X++;
                }
                else
                {
                    Frame.X = 0;
                }
                elapsed = 0;
            }
        }
        }
        }
    

