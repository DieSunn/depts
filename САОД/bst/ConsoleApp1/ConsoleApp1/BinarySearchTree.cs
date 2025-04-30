using System;

namespace BinarySearchTreeApp
{
    /// <summary>
    /// Реализация двоичного дерева поиска (Binary Search Tree, BST) без методов обхода.
    /// </summary>
    /// <typeparam name="T">Тип данных, хранящихся в дереве (должен быть сравнимым).</typeparam>
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private Node<T> _root;
        private const int COUNT = 5; // Для метода визуализации дерева

        public BinarySearchTree()
        {
            _root = null;
        }

        /// <summary>
        /// Публичное свойство для получения корневого узла дерева.
        /// </summary>
        public Node<T> Root => _root;

        public void Insert(T value)
        {
            _root = InsertRecursive(_root, value);
        }

        private Node<T> InsertRecursive(Node<T> current, T value)
        {
            if (current == null)
            {
                return new Node<T>(value);
            }

            int compareResult = value.CompareTo(current.Value);
            if (compareResult < 0)
            {
                current.Left = InsertRecursive(current.Left, value);
            }
            else if (compareResult > 0)
            {
                current.Right = InsertRecursive(current.Right, value);
            }
            // Дубликаты игнорируются

            return current;
        }

        public bool Contains(T value)
        {
            return ContainsRecursive(_root, value);
        }

        private bool ContainsRecursive(Node<T> current, T value)
        {
            if (current == null)
                return false;

            int compareResult = value.CompareTo(current.Value);
            if (compareResult == 0)
                return true;

            return compareResult < 0
                ? ContainsRecursive(current.Left, value)
                : ContainsRecursive(current.Right, value);
        }

        public void Remove(T value)
        {
            _root = RemoveRecursive(_root, value);
        }

        private Node<T> RemoveRecursive(Node<T> current, T value)
        {
            if (current == null)
                return null;

            int compareResult = value.CompareTo(current.Value);
            if (compareResult < 0)
            {
                current.Left = RemoveRecursive(current.Left, value);
            }
            else if (compareResult > 0)
            {
                current.Right = RemoveRecursive(current.Right, value);
            }
            else
            {
                // Узел с одним или без ребенка
                if (current.Left == null)
                    return current.Right;
                else if (current.Right == null)
                    return current.Left;

                // Узел с двумя детьми: находим наименьший узел в правом поддереве
                current.Value = FindMinValue(current.Right);
                current.Right = RemoveRecursive(current.Right, current.Value);
            }

            return current;
        }

        private T FindMinValue(Node<T> root)
        {
            T minValue = root.Value;
            while (root.Left != null)
            {
                minValue = root.Left.Value;
                root = root.Left;
            }
            return minValue;
        }

        public void Clear()
        {
            _root = null;
        }

        public int GetHeight()
        {
            return CalculateHeight(_root);
        }

        private int CalculateHeight(Node<T> node)
        {
            if (node == null)
                return 0;

            int leftHeight = CalculateHeight(node.Left);
            int rightHeight = CalculateHeight(node.Right);
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public bool IsEmpty()
        {
            return _root == null;
        }

        /// <summary>
        /// Метод для визуализации дерева в консоли (поворот на 90°).
        /// </summary>
        public void PrintTree()
        {
            PrintTreeRecursive(_root, 0);
        }

        private void PrintTreeRecursive(Node<T> node, int space)
        {
            if (node == null)
                return;

            space += COUNT;
            PrintTreeRecursive(node.Right, space);

            Console.WriteLine();
            for (int i = COUNT; i < space; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(node.Value);

            PrintTreeRecursive(node.Left, space);
        }
    }
}
