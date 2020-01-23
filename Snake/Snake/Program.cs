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
            
            Point hd = new Point(8, 5,'*');
            Point tl = new Point(5, 5, '*');
            Snake snak = new Snake(tl, hd, 3, Dir.left);
            snak.Draw();


            ConsoleKey e;
            
            while(true)
            {
                e = Console.ReadKey().Key;
                
                snak.Move(e);
                
            }


            Console.ReadLine();
        }
    }
}
