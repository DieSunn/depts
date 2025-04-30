using System;

namespace HashTableApp
{
    /// <summary>
    /// Представляет запись (элемент) хеш-таблицы.
    /// Содержит ключ, значение и ссылку на следующий элемент в цепочке.
    /// </summary>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    /// <typeparam name="TValue">Тип значения.</typeparam>
    public class HashTableEntry<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public HashTableEntry<TKey, TValue> Next { get; set; }

        public HashTableEntry(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }
}
