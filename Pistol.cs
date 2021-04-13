﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Template
{
    class Pistol : IShoot
    {
        private float coolDowm = 0.2f;
        private float timeLastShot = 0;
        List<Bullet> bullets;

        public Pistol(List<Bullet> bullets)
        {
            this.bullets = bullets;
        }
        public float CoolDown
        {
            get { return coolDowm; }
        }

        void IShoot.Shoot(Vector2 playerPos, float angle, Vector2 speed, Point size, Vector2 mousePos, DamageOrigin damageOrigin,Trigger trigger)
        {
            float timeShot = (float)Game1.Time.TotalGameTime.TotalSeconds;

            if ((timeShot - timeLastShot) >= coolDowm && trigger == Trigger.Pressed)
            {
                timeLastShot = timeShot;
                bullets.Add(new Bullet(Assets.BulletTexture, playerPos, angle, speed, size, mousePos, damageOrigin));
            }
        }
    }
}
