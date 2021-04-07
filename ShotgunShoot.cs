using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class ShotgunShoot : IShoot
    {
        private float reloadTime = 1;
        List<Bullet> bullets;

        public ShotgunShoot(List<Bullet> bullets)
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
