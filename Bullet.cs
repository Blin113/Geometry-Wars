﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class Bullet : BaseClass
    {
        private Vector2 speed;
        private Point size = new Point(4, 4);

        private DamageOrigin damageOrigin;

        public DamageOrigin GetDamageOrigin
        {
            get => damageOrigin;
            set => damageOrigin = value;
        }

        public Bullet(Texture2D texture, Vector2 texturePos, Vector2 speed, float angle, Point size, Vector2 mousePos, DamageOrigin damageOrigin) : base(texture, texturePos, angle, mousePos)
        {
            this.damageOrigin = damageOrigin;
            this.speed = speed;

            hitBox.Size = this.size;
        }

        public override void Update(Camera camera)
        {
            texturePos += new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 5;

            hitBox.Location = texturePos.ToPoint();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.BulletTexture, new Rectangle((int)texturePos.Y, (int)texturePos.Y, size.X, size.Y), null, Color.White, angle, new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)), SpriteEffects.None, 0);
        }
    }

    enum DamageOrigin
    {
        player,
        enemy
    }
}