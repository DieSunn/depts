using System;

namespace IterLinkedListApp
{
    /// <summary>
    /// Узел односвязного списка.
    /// </summary>
    /// <typeparam name="T">Тип данных, хранящихся в узле.</typeparam>
    public class LinkedListNode<T>
    {
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T value)
        {
            Value = value;
            Next = null;
        }
    }
}
