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
    public class TileGritIce : Tile
    {


        public TileGritIce() : base()
        {

        }
        protected override void define()
        {
            TextureLocation = new Vector2(0, 0);     //change txture location here
            ID = 1;
        }
        public override void update(GameTime gt)
        {
        
        }
    
}
}
