using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class PowerUpSpawner
    {
        private List<WeaponPowerUp> weaponPowerUps = new List<WeaponPowerUp>();
        private Random rnd = new Random();

        private float time = 0;

        public PowerUpSpawner(List<WeaponPowerUp> weaponPowerUps)
        {
            this.weaponPowerUps = weaponPowerUps;
        }

        /// <summary>
        /// Searches for a postition between 0 and 4000 for x and y
        /// once a position wich satisfies DistanceFromPlayer() is found, a PowerUp is spawned.
        /// Stops spawning once powerUps.Count equals maxpowerUps.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            time += (float)Game1.Time.ElapsedGameTime.TotalSeconds;

            int x;
            int y;
            do
            {
                x = rnd.Next(0, 4000);
                y = rnd.Next(0, 4000);
            } while (DistanceFromPlayer(x, y));

            if (weaponPowerUps.Count < 20)
            {
                weaponPowerUps.Add(new WeaponPowerUp(Assets.PowerUp, new Vector2(x, y), 0));
            }
        }

        private bool DistanceFromPlayer(int x, int y)
        {
            return x >= Player.CurrentPlayerPos.X + 1000
                || x <= Player.CurrentPlayerPos.X - 1000
                && y >= Player.CurrentPlayerPos.Y + 1000
                || y <= Player.CurrentPlayerPos.Y - 1000;
        }
    }
}
