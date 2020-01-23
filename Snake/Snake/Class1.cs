using System;
using System.Collections.Generic;

namespace Snake
{
    enum Dir
    {
        left,
        right,
        up,
        down
    }
    class Point
    {
        public int x, y;
        public char sym;


        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;

        }
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
        public void Clear()
        {
            sym = ' ';
            Draw();
        }

    }
    class HLine
    {
        List<Point> hlist;
        public HLine(int start, int end, int y, char chr)
        {
            hlist = new List<Point>();
            for (int xl = start; xl <= end; xl++)
            {

                Point pl = new Point(xl, y, chr);
                hlist.Add(pl);
            }
        }
        public void Draw()
        {
            foreach (Point pd in hlist)
            {
                pd.Draw();
            }
        }
    }
    class VLine
    {
        List<Point> vlist;
        public VLine(int start, int end, int x, char chr)
        {
            vlist = new List<Point>();
            for (int yl = start; yl <= end; yl++)
            {

                Point pl = new Point(x, yl, chr);
                vlist.Add(pl);
            }
        }
        public void Draw()
        {
            foreach (Point pd in vlist)
            {
                pd.Draw();
            }
        }
    }
    class Snake
    {
        List<Point> Fsnake = new List<Point>();
        Point tale;
        int len;
        Dir direct;
        Point head;
        Point start;
        public Snake(Point _tale, Point _head, int length, Dir direction)
        {
            
            tale = _tale;
            head = _head;
            len = length;
            direct = direction;
            Fsnake.Add(_tale);
            start = new Point(tale.x, tale.y, '*');
            for (int tjh = 1; tjh < len; tjh++)
            {
                start = new Point(start.x, tale.y, '*');
                Fsnake.Add(start);
                start.x += 1;
            }
            Point hed = head;
            Fsnake.Add(hed);
        }
        public void update()
        {
            Point head = Fsnake[Fsnake.Count - 1];
            Point tale = Fsnake[0];
            tale.Clear();
            Fsnake.Remove(tale);
            Point pt = new Point(head);
            Fsnake.Add(pt);
            
            
            Draw();
        }
        public void Move(ConsoleKey et)
        {
            switch (et)
            {
                case ConsoleKey.DownArrow:
                    head.y += 1;
                    direct = Dir.down;
                    update();
                    break;
                case ConsoleKey.UpArrow:
                    head.y -= 1;
                    direct = Dir.up;
                    update();
                    break;
                case ConsoleKey.RightArrow:
                    head.x += 1;
                    direct = Dir.right;
                    update();
                    break;
                case ConsoleKey.LeftArrow:
                    head.x -= 1;
                    direct = Dir.left;
                    update();
                    break;
            }
            
        }
        public void Draw()
        {
            foreach (Point pd in Fsnake)
            {
                
                pd.Draw();
            }
        }
    }
}
