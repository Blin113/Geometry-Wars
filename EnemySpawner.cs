using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Enemies
{
    class EnemySpawner
    {
        private List<BaseEnemy> enemies = new List<BaseEnemy>();
        private List<Bullet> bullets = new List<Bullet>();
        private Random rnd = new Random();

        private float time = 0;
        private int maxEnemies = 5;
        private const float spawnInterval = 10;

        public EnemySpawner(List<BaseEnemy> enemies, List<Bullet> bullets1)
        {
            this.enemies = enemies;
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
                x = rnd.Next(0, 4000);
                y = rnd.Next(0, 4000);
            } while (DistanceFromPlayer(x, y));

            if (enemies.Count < maxEnemies)
            {
                enemies.Add(new BaseEnemy(Assets.Player, new Vector2(x, y), 0, new WeaponHandler(bullets)));
            }

            EnemyLimit();
        }

        private bool DistanceFromPlayer(int x, int y)
        {
            return x >= Player.CurrentPlayerPos.X + 500 
                || x <= Player.CurrentPlayerPos.X - 500 
                && y >= Player.CurrentPlayerPos.Y + 500 
                || y <= Player.CurrentPlayerPos.Y - 500;
        }

        private void EnemyLimit()
        {
            if (time > spawnInterval)
            {
                maxEnemies += 5;
                time -= spawnInterval;
            }
        }
    }
}
