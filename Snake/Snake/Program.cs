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
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(80, 25);
            Console.SetWindowSize(80, 25);
            HLine htop = new HLine(0, 79, 0, '#');
            HLine hbot = new HLine(0, 79, 24, '#');
            VLine vleft = new VLine(0, 24, 0, '#');
            VLine vright = new VLine(0, 24, 78, '#');
            hbot.Draw();
            htop.Draw();
            vright.Draw();
            vleft.Draw();
            
            Point hd = new Point(7, 5,'*');
            Point tl = new Point(5, 5, '*');
            Snake snak = new Snake(hd, tl, 3, Dir.left);
            snak.Draw();


            ConsoleKey e = Console.ReadKey().Key;
            
            while(e != ConsoleKey.Escape)
            {
                e = Console.ReadKey().Key;
                
                snak.Move(e);
                
            }


            Console.ReadLine();
        }
    }
}
