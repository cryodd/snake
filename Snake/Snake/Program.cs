using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            
            HLine htop = new HLine(0, 79, 0, '#');
            HLine hbot = new HLine(0, 79, 24, '#');
            VLine vleft = new VLine(0, 24, 0, '#');
            VLine vright = new VLine(0, 24, 78, '#');
            hbot.Draw();
            htop.Draw();
            vright.Draw();
            vleft.Draw();
            Point tl = new Point(5, 5, '*');
            Snake snak = new Snake(tl, 3, Dir.right);
            snak.Draw();
            Food foodrea = new Food(24, 79, '$');
            Point food = foodrea.CreateFood();
            food.Draw();
            while(true)
            {
                if (snak.Eat(food))
                {
                    food = foodrea.CreateFood();
                    food.Draw();
                }
                else
                {
                    snak.Move();
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snak.cd(key.Key);
                }
                Thread.Sleep(200);
                snak.Move();
            }


        }
    }
}
