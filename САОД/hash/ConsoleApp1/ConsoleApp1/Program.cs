using System;
using HashTableApp;

namespace HashTableAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            // Добавляем записи
            hashTable.Add("apple", 1);
            hashTable.Add("banana", 2);
            hashTable.Add("orange", 3);

            Console.WriteLine("Содержимое хеш-таблицы:");
            foreach (var key in hashTable.Keys)
            {
                if (hashTable.TryGetValue(key, out int value))
                {
                    Console.WriteLine($"{key} : {value}");
                }
            }

            // Проверка наличия ключей
            Console.WriteLine("\nСодержит ли таблица ключ 'apple'? " + hashTable.ContainsKey("apple"));
            Console.WriteLine("Содержит ли таблица ключ 'grape'? " + hashTable.ContainsKey("grape"));

            // Удаляем запись
            hashTable.Remove("banana");
            Console.WriteLine("\nПосле удаления 'banana':");
            foreach (var key in hashTable.Keys)
            {
                if (hashTable.TryGetValue(key, out int value))
                {
                    Console.WriteLine($"{key} : {value}");
                }
            }

            // Очистка таблицы
            hashTable.Clear();
            Console.WriteLine("\nПосле очистки, количество элементов: " + hashTable.Count);

            Console.WriteLine("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
