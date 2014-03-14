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

namespace Tile_Based_Platformer_Test_2
{
    public class Tile
    {
        private String Raw_Data;
        public String[] Texture_Information;
        public Tile(String RD)
        {
            Raw_Data = RD;
            Texture_Information = Raw_Data.Split('/');
        }
    }
}
