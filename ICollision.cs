using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    interface ICollision
    {
        void Collision(Swarmer swarmer_Collider, Bullet bullet_Collider, WeaponPowerUp powerUp_Collider);       //metoden används för att kolla kollision mellan eller med givna objekt i parametern
    }
}
