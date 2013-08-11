using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    class GameEngine
    {
        private World _world;
        private Random _random;

        public GameEngine()
        {
            _world = new World(78, 23);
            _random = GameRandom.GetRandom();
        }

        public void Run()
        {
            Console.CursorVisible = false;

            CreateMonsters();

            while (true)
            {
                List<Monster> monsters = GetIsAliveMonsters();

                HideMonsters(monsters);
                RunMonsters(monsters);
                ShowIsAliveMonsters(monsters);
                CreateMonstersAgain();
                Thread.Sleep(500);
            }
        }

        private void CreateMonstersAgain()
        {
            if (_random.Next(5) == 0)
            {
                Populate();
            }
        }

        private void ShowIsAliveMonsters(List<Monster> monsters)
        {
            foreach (Monster monster in monsters)
            {
                if (monster.IsAlive)
                {
                    ShowObject(monster.X, monster.Y, monster.Face, monster.Color);
                }
            }
        }

        private static void RunMonsters(List<Monster> monsters)
        {
            foreach (Monster monster in monsters)
            {
                monster.Run();
            }
        }

        private void HideMonsters(List<Monster> monsters)
        {
            foreach (Monster monster in monsters)
            {
                HideObject(monster.X, monster.Y);
            }
        }

        private List<Monster> GetIsAliveMonsters()
        {
            List<Monster> monsters = _world.GetMonsters();
            return monsters;
        }

        private void CreateMonsters()
        {
            for (int i = 0; i < 10; i++)
            {
                Populate();
            }
        }

        private void Populate()
        {
            Monster monster = CreateRandomMonster();
            int x = _random.Next(_world.SizeX);
            int y = _random.Next(_world.SizeY);
            monster.BeBorn(_world, x, y);
        }

        private Monster CreateRandomMonster()
        {
            switch (_random.Next(3))
            {
                case 0:
                case 1:
                    return new Monsters.Hedgehog();
                case 2:
                    return new Monsters.Dog();
                default:
                    throw new Exception();
            }    
        }

        private void ShowObject(int x, int y, char c, ConsoleColor color)
        {
            Console.SetCursorPosition(x + 1, y + 1);
            Console.ForegroundColor = color;
            Console.Write(c);
        }

        private void HideObject(int x, int y)
        {
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write(' ');
        }
    }
}
