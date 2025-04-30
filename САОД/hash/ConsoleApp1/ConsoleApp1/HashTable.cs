using System;
using System.Collections.Generic;

namespace HashTableApp
{
    /// <summary>
    /// Простая хеш-таблица с использованием цепочек для разрешения коллизий.
    /// Поддерживает операции добавления, поиска, удаления, очистки и перечисления ключей.
    /// </summary>
    /// <typeparam name="TKey">Тип ключей.</typeparam>
    /// <typeparam name="TValue">Тип значений.</typeparam>
    public class HashTable<TKey, TValue>
    {
        private const int DefaultCapacity = 16;
        private HashTableEntry<TKey, TValue>[] buckets;

        /// <summary>
        /// Текущее количество элементов в таблице.
        /// </summary>
        public int Count { get; private set; }

        public HashTable(int capacity = DefaultCapacity)
        {
            buckets = new HashTableEntry<TKey, TValue>[capacity];
            Count = 0;
        }

        private int GetBucketIndex(TKey key)
        {
            int hash = key.GetHashCode();
            hash = hash & 0x7FFFFFFF; // делаем хеш неотрицательным
            return hash % buckets.Length;
        }

        /// <summary>
        /// Добавляет новую запись в хеш-таблицу.
        /// Если ключ уже существует, выбрасывается исключение.
        /// </summary>
        public void Add(TKey key, TValue value)
        {
            int index = GetBucketIndex(key);
            // Проверка наличия ключа в цепочке
            var entry = buckets[index];
            while (entry != null)
            {
                if (entry.Key.Equals(key))
                    throw new ArgumentException("Ключ уже существует.");
                entry = entry.Next;
            }
            // Добавляем новый элемент в начало цепочки
            var newEntry = new HashTableEntry<TKey, TValue>(key, value);
            newEntry.Next = buckets[index];
            buckets[index] = newEntry;
            Count++;
        }

        /// <summary>
        /// Проверяет, содержится ли указанный ключ в таблице.
        /// </summary>
        public bool ContainsKey(TKey key)
        {
            int index = GetBucketIndex(key);
            var entry = buckets[index];
            while (entry != null)
            {
                if (entry.Key.Equals(key))
                    return true;
                entry = entry.Next;
            }
            return false;
        }

        /// <summary>
        /// Пытается получить значение по ключу.
        /// Возвращает true, если ключ найден, и значение через out-параметр.
        /// </summary>
        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = GetBucketIndex(key);
            var entry = buckets[index];
            while (entry != null)
            {
                if (entry.Key.Equals(key))
                {
                    value = entry.Value;
                    return true;
                }
                entry = entry.Next;
            }
            value = default(TValue);
            return false;
        }

        /// <summary>
        /// Удаляет запись с указанным ключом.
        /// Возвращает true, если удаление прошло успешно.
        /// </summary>
        public bool Remove(TKey key)
        {
            int index = GetBucketIndex(key);
            HashTableEntry<TKey, TValue> current = buckets[index];
            HashTableEntry<TKey, TValue> previous = null;
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    if (previous == null)
                        buckets[index] = current.Next;
                    else
                        previous.Next = current.Next;
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Очищает хеш-таблицу.
        /// </summary>
        public void Clear()
        {
            buckets = new HashTableEntry<TKey, TValue>[buckets.Length];
            Count = 0;
        }

        /// <summary>
        /// Позволяет перечислить все ключи в таблице.
        /// </summary>
        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach (var bucket in buckets)
                {
                    var entry = bucket;
                    while (entry != null)
                    {
                        yield return entry.Key;
                        entry = entry.Next;
                    }
                }
            }
        }

        /// <summary>
        /// Позволяет перечислить все значения в таблице.
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get
            {
                foreach (var bucket in buckets)
                {
                    var entry = bucket;
                    while (entry != null)
                    {
                        yield return entry.Value;
                        entry = entry.Next;
                    }
                }
            }
        }
    }
}
