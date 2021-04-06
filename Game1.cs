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

        //Menu
        private Menu menu = new Menu();

        //grid
        private Grid grid = new Grid();

        //Camera
        private Camera camera;

        //player
        private Player player;
        private Vector2 texturePos = new Vector2(1000, 1000);

        //Shooting
        private Point size;
        private Vector2 speed;
        private List<Bullet> bullets1 = new List<Bullet>(); 
        private WeaponHandler weaponHandler;

        //angle and mouse
        private float angle;
        private Vector2 mousePos;

        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1990;
            graphics.PreferredBackBufferHeight = 1080;

            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // If not in a menu, run game
            if(menu.CurrentMenu == CurrentMenu.None)
            {
                camera.UpdateCamera(GraphicsDevice.Viewport);

                weaponHandler.Update(camera);

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

            if(menu.CurrentMenu == CurrentMenu.None || menu.CurrentMenu == CurrentMenu.PauseMenu)
            {
                grid.Draw(spriteBatch, Assets.Pixel);

                foreach (Bullet item in bullets1)   //rita ut bullets
                {
                    item.Draw(spriteBatch);
                }

                player.Draw(spriteBatch);
            }

            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            menu.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
