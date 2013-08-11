using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameRandom
    {
        private static Random _random;

        public static Random GetRandom()
        {
            if(_random == null)
            {
                _random = new Random();
            }

            return _random;
        }
    }
}
