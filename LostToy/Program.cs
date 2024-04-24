using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

//https://medium.com/codex/how-does-dijkstras-algorithm-work-easy-explanation-in-less-than-5-minutes-e27f46795c18
//https://pathfinding-visualizer-nu.vercel.app/

class DijkstraAlgorithm
{
    static void Main(string[] args)
    {
        DijkstraAlgorithm d = new DijkstraAlgorithm();
        d.FindToyAndCat(d.grid);
    }

    char[,] grid = { {'.','.','K','.','.'},
                     {'.','#','#','#','#'},
                     {'.','#','#','#','#'},
                     {'.','#','#','#','#'},
                     {'H','#','#','#','#'},};
    int catPosRow;
    int catPosCol;
    int toyPosRow;
    int toyPosCol;

    public void FindToyAndCat(char[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == 'K')
                {
                    catPosRow = i;
                    catPosCol = j;
                }
                else if (grid[i, j] == 'H')
                {
                    toyPosRow = i;
                    toyPosCol = j;
                }
            }
        }
        Console.WriteLine($"{catPosRow}, {catPosCol}");
        Console.WriteLine($"{toyPosRow}, {toyPosCol}");

    }
}
