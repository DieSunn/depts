using System;

namespace BinarySearchTreeApp
{
    /// <summary>
    /// Класс для обхода дерева. Методы обхода реализованы как статические методы.
    /// </summary>
    public static class TreeTraversal
    {
        /// <summary>
        /// Выполняет in-order обход дерева.
        /// </summary>
        /// <typeparam name="T">Тип данных узлов дерева.</typeparam>
        /// <param name="node">Начальный узел (обычно корень).</param>
        /// <param name="action">Действие, выполняемое для каждого узла.</param>
        public static void InOrderTraversal<T>(Node<T> node, Action<T> action) where T : IComparable<T>
        {
            if (node == null)
                return;

            InOrderTraversal(node.Left, action);
            action(node.Value);
            InOrderTraversal(node.Right, action);
        }

        /// <summary>
        /// Выполняет pre-order обход дерева.
        /// </summary>
        public static void PreOrderTraversal<T>(Node<T> node, Action<T> action) where T : IComparable<T>
        {
            if (node == null)
                return;

            action(node.Value);
            PreOrderTraversal(node.Left, action);
            PreOrderTraversal(node.Right, action);
        }

        /// <summary>
        /// Выполняет post-order обход дерева.
        /// </summary>
        public static void PostOrderTraversal<T>(Node<T> node, Action<T> action) where T : IComparable<T>
        {
            if (node == null)
                return;

            PostOrderTraversal(node.Left, action);
            PostOrderTraversal(node.Right, action);
            action(node.Value);
        }
    }
}
