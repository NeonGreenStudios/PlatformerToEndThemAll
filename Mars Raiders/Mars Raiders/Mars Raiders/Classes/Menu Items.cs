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
        private String Properties,Name; //The name of the position on the file//The information that pops up on the pop up display
        private Boolean Selected, PropertiesDisplay;//Whether the mouse is hovered over the RECTANGLE or not// Whether the pop up display is displaying or not
        private Rectangle Shape;
        private Byte ItemNumber; //The position that it will appear
        private Double TimeSelected, LastSelected; //How long the mouse has been hovered over it// When it last hovered it

        public Rectangle GetShape
        {
            get { return Shape; }
        } //This is used to get the RECTANGLE information of the menu_item

    }
}
