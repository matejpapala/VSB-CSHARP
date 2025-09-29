using System;
using System.Dynamic;

namespace cviceni2tetris;

public class ClassArray
{
    public class Brick() {
        public int x;
        public int y ;

    }

    public class CompositeBrick() {
        public int x;
        public int y;
        public Brick[] Bricks;
    }

    public void Run() {
        CompositeBrick[] bricks = new CompositeBrick[2];
        bricks[0] = CreateT(1, 0);
        bricks[1] = CreateT(3, 5);
        while(true) {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            PrintPlayground(bricks);
            Thread.Sleep(500);
        }
    }

    private void PrintPlayground(CompositeBrick[] bricks) {
        Console.ForegroundColor = ConsoleColor.Black;
        for(int i = 0;i < bricks.Length;i++) {
            CompositeBrick cb = bricks[i];
            for(int j = 0;j < cb.Bricks.Length;j++) {
                Brick b = cb.Bricks[j];
                Console.SetCursorPosition((cb.x + b.x) * 2, cb.y + b.y);
                Console.Write("\u2588\u2588");
            }
        }
    }

    private void Shift() {

    }

    private CompositeBrick CreateT(int x, int y) {
        CompositeBrick cp = new CompositeBrick() {
            x = x,
            y= y
        };
        cp.Bricks = new Brick[4];
        cp.Bricks[0] = new Brick() {x = 0, y = 0};
        cp.Bricks[1] = new Brick() {x = 1, y = 0};
        cp.Bricks[2] = new Brick() {x = 2, y = 0};
        cp.Bricks[3] = new Brick() {x = 1, y = 1};
        return cp;
    }
}
