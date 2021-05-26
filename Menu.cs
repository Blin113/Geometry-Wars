using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Template
{
    //menu
    enum CurrentMenu        //enum för att bestämma vilken menu vi är i
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

        CurrentMenu currentMenu = CurrentMenu.StartMenu;        //sättar första menyn till startmenu

        private Player player;

        public List<string> highscores = new List<string>();

        private bool saved = false;     //så att en oändlig loop av filhantering inte skapas.

        public Menu(Player player)
        {
            this.player = player;

            if (!File.Exists("scoreFile.txt"))      //om filen inte existerar skapar vi den.
            {
                File.Create("scoreFile.txt");
            }
        }

        public void Update()
        {
            switch (currentMenu)    //switch case för att köra metoderna för de olika enums av menuer
            {
                case CurrentMenu.StartMenu:
                    StartMenu();
                    break;

                case CurrentMenu.ColorMenu:
                    ColorMenu();
                    break;

                case CurrentMenu.PauseMenu:
                    PauseMenu();
                    break;

                case CurrentMenu.DeathMenu:
                    DeathMenu();
                    break;

                case CurrentMenu.None:
                    if(Keyboard.GetState().IsKeyDown(Keys.P))
                        currentMenu = CurrentMenu.PauseMenu;

                    if (player.IsDead())
                    {
                        currentMenu = CurrentMenu.DeathMenu;
                    }
                    break;

                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (currentMenu)        //samma som update() men vi ritar ut saker till menyn istället för att köra metoderna
            {
                case CurrentMenu.StartMenu:
                    spriteBatch.DrawString(Assets.MenuFont, "Press space to continue", new Vector2(250, 300), Color.Purple);
                    break;

                case CurrentMenu.ColorMenu:
                    spriteBatch.DrawString(Assets.MenuFont, "Press space to continue", new Vector2(250, 300), Color.Purple);
                    break;

                case CurrentMenu.PauseMenu:
                    spriteBatch.Draw(Assets.PauseScreen, new Rectangle(0, 0, 800, 480), new Color(Color.White, 1));
                    spriteBatch.DrawString(Assets.MenuFont, "Press space to continue", new Vector2(250, 300), Color.Purple);
                    break;

                case CurrentMenu.DeathMenu:
                    spriteBatch.DrawString(Assets.MenuFont, "your score is:" + Game1.HighScore.ToString(), new Vector2(100, 100), Color.Purple);

                    int y = 140;

                    spriteBatch.DrawString(Assets.MenuFont, "Highscores:", new Vector2(100, 140), Color.Purple);

                    for (int i = 0; i < highscores.Count; i++)      //skriv ut highscores lista
                    {
                        if (i > 4)
                        {
                            break;
                        }
                            
                        y += 40;
                        spriteBatch.DrawString(Assets.MenuFont, highscores[i], new Vector2(140, y), Color.Purple);
                    }

                    spriteBatch.DrawString(Assets.MenuFont, "Press ESCAPE to exit", new Vector2(250, 300), Color.Purple);
                    break;

                case CurrentMenu.None:
                    int Coordx = (int)player.Position.X;
                    int Coordy = (int)player.Position.Y;
                    //använder den generiska klassen Coordinates för att skapa en string array av spelarens position
                    string[] CC = Coordinates<string>.CreateCoordinatesArray(Coordx.ToString(), Coordy.ToString());

                    spriteBatch.DrawString(Assets.MenuFont, "(" + string.Join(" , ", CC) + ")", new Vector2(10, 440), Color.Purple);

                    break;

                default:
                    break;
            }
        }

        public void StartMenu()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                currentMenu = CurrentMenu.None;
        }

        public void ColorMenu()
        {
            //if (Keyboard.GetState().IsKeyDown(Keys.Space))
                currentMenu = CurrentMenu.None;
        }
        public void PauseMenu()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                currentMenu = CurrentMenu.None;

            //if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                //Exit
        }

        public void DeathMenu()
        {
            if (!saved)
            {
                string hscore = Game1.HighScore.ToString();     //kan inte ha int från början? många konvertioner

                highscores.Clear();

                List<int> tempHighscores = new List<int>();

                foreach (var line in File.ReadAllLines("scoreFile.txt"))    //läser från fil
                {
                    tempHighscores.Add(int.Parse(line));        //lägger in värden från fil i listan
                }

                tempHighscores.Add(Game1.HighScore);
                tempHighscores.Sort();
                tempHighscores.Reverse();

                highscores = tempHighscores.ConvertAll(x => x.ToString());

                File.WriteAllLines("scoreFile.txt", highscores); //omvandlar int listan till en string lista och sen skriver ut den till filen

                saved = true;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                //Game1.restart = true;
                currentMenu = CurrentMenu.StartMenu;
            }

            //ESC will exit regardless
        }

    }
}
///I den här klassen kollar vi vilken meny vi är i och vad som sak ske om vi är i den menyn
///
///Startmenu visar bara en text att du kan spela om du klickar mellanslag
///
///Colormenu är inte klar men bör vara till för att välja färg på spelaren
///
///Pausemenu är som startmenu men öppnas om du klickar P tangenten och stängs med mellanslag
///
///Deathmenu är inte heller klar men ska leda till en scoreboard och öppnas när man dör. Härifrån kan du spela om eller lämna.
/// 
///