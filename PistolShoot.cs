using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Template
{
    class PistolShoot : IShoot
    {
        private float reloadTime = 0.5f;
        List<Bullet> bullets;

        public PistolShoot(List<Bullet> bullets)
        {
            this.bullets = bullets;
        }

        public float ReloadTime
        {
            get { return reloadTime; }
        }

        void IShoot.Shoot(Vector2 playerPos, float angle, Vector2 speed, Point size, Vector2 mousePos, DamageOrigin damageOrigin)
        {
            bullets.Add(new Bullet(Assets.BulletTexture, playerPos, speed, angle, size, mousePos, damageOrigin));
        }
    }
}
