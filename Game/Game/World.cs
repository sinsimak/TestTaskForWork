using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class World
    {
        private List<Monster> _monsters;
        private int _sizeX;
        private int _sizeY;

        public World(int sizeX, int sizeY)
        {
            _monsters = new List<Monster>();
            _sizeX = sizeX;
            _sizeY = sizeY;
        }

        public int SizeX
        {
            get { return _sizeX; }
        }

        public int SizeY
        {
            get { return _sizeY; }
        }

        public List<Monster> GetMonsters()
        {
            return new List<Monster>(_monsters);
        }

        public void AddMonster(Monster monster)
        {
            _monsters.Add(monster);
        }

        public void RemoveMonster(Monster monster)
        {
            _monsters.Remove(monster);
        }

        public Monster GetMonster(int x, int y)
        {
            foreach (Monster monster in _monsters)
            {
                if(monster.X == x && monster.Y == y)
                {
                    return monster;
                }
            }
            return null;
        }
    }
}
