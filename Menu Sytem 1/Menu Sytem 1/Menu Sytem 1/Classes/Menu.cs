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
    public class Menu
    {
        public Double VoidClick, LastVoidClick;
        public List<Menu_Item> MenuItems = new List<Menu_Item>();

        public void Contents(GameTime GT)
        {
            VoidClick = GT.TotalGameTime.TotalMilliseconds;
            Collision();
            PopUp_Display(GT);
            if (VoidClick - LastVoidClick >= 500)
            {
                Click();
            } 
        }

        private void Collision()
        {
            Vector2 Temp;
            Int16 X, Y;
            Temp = Game1.Function.GetMouseCoords();
            for (int I = 0; I <= MenuItems.Count - 1; I++)
            {
                X = Convert.ToInt16(Temp.X);
                Y = Convert.ToInt16(Temp.Y);
                MenuItems[I].Selected = Game1.Function.CollisionChecker(MenuItems[I].Shape, new Rectangle(X, Y, 1, 1));
            }
        }

        private void PopUp_Display(GameTime GT)
        {

            for (int I = 0; I <= MenuItems.Count - 1; I++)
            {
                if (MenuItems[I].Selected == true)
                {
                    MenuItems[I].TimeSelected = GT.TotalGameTime.TotalMilliseconds;
                }
                else
                {
                    MenuItems[I].TimeSelected = GT.TotalGameTime.TotalMilliseconds;
                    MenuItems[I].LastSelected = GT.TotalGameTime.TotalMilliseconds;
                }
                if (MenuItems[I].TimeSelected - MenuItems[I].LastSelected >= 500)
                {
                    MenuItems[I].PropertiesDisplay = true;
                }
                else
                {
                    MenuItems[I].PropertiesDisplay = false;
                    MenuItems[I].TimeSelected = MenuItems[I].LastSelected;
                }
            }
        }

        private void Click()
        {
            Boolean Click;
            Click = Game1.Function.MouseLeftClick();
            if (Click == true)
            {
                for (int I = 0; I <= MenuItems.Count - 1; I++)
                {
                    if (MenuItems[I].Selected == true)
                    {
                        Game1.ProgramPosition = MenuItems[I].ProgramPosition;
                    }
                }
            }
        }

        public void Draw(SpriteBatch SB)
        {
            for (int I = 0; I <= MenuItems.Count - 1; I++)
            {
                MenuItems[I].Draw(SB, I);
            }
        }
    }
}
