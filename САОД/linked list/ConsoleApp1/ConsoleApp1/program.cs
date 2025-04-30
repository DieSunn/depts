using System;
using IterLinkedListApp;

namespace IterLinkedListAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new IterLinkedList<int>();

            // Добавление элементов
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Console.WriteLine("Содержимое списка:");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // Удаление элемента
            list.Remove(2);
            Console.WriteLine("После удаления 2:");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // Проверка наличия элемента
            Console.WriteLine("Содержит ли список 3? " + list.Contains(3));
            Console.WriteLine("Количество элементов: " + list.Count);

            // Очистка списка
            list.Clear();
            Console.WriteLine("После очистки, количество элементов: " + list.Count);

            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
