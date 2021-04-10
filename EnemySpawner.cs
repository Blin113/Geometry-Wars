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
        //private float time = 5;
        //private float timer = 0;
        private Random rnd = new Random();

        public EnemySpawner(List<BaseEnemy> enemies, List<Bullet> bullets1)
        {
            this.enemies = enemies;
            bullets = bullets1;
        }

        public void Update(GameTime gameTime)
        {
            int x;
            int y;
            do
            {
                x = rnd.Next(0, 4000);
                y = rnd.Next(0, 4000);
                enemies.Add(new BaseEnemy(Assets.Player, new Vector2(x, y), 0, new WeaponHandler(bullets)));
            } while (enemies.Count < 1);
            
        }
    }
}
/*x != Player.CurrentPlayerPos.X + 500 || x != Player.CurrentPlayerPos.X - 500 && y != Player.CurrentPlayerPos.Y + 500 || y != Player.CurrentPlayerPos.Y - 500*/