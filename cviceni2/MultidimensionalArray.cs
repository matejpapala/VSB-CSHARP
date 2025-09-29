using System;

namespace cviceni2;

public class MultidimensionalArray
{
    private bool[,] playGround = new bool[15,30];
    public void Run(){
        CreateTBlock(2,0);
        while(true) {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            PrintPlayground();
            Shift();
            System.Threading.Thread.Sleep(500);
        }
    }

    public void Shift() {
        for(int r = playGround.GetLength(1) - 1;r > 0;r--) {
            for(int c = 0;c < playGround.GetLength(0);c++) {
                playGround[c,r] = playGround[c,r-1];
            }
        }
        for(int c = 0;c < playGround.GetLength(0);c++) {
            playGround[c,0] = false;
        }
    }

    private void PrintPlayground() {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Black;
        for(int i = 0;i < playGround.GetLength(1);i++) {
            for(int j = 0;j < playGround.GetLength(0);j++) {
                Console.Write(playGround[j,i] ? "\u2588\u2588" : "  ");
            }
            Console.WriteLine();
        }
    }

    public void CreateTBlock(int x, int y) {
        playGround[x,y] = true;
        playGround[x+1,y] = true;
        playGround[x+2,y] = true;
        playGround[x+1,y+1] = true;
    }
}
