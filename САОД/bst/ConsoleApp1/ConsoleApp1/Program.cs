using System;
using BinarySearchTreeApp;

namespace BinarySearchTreeAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(3);
            bst.Insert(7);

            Console.WriteLine("In-order обход:");
            TreeTraversal.InOrderTraversal(bst.Root, value => Console.Write(value + " "));

            Console.WriteLine("\n\nPre-order обход:");
            TreeTraversal.PreOrderTraversal(bst.Root, value => Console.Write(value + " "));

            Console.WriteLine("\n\nPost-order обход:");
            TreeTraversal.PostOrderTraversal(bst.Root, value => Console.Write(value + " "));

            Console.WriteLine("\n\nВизуальное представление дерева:");
            bst.PrintTree();

            Console.WriteLine("\n\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
