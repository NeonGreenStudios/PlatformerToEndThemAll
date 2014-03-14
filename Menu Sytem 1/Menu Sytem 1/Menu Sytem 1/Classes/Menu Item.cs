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

namespace Menu_Sytem_1
{
    public class Menu_Item
    {
        public static int X_OFFSET = 100;
        public static int Y_SPACE = 100;
        public static float MENU_SCALE = 1.0f;
        private String Name;
        public String ProgramPosition;
        private String Properties;
        public Boolean Selected;
        public Double TimeSelected, LastSelected;
        private Byte ItemNumber;
        public Rectangle Shape;
        public Boolean PropertiesDisplay;

        public Menu_Item(String N, String P, Byte IN, String PP, ContentManager C)
        {
     
            Name = N;
            ProgramPosition = PP;
            Properties = P;
            ItemNumber = IN;
            //Texture = C.Load<Texture2D>("Graphics/Menu/"+ Game1.ProgramPosition + "/" + Name);
       
           // EdgeBuffer = Texture.Height;
            TimeSelected = 0.0;
      
     
            Shape = new Rectangle(X_OFFSET,IN*Y_SPACE,1000,70);
        }

        public void Draw(SpriteBatch SB, int i)
        {
            i += 1;
            if (Selected == false)
            {
             //   SB.Draw(this.Texture, this.Shape, Color.White);

                SB.DrawString(Game1.Andy, this.Name, new Vector2(X_OFFSET * MENU_SCALE, i * Y_SPACE * MENU_SCALE), Color.White, 0f, new Vector2(X_OFFSET, i * Y_SPACE),MENU_SCALE,SpriteEffects.None,0);
            }
            else
            {
               // SB.Draw(this.Texture, this.Shape, Color.Red);
                SB.DrawString(Game1.Andy, this.Name, new Vector2(X_OFFSET * MENU_SCALE, i * Y_SPACE * MENU_SCALE), Color.Red, 0f, new Vector2(X_OFFSET, i * Y_SPACE), MENU_SCALE, SpriteEffects.None, 0);
            }
            if (PropertiesDisplay == true)
            {
                Vector2 Temp;
                Temp = Game1.Function.GetMouseCoords();
                Temp.Y -= 45;
                SB.DrawString(Game1.Background, this.Properties, Temp, Color.Black);
                SB.DrawString(Game1.Andy,this.Properties, Temp ,Color.White);
            }
        }
    }
}
