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
    public class Menu_Item
    {
        public Vector2 SourceRectangle;
        private Rectangle HitBox = new Rectangle(0, 0, 135, 135); //Stores the hit box texture
        private String Properties, Name; //The name of the position on the file//The information that pops up on the pop up display
        public Boolean Selected, PropertiesDisplay;//Whether the mouse is hovered over the RECTANGLE or not// Whether the pop up display is displaying or not
        public int ProgramPosition;
        public Rectangle Shape;
        public Byte ItemNumber; //The position that it will appear
        public Double TimeSelected, FirstSelected; //How long the mouse has been hovered over it// When it last hovered it
        private float XOffset, YGap, YOffset, Scale;

        public Menu_Item(String name, String properties, Byte itemNumber, int programPosition, float Scale, ContentManager Content)
        {
            Name = name;
            this.ProgramPosition = programPosition;
            Properties = properties;
            ItemNumber = itemNumber;
            TimeSelected = 0.0;
            XOffset = 10.0f;
            YOffset = 2.0f;
            YGap = 10f;
            this.Scale = Scale;
            HitBox = new Rectangle (HitBox.X,HitBox.Y , Convert.ToInt16 (HitBox.Width * Scale), Convert.ToInt16(HitBox.Height * Scale));
            Shape = new Rectangle(Convert.ToInt16((XOffset / 2)), Convert.ToInt16((YOffset + ((YGap + HitBox.Height) * this.ItemNumber)) - HitBox.Height), Convert.ToInt16(HitBox.Width * Scale), Convert.ToInt16(HitBox.Height * Scale));
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager CM)
        {
            spriteBatch.Draw(CM.Load<Texture2D>("Graphics/Menu Item/Sprite Sheet"), Shape, new Rectangle(Convert.ToInt16(this.SourceRectangle.X), Convert.ToInt16(this.SourceRectangle.Y), HitBox.Width, HitBox.Height ), Color.White);
            spriteBatch.DrawString(Game1.Andy, this.Name, new Vector2(XOffset + HitBox.Width, YOffset + ((YGap + HitBox.Height) * this.ItemNumber) - HitBox.Height), Color.Green, 0.0f, new Vector2(0, 0), Scale * Game1.Scale * 2, SpriteEffects.None, 0.0f);
            if (PropertiesDisplay == true)
            {
                Vector2 Temp = new Vector2(0, 0);
                Temp = Functions.GetMouseCoords();
                Temp.Y -= 45;
               // spriteBatch.DrawString(Game1.Background, this.Properties, Temp, Color.Black, 0.0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
                spriteBatch.DrawString(Game1.Andy, this.Properties, Temp, Color.Green, 0.0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
            }
        }

    }
}
