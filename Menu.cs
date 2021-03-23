using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    //menu
    enum CurrentMenu
    {
        StartMenu,
        ColorMenu,
        PauseMenu,
        DeathMenu,
        None
    }

    class Menu
    {
        public CurrentMenu CurrentMenu { get { return currentMenu; } }

        CurrentMenu currentMenu = CurrentMenu.StartMenu;

        public Menu()
        {

        }

        public void Update()
        {
            if(currentMenu == CurrentMenu.StartMenu){
                StartMenu();
            }
            else if(currentMenu == CurrentMenu.ColorMenu)
            {

            }
            else if(currentMenu == CurrentMenu.PauseMenu)
            {

            }
            else if(currentMenu == CurrentMenu.DeathMenu)
            {

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentMenu == CurrentMenu.StartMenu)
            {
                spriteBatch.DrawString(Assets.MenuFont, "Press space to continue", new Vector2(400, 240), Color.Purple);
            }
        }

        public void StartMenu()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                currentMenu = CurrentMenu.None;
        }

        public void PauseMenu()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                currentMenu = CurrentMenu.None;
        }

    }
}
