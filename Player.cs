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

        public override void Update(Camera camera)
        {
            //border
            if (texturePos.X <= 0)
            {
                texturePos.X = 0;
            }
            if (texturePos.X >= 4000)
            {
                texturePos.X = 4000;
            }
            if (texturePos.Y <= 0)
            {
                texturePos.Y = 0;
            }
            if (texturePos.Y >= 4000)
            {
                texturePos.Y = 4000;
            }

            //shooting and rotation
            mousePos = Mouse.GetState().Position.ToVector2();

            KeyboardState kstate = Keyboard.GetState();

            angle = (float)Math.Atan2(mousePos.Y - camera.Bounds.Height/2 , mousePos.X - camera.Bounds.Width/2);        //thank Bela, the god

            hitBox.Location = texturePos.ToPoint();

            Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));

           
            if (kstate.IsKeyDown(Keys.LeftShift) && kstate.IsKeyDown(Keys.W))
            {
                texturePos += direction * 3;
            }
            else if (kstate.IsKeyDown(Keys.W))
            {
                texturePos += direction * 2;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.Player, new Rectangle((int)texturePos.X, (int)texturePos.Y, 20, 20), null, Color.White, angle, new Vector2(Assets.Player.Width / 2,Assets.Player.Height / 2), SpriteEffects.None, 0);
        }
    }
}
