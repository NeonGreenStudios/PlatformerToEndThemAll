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
    public class Menu_HitBox
    {
        public Texture2D Texture2HIT;
        public Menu_Items MenuItem; 
        
        public Menu_HitBox(Texture2D texture2HIT, Menu_Items menuItem)
        {
            Texture2HIT = texture2HIT;
            MenuItem = menuItem;
        }
    }
}
