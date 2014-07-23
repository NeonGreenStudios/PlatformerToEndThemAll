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
    public class TileExteriorPanel : Tile
    {


        public TileExteriorPanel() : base()
        {

        }
        protected override void define()
        {
            TextureLocation = new Vector2(2, 0);     //change txture location here
            ID = 4;
        }
        public override void update(GameTime gt)
        {
        
        }
    
}
}
