using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Monsters
{
    class Hedgehog : Monster
    {
        private Random _random;

        public Hedgehog()
        {
            _random = GameRandom.GetRandom();
        }

        public override char Face
        {
            get { return '*'; }
        }

        public override ConsoleColor Color
        {
            get
            {
                if(Age < 15)
                {
                    return ConsoleColor.Green;
                }
                else if(Age < 45)
                {
                    return ConsoleColor.White;
                }
                else
                {
                    return ConsoleColor.Gray;
                }
            }
        }

        public override int MaxAge
        {
            get { return 60; }
        }

        protected override void OnRun()
        {
            int x = X;
            int y = Y;

            switch (_random.Next(4))
            {
                case 0:
                    x--; 
                    break;
                case 1:
                    x++; 
                    break;
                case 2:
                    y--; 
                    break;
                case 3:
                    y++; 
                    break;
            }

            MoveTo(x, y);
        }
    }
}
