using System;

namespace BinarySearchTreeApp
{
    /// <summary>
    /// Класс, представляющий узел в двоичном дереве поиска.
    /// </summary>
    /// <typeparam name="T">Тип данных, хранящихся в узле (должен быть сравнимым).</typeparam>
    public class Node<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
}
