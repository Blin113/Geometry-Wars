using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Player : BaseClass
    {
        public Player(Texture2D texture, Vector2 texturePos, float angle, Vector2 mousePos) : base(texture, texturePos, angle, mousePos)
        {
            hitBox.Size = new Point(20, 20);
        }

        public override void Update()
        {
            KeyboardState kstate = Keyboard.GetState();


            //player movement
            if (kstate.IsKeyDown(Keys.W))
            {
                texturePos.Y -= 2;
            }
            if (kstate.IsKeyDown(Keys.A))
            {
                texturePos.X -= 2;
            }
            if (kstate.IsKeyDown(Keys.S))
            {
                texturePos.Y += 2;
            }
            if (kstate.IsKeyDown(Keys.D))
            {
                texturePos.X += 2;
            }

            /*
            //border
            if (texturePos.X <= 20)
            {
                texturePos.X = 20;
            }
            if (texturePos.X >= 780)
            {
                texturePos.X = 780;
            }
            if (texturePos.Y <= 20)
            {
                texturePos.Y = 20;
            }
            if (texturePos.Y >= 460)
            {
                texturePos.Y = 460;
            }
            */

            //shooting and rotation
            mousePos = Mouse.GetState().Position.ToVector2();
            angle = (float)Math.Atan2(texturePos.Y - mousePos.Y, texturePos.X - mousePos.X) + (float)(Math.PI);
            hitBox.Location = texturePos.ToPoint();

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.Player, new Rectangle((int)texturePos.X, (int)texturePos.Y, 20, 20), null, Color.Green, angle, new Vector2(texture.Width / 2,texture.Height / 2), SpriteEffects.None, 0);
        }
    }
}
