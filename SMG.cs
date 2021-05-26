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

        private float coolDowm = 0.2f;
        private float timeLastShot= 0;
        public GameTime gameTime;

        public SMG(List<Bullet> bullets)
        {
            this.bullets = bullets;
        }

        public float CoolDown
        {
            get { return coolDowm; }
        }

        /// <summary>
        /// shoot metod från IShoot
        /// som Pistol.cs men inte begränsad lika hårt av coolDown och kan även hållas nere och skjuta som skrivs i player.cs enligt trigger enum
        /// åker enl angivna parametrar
        /// begränsas av coolDown
        /// </summary>
        /// <param name="playerPos"></param>
        /// <param name="angle"></param>
        /// <param name="speed"></param>
        /// <param name="size"></param>
        /// <param name="mousePos"></param>
        /// <param name="damageOrigin"></param>
        /// <param name="trigger"></param>
        void IShoot.Shoot(Vector2 playerPos, float angle, Vector2 speed, Point size, Vector2 mousePos, DamageOrigin damageOrigin, Trigger trigger)
        {
            float timeShot = (float)Game1.Time.TotalGameTime.TotalSeconds;
            
            if((timeShot-timeLastShot)>= coolDowm)
            {
                timeLastShot = timeShot;
                bullets.Add(new Bullet(playerPos, angle, speed, size, mousePos, damageOrigin));
            }
        }
    }
}
