using System;
using System.Collections.Generic;

namespace HomeWorkAl5
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();
            tree.AddItem(10);
            tree.AddItem(100);
            tree.AddItem(1);
            tree.AddItem(4);
            tree.AddItem(50);
            tree.AddItem(0);
            tree.AddItem(19);
            tree.AddItem(45);
            tree.AddItem(17);

            tree.PrintTree();
            Console.WriteLine();

            Console.WriteLine($"BFS: \nОжидание:  [10]  [1]  [100]  [0]  [4]  [50]  [19]  [17]  [45]");
            Console.Write("Реальность: ");
            tree.BreadthFirstSearch();
            Console.WriteLine();

            Console.WriteLine($"DFS: \nОжидание:  [10]  [1]  [0]  [4]  [100]  [50]  [19]  [17]  [45]");
            Console.Write("Реальность: ");
            tree.DeepFirstSearch();
            
        }

    }

    

    
    

    
}
