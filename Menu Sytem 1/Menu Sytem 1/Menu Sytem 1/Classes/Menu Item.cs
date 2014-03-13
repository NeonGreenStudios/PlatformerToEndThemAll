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
        private String Name;
        public String ProgramPosition;
        private Int32 ItemGap, ItemHeight, EdgeBuffer;
        private String Properties;
        public Boolean Selected;
        public Double TimeSelected, LastSelected;
        private Texture2D Texture;
        private Byte ItemNumber;
        public Rectangle Shape;
        public Boolean PropertiesDisplay;

        public Menu_Item(String N, String P, Byte IN, String PP, ContentManager C)
        {
            ItemGap = 0;
            Name = N;
            ProgramPosition = PP;
            Properties = P;
            ItemNumber = IN;
            Texture = C.Load<Texture2D>("Graphics/Menu/"+ Game1.ProgramPosition + "/" + Name);
            ItemHeight = Texture.Height;
            EdgeBuffer = Texture.Height;
            TimeSelected = 0.0;
            int X = 0;
            X += ItemGap;
            X += ItemNumber * ItemHeight;
            Shape = new Rectangle(EdgeBuffer, X, Texture.Width, Texture.Height);
        }

        public void Draw(SpriteBatch SB)
        {
            if (Selected == false)
            {
                SB.Draw(this.Texture, this.Shape, Color.White);
            }
            else
            {
                SB.Draw(this.Texture, this.Shape, Color.Red);
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
