using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static GameTime Time;

        //Menu
        private Menu menu = new Menu();

        //grid
        private Grid grid = new Grid();

        //Camera
        private Camera camera;

        //player
        private Player player;
        private Vector2 texturePos = new Vector2(2000, 2000);

        //Shooting
        private Point size;
        private Vector2 speed;
        private List<Bullet> bullets1 = new List<Bullet>(); 
        private WeaponHandler weaponHandler;

        //angle and mouse
        private float angle;
        private Vector2 mousePos;
        private Point cursorPos;

        
        //Enemy
        private List<BaseEnemy> enemies1 = new List<BaseEnemy>();
        private EnemySpawner enemySpawner;
        

        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            /*
            graphics.PreferredBackBufferWidth = 1990;
            graphics.PreferredBackBufferHeight = 1080;

            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            */
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            camera = new Camera(GraphicsDevice.Viewport);
            
            enemySpawner = new EnemySpawner(enemies1, bullets1);
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Assets.LoadAssets(Content, GraphicsDevice);

            player = new Player(Assets.Player, texturePos, angle, mousePos);

            // TODO: use this.Content to load your game content here 

            weaponHandler = new WeaponHandler(bullets1);
            player.SetWeaponHandler(weaponHandler);

            camera.SetTarget(player);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Time = gameTime;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mousePos = Mouse.GetState().Position.ToVector2();

            cursorPos = new Point((int)mousePos.X, (int)mousePos.Y);

            // If not in a menu, run game
            if (menu.CurrentMenu == CurrentMenu.None)
            {
                camera.UpdateCamera(GraphicsDevice.Viewport);

                weaponHandler.Update(camera);

                
                foreach (BaseEnemy item in enemies1)
                {
                    item.Update(camera);
                }
                
                enemySpawner.Update(gameTime);
                

                Collision();

                player.Update(camera);
            }
            menu.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here.
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.Transform);

            if (menu.CurrentMenu == CurrentMenu.None || menu.CurrentMenu == CurrentMenu.PauseMenu)
            {
                grid.Draw(spriteBatch, Assets.Pixel);

                foreach (Bullet item in bullets1)   //rita ut bullets
                {
                    item.Draw(spriteBatch);
                }

                foreach (BaseEnemy item in enemies1)        //rita ut fiender
                {
                    item.Draw(spriteBatch);
                }

                player.Draw(spriteBatch);
            }

            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            spriteBatch.Draw(Assets.Croshair, new Rectangle(cursorPos.X - 10, cursorPos.Y - 10, 20, 20), Color.White);

            menu.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Collision() 
        {
            for (int i = 0; i < bullets1.Count; i++)
            {
                if (bullets1[i].HitBox.X <= 0)
                {
                    bullets1.RemoveAt(i);
                    i--;
                }
                else if (bullets1[i].HitBox.X >= 4000)
                {
                    bullets1.RemoveAt(i);
                    i--;
                }
                else if (bullets1[i].HitBox.Y <= 0)
                {
                    bullets1.RemoveAt(i);
                    i--;
                }
                else if (bullets1[i].HitBox.Y >= 4000)
                {
                    bullets1.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < bullets1.Count; i++)
            {
                for (int j = 0; j < enemies1.Count; j++)
                {
                    if (bullets1[i].GetDamageOrigin == DamageOrigin.player && enemies1[j].HitBox.Intersects(bullets1[i].HitBox))
                    {
                        enemies1.RemoveAt(j);
                        bullets1.RemoveAt(i);

                        i--;
                        break;
                    }
                }
            }
        }
    }
}

/*
            for (int i = 0; i < enemies1.Count; i++)
            {
                if (enemies1[i].HitBox.Intersects(player.HitBox))
                {
                    CurrentMenu = CurrentMenu.DeathMenu;
                }
            }
*/
