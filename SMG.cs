using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class SMG : IShoot
    {
        
        List<Bullet> bullets;

        private float coolDowm = 2;
        private float timer = 0;
        public GameTime gameTime;

        public SMG(List<Bullet> bullets)
        {
            this.bullets = bullets;
        }

        public float CoolDown
        {
            get { return coolDowm; }
        }

        void IShoot.Shoot(Vector2 playerPos, float angle, Vector2 speed, Point size, Vector2 mousePos, DamageOrigin damageOrigin)
        {
            /*
            gameTime = new GameTime();
            
            while (timer < coolDowm)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            bullets.Add(new Bullet(Assets.BulletTexture, playerPos, angle, speed, size, mousePos, damageOrigin));
            timer = 0;
            */
            
        }
    }
}
