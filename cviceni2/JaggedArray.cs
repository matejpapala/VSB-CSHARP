using System;

namespace cviceni2tetris;

public class JaggedArray
{
    private bool[][] playGround = new bool[30][];
    public JaggedArray()
    {
        for (int i = 0; i < playGround.Length; i++)
        {
            playGround[i] = new bool[15];
        }
    }

    public void Run()
    {
        CreateTBlock(2, 0);
        while (true)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            PrintPlayground();
            Shift();
            System.Threading.Thread.Sleep(500);
        }
    }

    public void Shift()
    {
        for (int r = playGround.Length - 1; r > 0; r--)
        {   
             playGround[r] = playGround[r - 1];
        }
            playGround[0] = new bool[playGround[0].Length];
    }

    private void PrintPlayground()
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Black;
        for (int i = 0; i < playGround.Length; i++)
        {
            for (int j = 0; j < playGround[i].Length; j++)
            {
                Console.Write(playGround[i][j] ? "\u2588\u2588" : "  ");
            }
            Console.WriteLine();
        }
    }

    public void CreateTBlock(int x, int y)
    {
        playGround[y][x] = true;
        playGround[y][x + 1] = true;
        playGround[y][x + 2] = true;
        playGround[y + 1][x + 1] = true;
    }
}
