using System;

class Program
{
    static void Main()
    {
        // Создаём экземпляр бинарного дерева поиска
        var bst = new BinarySearchTree<int>();

        // Вставляем элементы в дерево
        bst.Insert(50);
        bst.Insert(30);
        bst.Insert(70);
        bst.Insert(20);
        bst.Insert(40);
        bst.Insert(60);
        bst.Insert(80);

        Console.WriteLine("Элементы дерева в порядке in-order (до удаления):");

        // Вывод элементов дерева до удаления
        foreach (var value in bst)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();

        // Удаляем элемент (например, 30)
        bst.Delete(30);

        Console.WriteLine("Элементы дерева в порядке in-order (после удаления 30):");

        // Вывод элементов дерева после удаления
        foreach (var value in bst)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }
}
