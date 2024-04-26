using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

//https://medium.com/codex/how-does-dijkstras-algorithm-work-easy-explanation-in-less-than-5-minutes-e27f46795c18
//https://pathfinding-visualizer-nu.vercel.app/

class DijkstraAlgorithm
{
    static void Main(string[] args)
    {
        char[,] grid = { {'.','.','K','.','.'},
                         {'.','#','#','#','#'},
                         {'.','#','#','#','#'},
                         {'.','#','#','#','#'},
                         {'.','.','H','#','#'},};
        DijkstraAlgorithm d = new DijkstraAlgorithm();
        d.Djikstra(grid);
    }

    public void Djikstra(char[,] grid)
    {
        Coordinate catPos = new Coordinate(0,0);
        Coordinate toyPos = new Coordinate(0,0);
        
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == 'K')
                {
                    catPos.X = i;
                    catPos.Y = j;
                }
                else if (grid[i, j] == 'H')
                {
                    catPos.X = i;
                    catPos.Y = j;
                }
            }
        }
        List<Coordinate> visitedNodes = new List<Coordinate> ();
        Dictionary<Coordinate, int> nodeDistances = new Dictionary<Coordinate, int> ();
        Queue<Coordinate> q = new Queue<Coordinate>();
        q.Enqueue( catPos );
        while(q.Count > 0)
        {
            Coordinate currentNode = q.Dequeue();
            Coordinate[] neighbors = { new Coordinate(currentNode.X + 1, currentNode.Y), new Coordinate(currentNode.X - 1, currentNode.Y), new Coordinate(currentNode.X, currentNode.Y + 1), new Coordinate(currentNode.X, currentNode.Y - 1) };
            foreach (Coordinate i in neighbors) 
            {
                if (i.X < 0 || i.Y < 0 || i.X >= grid.GetLength(0) || i.Y >= grid.GetLength(1))
                {
                    continue;
                }
                if (grid[i.X, i.Y] == 'H')
                {
                    Console.WriteLine("Ano");
                    return;
                }
                else if (grid[i.X, i.Y] == '.' && !visitedNodes.Contains(i))
                {
                    q.Enqueue(i);
                }
            }
        }
        Console.WriteLine("Ne");
        
    }
}
