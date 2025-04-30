using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using BinarySearchTreeApp; // Убедитесь, что пространство имён соответствует вашему проекту

namespace BinarySearchTreeTests
{
    [TestFixture]
    public class BinarySearchTreeNUnitTests
    {
        private BinarySearchTree<int> bst;

        [SetUp]
        public void Setup()
        {
            bst = new BinarySearchTree<int>();
        }

        [Test]
        public void TestInsertAndContains()
        {
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);

            Assert.IsTrue(bst.Contains(10), "Дерево должно содержать 10.");
            Assert.IsTrue(bst.Contains(5), "Дерево должно содержать 5.");
            Assert.IsTrue(bst.Contains(15), "Дерево должно содержать 15.");
            Assert.IsFalse(bst.Contains(100), "Дерево не должно содержать 100.");
        }

        [Test]
        public void TestRemove()
        {
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(3);
            bst.Insert(7);

            bst.Remove(5);

            Assert.IsFalse(bst.Contains(5), "После удаления значение 5 не должно присутствовать.");
            Assert.IsTrue(bst.Contains(10), "Значение 10 должно присутствовать.");
            Assert.IsTrue(bst.Contains(15), "Значение 15 должно присутствовать.");
        }

        [Test]
        public void TestClearAndIsEmpty()
        {
            bst.Insert(1);
            bst.Insert(2);
            bst.Clear();

            Assert.IsTrue(bst.IsEmpty(), "Дерево должно быть пустым после очистки.");
        }

        [Test]
        public void TestGetHeight()
        {
            // Пустое дерево
            Assert.AreEqual(0, bst.GetHeight(), "Высота пустого дерева должна равняться 0.");

            bst.Insert(10);
            Assert.AreEqual(1, bst.GetHeight(), "Высота дерева с одним узлом должна равняться 1.");

            bst.Insert(5);
            bst.Insert(15);
            Assert.AreEqual(2, bst.GetHeight(), "Высота дерева с корневым узлом и двумя дочерними равна 2.");

            bst.Insert(3);
            Assert.AreEqual(3, bst.GetHeight(), "Высота дерева должна учитывать глубину добавленных узлов.");
        }

        [Test]
        public void TestInOrderTraversal()
        {
            // Ожидаем отсортированную последовательность
            var expected = new List<int> { 3, 5, 7, 10, 15 };

            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(3);
            bst.Insert(7);

            var result = new List<int>();
            TreeTraversal.InOrderTraversal(bst.Root, value => result.Add(value));

            CollectionAssert.AreEqual(expected, result, "In-order обход должен выдавать отсортированную последовательность.");
        }

        [Test]
        public void TestPreOrderTraversal()
        {
            // Ожидаемый порядок обхода: корень, левое поддерево, правое поддерево
            var expected = new List<int> { 10, 5, 3, 7, 15 };

            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(3);
            bst.Insert(7);

            var result = new List<int>();
            TreeTraversal.PreOrderTraversal(bst.Root, value => result.Add(value));

            CollectionAssert.AreEqual(expected, result, "Pre-order обход не соответствует ожидаемому порядку.");
        }

        [Test]
        public void TestPostOrderTraversal()
        {
            // Ожидаемый порядок обхода: левое поддерево, правое поддерево, корень
            var expected = new List<int> { 3, 7, 5, 15, 10 };

            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(3);
            bst.Insert(7);

            var result = new List<int>();
            TreeTraversal.PostOrderTraversal(bst.Root, value => result.Add(value));

            CollectionAssert.AreEqual(expected, result, "Post-order обход не соответствует ожидаемому порядку.");
        }

        [Test]
        public void TestPrintTreeOutput()
        {
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);

            using (var sw = new StringWriter())
            {
                // Перенаправляем вывод консоли в StringWriter
                Console.SetOut(sw);
                bst.PrintTree();
                string output = sw.ToString();

                Assert.IsTrue(output.Contains("10"), "Вывод должен содержать корневой узел 10.");
                Assert.IsTrue(output.Contains("5"), "Вывод должен содержать узел 5.");
                Assert.IsTrue(output.Contains("15"), "Вывод должен содержать узел 15.");
            }
        }
    }
}
