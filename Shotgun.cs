using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Shotgun : IShoot
    {
        private float reloadTime = 1;
        List<Bullet> bullets;
        float spread = 0;


        Random random = new Random();

        public Shotgun(List<Bullet> bullets)
        {
            this.bullets = bullets;
        }

        public float ReloadTime
        {
            get { return reloadTime; }
        }

        void IShoot.Shoot(Vector2 playerPos, float angle, Vector2 speed, Point size, Vector2 mousePos, DamageOrigin damageOrigin)
        {
            for(int i = 0; i < 6; i++)
            {
                float originalAngle = angle;

                spread = random.Next(-5, 5);        //make this a float value
                spread /= 10;                       //divide by 10 for float value
                angle = angle + spread;

                bullets.Add(new Bullet(Assets.BulletTexture, playerPos, angle, speed, size, mousePos, damageOrigin));

                angle = originalAngle;
            }
        }
    }
}
