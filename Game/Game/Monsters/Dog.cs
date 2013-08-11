using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Monsters
{
    class Dog : Monster
    {
        private const int DIRECTION_NO = 0;
        private const int DIRECTION_UP = 1;
        private const int DIRECTION_DOWN = 2;
        private const int DIRECTION_LEFT = 3;
        private const int DIRECTION_RIGHT = 4;

        private Random _random;
        private ConsoleColor _color;
        private int _direction;

        public Dog()
        {
            _random = GameRandom.GetRandom();

            switch (_random.Next(2))
            {
                case 0:
                    _color = ConsoleColor.DarkYellow;
                    break;
                case 1:
                    _color = ConsoleColor.Yellow;
                    break;
            }

            _direction = DIRECTION_NO;
        }

        public override char Face
        {
            get { return'@'; }
        }

        public override ConsoleColor Color
        {
            get { return _color; }
        }

        public override int MaxAge
        {
            get { return 50; }
        }

        protected override void OnRun()
        {
            if(_direction == DIRECTION_NO)
            {
                _direction = _random.Next(1, 5);
            }

            if(_random.Next(20) == 0)
            {
                _direction = DIRECTION_NO;
            }

            int x = X;
            int y = Y;

            switch (_direction)
            {
                case DIRECTION_UP:
                    y--;
                    break;
                case DIRECTION_DOWN:
                    y++;
                    break;
                case DIRECTION_LEFT:
                    x--;
                    break;
                case DIRECTION_RIGHT:
                    x++;
                    break;
            }

            if(!MoveTo(x, y))
            {
                _direction = DIRECTION_NO;
            }
        }
    }
}
