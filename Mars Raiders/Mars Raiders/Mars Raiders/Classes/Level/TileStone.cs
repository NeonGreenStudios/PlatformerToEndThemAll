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
    public class TileStone : Tile
    {


        public TileStone() : base()
        {

        }
        protected override void defineTexture()
        {
            TextureLocation = new Vector2(1, 0);     //change txture location here
        }
        public override void update(GameTime gt)
        {
        
        }
    
}
}
