using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Template
{
    class Pistol : IShoot
    {
        private float coolDown = 0.2f;
        private float timeLastShot = 0;
        List<Bullet> bullets;

        public Pistol(List<Bullet> bullets)
        {
            this.bullets = bullets;
        }
        public float CoolDown
        {
            get { return coolDown; }
        }

        /// <summary>
        /// shoot metod från IShoot
        /// vi lägger bara till ett skott som beter sig som i en vanlig pistol
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
        void IShoot.Shoot(Vector2 playerPos, float angle, Vector2 speed, Point size, Vector2 mousePos, DamageOrigin damageOrigin,Trigger trigger)
        {
            float timeShot = (float)Game1.Time.TotalGameTime.TotalSeconds;

            if ((timeShot - timeLastShot) >= coolDown && trigger == Trigger.Pressed)
            {
                timeLastShot = timeShot;
                bullets.Add(new Bullet(playerPos, angle, speed, size, mousePos, damageOrigin));
            }
        }
    }
}
