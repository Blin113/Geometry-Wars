﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Enemies
{
    class BaseEnemy : BaseClass
    {
        private WeaponHandler weaponHandler;

        private Random rnd = new Random();

        private int speed;

        public BaseEnemy(Texture2D texture, Vector2 texturePos, float angle, WeaponHandler weaponHandler) : base(texture, texturePos, angle)
        {
            this.weaponHandler = weaponHandler;
            hitBox.Size = new Point(40, 40);
        }

        public override void Update(Camera camera)
        {
            angle = (float)Math.Atan2(texturePos.Y - Player.CurrentPlayerPos.Y, texturePos.X - Player.CurrentPlayerPos.X) + (float)(Math.PI);

            /*
            if (rnd.Next(0, 100) <= 1)
            {
                weaponHandler.Shoot(texturePos, angle, new Vector2(), new Point(), mousePos, DamageOrigin.enemy);
            }
            */

            hitBox.Location = texturePos.ToPoint();

            SearchAndDestroy();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.Player, new Rectangle((int)texturePos.X, (int)texturePos.Y, 20, 20), null, Color.White, angle, new Vector2(Assets.Player.Width / 2, Assets.Player.Height / 2), SpriteEffects.None, 0);
        }

        public void SearchAndDestroy()
        {
            Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            speed = 2;
            texturePos += direction * speed;
        }
    }
}