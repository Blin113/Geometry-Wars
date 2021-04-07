using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Template
{
    class WeaponHandler
    {
        List<Bullet> bullets = new List<Bullet>();
        IShoot shooting;

        public WeaponHandler(List<Bullet> bullets1)
        {
            bullets = bullets1;
            shooting = new PistolShoot(bullets);

        }

        public void Update(Camera camera)
        {
            foreach (Bullet item in bullets)
            {
                item.Update(camera);
            }
        }

        public void Shoot()
        {
            shooting.Shoot();
        }

        public void Swap()
        {
            shooting = new ShotgunShoot(bullets);
        }
    }
}
