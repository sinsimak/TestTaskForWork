using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class Monster
    {
        private World _world;
        private int _x;
        private int _y;
        private int _age;
        private bool _isAlive;

        public Monster() {}

        public void BeBorn(World world, int x, int y)
        {
            _x = x;
            _y = y;
            _age = 0;
            _isAlive = true;
            _world = world;
            _world.AddMonster(this);
        }

        public void Die()
        {
            _isAlive = false;
            _world.RemoveMonster(this);
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public int Age
        {
            get { return _age; }
        }

        public bool IsAlive
        {
            get { return _isAlive; }
        }

        public void Run()
        {
            if(_age > MaxAge)
            {
                Die();
            }

            if(!_isAlive)
            {
                return;
            }

            _age++;

            OnRun();
        }

        public abstract char Face { get; }
        public abstract ConsoleColor Color { get; }
        public abstract int MaxAge { get; }
        
        protected virtual void OnRun() {}

        protected World World
        {
            get { return _world; }
        }

        protected bool MoveTo(int x, int y)
        {
            if(x < 0 || x >= World.SizeX || y < 0 || y >= World.SizeY)
            {
                return false;
            }

            _x = x;
            _y = y;
            return true;
        }


    }

}
