using NUnit.Framework;
using IterLinkedListApp;
using System.Collections.Generic;
using System.Linq;

namespace IterLinkedListTests
{
    [TestFixture]
    public class IterLinkedListNUnitTests
    {
        private IterLinkedList<int> list;

        [SetUp]
        public void Setup()
        {
            list = new IterLinkedList<int>();
        }

        [Test]
        public void TestAddAndCount()
        {
            list.Add(10);
            list.Add(20);
            list.Add(30);
            Assert.AreEqual(3, list.Count, "Количество элементов должно быть равно 3.");
        }

        [Test]
        public void TestContains()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.IsTrue(list.Contains(2), "Список должен содержать 2.");
            Assert.IsFalse(list.Contains(4), "Список не должен содержать 4.");
        }

        [Test]
        public void TestRemove()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            bool removed = list.Remove(2);
            Assert.IsTrue(removed, "Удаление 2 должно вернуть true.");
            Assert.AreEqual(2, list.Count, "Количество элементов должно уменьшиться до 2.");
            Assert.IsFalse(list.Contains(2), "Список не должен содержать 2 после удаления.");
        }

        [Test]
        public void TestClear()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Clear();
            Assert.AreEqual(0, list.Count, "После очистки список должен быть пуст.");
        }

        [Test]
        public void TestIteration()
        {
            var expected = new List<int> { 5, 10, 15 };
            foreach (var val in expected)
            {
                list.Add(val);
            }
            List<int> result = list.ToList();
            CollectionAssert.AreEqual(expected, result, "Итерация должна вернуть добавленные элементы в порядке их добавления.");
        }
    }
}
