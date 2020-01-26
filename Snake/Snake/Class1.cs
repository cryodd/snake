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
        public void Move(int i, Dir dir)
        {
            switch (dir)
            {
                case (Dir.left):
                    x -= i;
                    break;
                case (Dir.right):
                    x += i;
                    break;
                case (Dir.up):
                    y -= i;
                    break;
                case (Dir.down):
                    y += i;
                    break;
            }
        }
        public bool isHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
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
        Dir direct;
        public Snake(Point tale, int length, Dir direction)
        {
            direct = direction;
            
            for(int i = 0; i < length; i++)
            {
                Point p = new Point(tale);
                p.Move(i, direction);
                Fsnake.Add(p);
            }
        }
        public void Move()
        {
            Point tale = Fsnake[0];
            Fsnake.Remove(tale);
            Point head = GetNext();
            Fsnake.Add(head);
            tale.Clear();
            head.Draw();
        }
        public Point GetNext()
        {
            Point head = Fsnake[Fsnake.Count - 1];
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direct);
            return nextPoint;
        }
        public void cd(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    
                    direct = Dir.down;
                    
                    break;
                case ConsoleKey.UpArrow:
                    
                    direct = Dir.up;
                    
                    break;
                case ConsoleKey.RightArrow:
                    
                    direct = Dir.right;
                    
                    break;
                case ConsoleKey.LeftArrow:
                    
                    direct = Dir.left;
                    
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
        public bool Eat(Point food)
        {
            Point head = GetNext();
            //if (head.isHit(food))
            if(head.x ==food.x && head.y == food.y)
            {
                food.sym = head.sym;
                Fsnake.Add(food);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Food
    {
        int height,width;
        char sym;
        Random rand = new Random();
        public Food(int hei,int wid, char sym)
        {
            height = hei;
            width = wid;
            this.sym = sym;
        }
        public Point CreateFood()
        {
            int x = rand.Next(2, width - 2);
            int y = rand.Next(2, height - 2);
            return new Point(x, y, sym);
        }
    }
}
