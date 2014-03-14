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
    public class Menu_Items
    {
        public String Properties, Name; //The name of the position on the file//The information that pops up on the pop up display
        public Boolean Selected, PropertiesDisplay;//Whether the mouse is hovered over the RECTANGLE or not// Whether the pop up display is displaying or not
        public int ProgramPosition;
        public Rectangle Shape;
        public Byte ItemNumber; //The position that it will appear
        public Double TimeSelected, FirstSelected; //How long the mouse has been hovered over it// When it last hovered it
        public float XOffset, YGap, YOffset;

        public Menu_Items(String name, String properties, Byte itemNumber, int programPosition, ContentManager Content)
        {
            Name = name;
            this.ProgramPosition = programPosition;
            Properties = properties;
            ItemNumber = itemNumber;
            TimeSelected = 0.0;
            XOffset = 10.0f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Selected == false)
            {
                spriteBatch.DrawString(Game1.Andy, this.Name, new Vector2(XOffset, YOffset + ((YGap + YOffset) * this.ItemNumber)), Color.White, 0.0f, new Vector2(0, 0), Game1.Scale, SpriteEffects.None, 0.0f);
            }
            else
            {
                spriteBatch.DrawString(Game1.Andy, this.Name, new Vector2(XOffset, YOffset + ((YGap + YOffset) * this.ItemNumber)), Color.Red, 0.0f, new Vector2(0, 0), Game1.Scale, SpriteEffects.None, 0.0f);
            }
            if (PropertiesDisplay == true)
            {
                Vector2 Temp = new Vector2(0,0);
                Temp = Game1.Function.GetMouseCoords();
                Temp.Y -= 45;
                spriteBatch.DrawString(Game1.Background, this.Properties, Temp, Color.Black);
                spriteBatch.DrawString(Game1.Andy, this.Properties, Temp, Color.White);
            }
        }

    }
}
