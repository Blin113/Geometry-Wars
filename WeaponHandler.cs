using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
            shooting = new Pistol(bullets);
        }

        public void Update(Camera camera)
        {
            foreach (Bullet item in bullets)
            {
                item.Update(camera);
            }

            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Z))       //byter vapen beroende på vilken knapp som trycks
            {
                shooting = new Pistol(bullets);
            }
            if (kstate.IsKeyDown(Keys.X))
            {
                shooting = new Shotgun(bullets);
            }
            if (kstate.IsKeyDown(Keys.C))
            {
                shooting = new SMG(bullets);
            }
        }

        public void Shoot(Vector2 playerPos, float angle, Vector2 speed, Point size, Vector2 mousePos, DamageOrigin damageOrigin, Trigger trigger)
        {
            shooting.Shoot(playerPos, angle, speed, size, mousePos, damageOrigin, trigger);
        }
    }
}
