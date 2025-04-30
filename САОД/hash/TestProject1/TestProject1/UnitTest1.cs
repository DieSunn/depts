using NUnit.Framework;
using HashTableApp;

namespace HashTableTests
{
    // Вспомогательный класс для тестирования коллизий.
    // Все объекты CollisionKey имеют одинаковый хеш-код, что заставляет хеш-таблицу использовать цепочки.
    public class CollisionKey
    {
        public string Key { get; }
        public CollisionKey(string key)
        {
            Key = key;
        }

        public override int GetHashCode()
        {
            return 42; // Фиксированный хеш для всех экземпляров
        }

        public override bool Equals(object obj)
        {
            if (obj is CollisionKey other)
            {
                return Key.Equals(other.Key);
            }
            return false;
        }
    }

    public partial class HashTableNUnitTests
    {
        [Test]
        public void TestCollisionHandling()
        {
            // Создаем хеш-таблицу с ключами типа CollisionKey
            var collisionTable = new HashTable<CollisionKey, int>();

            // Создаем несколько ключей, которые гарантированно будут иметь одинаковый хеш-код.
            var key1 = new CollisionKey("key1");
            var key2 = new CollisionKey("key2");
            var key3 = new CollisionKey("key3");

            // Добавляем записи
            collisionTable.Add(key1, 100);
            collisionTable.Add(key2, 200);
            collisionTable.Add(key3, 300);

            // Проверяем, что все ключи присутствуют
            Assert.IsTrue(collisionTable.ContainsKey(key1), "Таблица должна содержать key1.");
            Assert.IsTrue(collisionTable.ContainsKey(key2), "Таблица должна содержать key2.");
            Assert.IsTrue(collisionTable.ContainsKey(key3), "Таблица должна содержать key3.");

            // Проверяем, что можно корректно получить значение по ключу
            bool found = collisionTable.TryGetValue(key2, out int value);
            Assert.IsTrue(found, "Должен быть найден key2.");
            Assert.AreEqual(200, value, "Значение для key2 должно быть 200.");

            // Удаляем один из ключей и проверяем оставшиеся записи
            bool removed = collisionTable.Remove(key2);
            Assert.IsTrue(removed, "Удаление key2 должно вернуть true.");
            Assert.IsFalse(collisionTable.ContainsKey(key2), "После удаления key2 не должен присутствовать в таблице.");
            Assert.IsTrue(collisionTable.ContainsKey(key1), "key1 должен оставаться в таблице.");
            Assert.IsTrue(collisionTable.ContainsKey(key3), "key3 должен оставаться в таблице.");
        }

        private HashTable<string, int> hashTable;

        [SetUp]
        public void Setup()
        {
            hashTable = new HashTable<string, int>();
        }

        [Test]
        public void TestAddAndContainsKey()
        {
            hashTable.Add("one", 1);
            hashTable.Add("two", 2);

            Assert.IsTrue(hashTable.ContainsKey("one"), "Таблица должна содержать ключ 'one'.");
            Assert.IsTrue(hashTable.ContainsKey("two"), "Таблица должна содержать ключ 'two'.");
            Assert.IsFalse(hashTable.ContainsKey("three"), "Таблица не должна содержать ключ 'three'.");
        }

        [Test]
        public void TestAddDuplicateKeyThrows()
        {
            hashTable.Add("dup", 10);
            Assert.Throws<System.ArgumentException>(() => hashTable.Add("dup", 20));
        }

        [Test]
        public void TestTryGetValue()
        {
            hashTable.Add("test", 42);
            bool found = hashTable.TryGetValue("test", out int value);
            Assert.IsTrue(found, "Ключ 'test' должен быть найден.");
            Assert.AreEqual(42, value, "Значение для ключа 'test' должно равняться 42.");

            found = hashTable.TryGetValue("nonexistent", out value);
            Assert.IsFalse(found, "Ключ 'nonexistent' не должен быть найден.");
        }

        [Test]
        public void TestRemove()
        {
            hashTable.Add("a", 1);
            hashTable.Add("b", 2);
            bool removed = hashTable.Remove("a");

            Assert.IsTrue(removed, "Удаление ключа 'a' должно вернуть true.");
            Assert.IsFalse(hashTable.ContainsKey("a"), "Ключ 'a' должен отсутствовать после удаления.");
            Assert.AreEqual(1, hashTable.Count, "После удаления количество элементов должно быть равно 1.");
        }

        [Test]
        public void TestClear()
        {
            hashTable.Add("x", 100);
            hashTable.Add("y", 200);
            hashTable.Clear();

            Assert.AreEqual(0, hashTable.Count, "После очистки таблица должна быть пуста.");
        }
    }

}
