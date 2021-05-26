using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Template
{
    /// <summary>
    /// tar hand om fiendernas spawning
    /// </summary>
    class EnemySpawner
    {
        private List<Swarmer> swarmers = new List<Swarmer>();
        private List<Cannon> cannons = new List<Cannon>();

        private List<Bullet> bullets = new List<Bullet>();
        private Random rnd = new Random();

        private float time = 0;
        private int maxEnemies = 5;
        private float spawnInterval = 10;

        public EnemySpawner(List<Swarmer> swarmers, List<Cannon> cannons, List<Bullet> bullets1)
        {
            this.swarmers = swarmers;
            this.cannons = cannons;
            bullets = bullets1;
        }

        /// <summary>
        /// Searches for a postition between 0 and 4000 for x and y
        /// once a position wich satisfies DistanceFromPlayer() is found, an enemy is spawned.
        /// Stops spawning once enemies.Count equals maxEnemies.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            time += (float)Game1.Time.ElapsedGameTime.TotalSeconds;

            int x;
            int y;
            do
            {
                x = rnd.Next(0, 4000);      //x, y position för fiende, en av varje på samma (x, y)
                y = rnd.Next(0, 4000);
            } while (DistanceFromPlayer(x, y));

            if (swarmers.Count < maxEnemies)    //spawnar fiender av typen Swarmer, begränsas av EnemyLimit()
            {
                swarmers.Add(new Swarmer(Assets.Enemy, new Vector2(x, y), 0));
            }

            if (cannons.Count < maxEnemies)     //spawnar fiender av typen Cannon, begränsas av EnemyLimit()
            {
                cannons.Add(new Cannon(Assets.Enemy, new Vector2(x, y), 0, new WeaponHandler(bullets)));
            }

            EnemyLimit();
        }

        private bool DistanceFromPlayer(int x, int y)       //gränser för spawn -- Funkar konstigt?
        {
            return x >= Player.CurrentPlayerPos.X + 500 
                || x <= Player.CurrentPlayerPos.X - 500 
                && y >= Player.CurrentPlayerPos.Y + 500 
                || y <= Player.CurrentPlayerPos.Y - 500;
        }

        private void EnemyLimit()   //gräns för antal enemies
        {
            if (time > spawnInterval)
            {
                maxEnemies += 5;
                time -= spawnInterval;
                spawnInterval += 10;
            }
        }
    }
}
