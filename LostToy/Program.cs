using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Security.Cryptography.X509Certificates;

//https://medium.com/codex/how-does-dijkstras-algorithm-work-easy-explanation-in-less-than-5-minutes-e27f46795c18
//https://pathfinding-visualizer-nu.vercel.app/

class BFSAlgorithm
{
    static void Main(string[] args)
    {
        char[,] grid = { {'.','.','K','.','.'},
                         {'.','#','#','#','#'},
                         {'.','#','#','#','#'},
                         {'.','#','#','#','#'},
                         {'.','.','H','#','#'},};
        BFSAlgorithm d = new BFSAlgorithm();
        d.BFS(grid);
    }

    public void BFS(char[,] grid)
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
                    toyPos.X = i;
                    toyPos.Y = j;
                }
            }
        }

        List<Coordinate> visitedNodes = new List<Coordinate> ();
        List<Coordinate[]> nodesTraveled = new List<Coordinate[]>();
        Queue<Coordinate> q = new Queue<Coordinate>();
        Queue<Coordinate> path = new Queue<Coordinate>();
        q.Enqueue( catPos );
        while(q.Count > 0)
        {
            Coordinate currentNode = q.Dequeue();
            Coordinate[] neighbors = { new Coordinate(currentNode.X + 1, currentNode.Y), new Coordinate(currentNode.X - 1, currentNode.Y), new Coordinate(currentNode.X, currentNode.Y + 1), new Coordinate(currentNode.X, currentNode.Y - 1) };
            foreach (Coordinate i in neighbors) 
            {

                if (i.X < 0 || i.Y < 0 || i.X >= grid.GetLength(0) || i.Y >= grid.GetLength(1) || grid[i.X, i.Y] == '#' || visitedNodes.Contains(i))
                {
                    continue;
                }
                nodesTraveled.Add(new Coordinate[] { currentNode, i });

                if (grid[i.X, i.Y] == 'H')
                {

                    Console.WriteLine("Ano");
                    Console.WriteLine(nodesTraveled.Count);
                    foreach (Coordinate[] item in nodesTraveled)
                    {
                        Console.WriteLine($"{item[0].X} | {item[0].Y} ||| {item[1].X} | {item[1].Y}");
                    }
                    return;
                }
                else if (grid[i.X, i.Y] == '.' && !visitedNodes.Contains(i))
                {

                    q.Enqueue(i);
                }
            }
            visitedNodes.Add(currentNode);
            
        }

        Console.WriteLine("Ne");

    }
}
