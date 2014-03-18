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
        public Texture2D Texture2HIT; //Stores the hit box texture
        public String Properties, Name; //The name of the position on the file//The information that pops up on the pop up display
        public Boolean Selected, PropertiesDisplay;//Whether the mouse is hovered over the RECTANGLE or not// Whether the pop up display is displaying or not
        public int ProgramPosition;
        public Rectangle Shape;
        public Byte ItemNumber; //The position that it will appear
        public Double TimeSelected, FirstSelected; //How long the mouse has been hovered over it// When it last hovered it
        public float XOffset, YGap, YOffset;

        public Menu_Items(String name, String properties, Byte itemNumber, int programPosition, Texture2D texture2HIT, ContentManager Content)
        {
            Name = name;
            Texture2HIT = texture2HIT;
            this.ProgramPosition = programPosition;
            Properties = properties;
            ItemNumber = itemNumber;
            TimeSelected = 0.0;
            XOffset = 10.0f;
            YOffset = 2.0f;
            YGap = 5.0f;
            Shape = new Rectangle(Convert.ToInt16(XOffset / 2), Convert.ToInt16(YOffset + ((YGap + Texture2HIT.Height) * this.ItemNumber) - Texture2HIT.Height), Texture2HIT.Width, Texture2HIT.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Selected == false)
            {
                spriteBatch.DrawString(Game1.Andy, this.Name, new Vector2(XOffset + Texture2HIT.Width, YOffset + ((YGap + Texture2HIT.Height) * this.ItemNumber) - Texture2HIT.Height), Color.White, 0.0f, new Vector2(0, 0), Game1.Scale, SpriteEffects.None, 0.0f);
                spriteBatch.Draw(Texture2HIT, new Rectangle(Convert.ToInt16(XOffset/2), Convert.ToInt16(YOffset + ((YGap + Texture2HIT.Height) * this.ItemNumber) - Texture2HIT.Height),Texture2HIT.Width, Texture2HIT.Height),Color.White);
            }
            else
            {
                spriteBatch.DrawString(Game1.Andy, this.Name, new Vector2(XOffset + Texture2HIT.Width, YOffset + ((YGap + Texture2HIT.Height) * this.ItemNumber) - Texture2HIT.Height), Color.Red, 0.0f, new Vector2(0, 0), Game1.Scale, SpriteEffects.None, 0.0f);
                spriteBatch.Draw(Texture2HIT, new Rectangle(Convert.ToInt16(XOffset / 2), Convert.ToInt16(YOffset + ((YGap + Texture2HIT.Height) * this.ItemNumber) - Texture2HIT.Height), Texture2HIT.Width, Texture2HIT.Height), Color.Red);
            }
            if (PropertiesDisplay == true)
            {
                Vector2 Temp = new Vector2(0,0);
                Temp = Functions.GetMouseCoords();
                Temp.Y -= 45;
                spriteBatch.DrawString(Game1.Background, this.Properties, Temp, Color.Black, 0.0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
                spriteBatch.DrawString(Game1.Andy, this.Properties, Temp, Color.White,0.0f,new Vector2(0,0),0.5f,SpriteEffects.None,0);
            }
        }

    }
}
