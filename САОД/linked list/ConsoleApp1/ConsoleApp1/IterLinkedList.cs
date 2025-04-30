using System;
using System.Collections;
using System.Collections.Generic;

namespace IterLinkedListApp
{
    /// <summary>
    /// Итеративный односвязный список, реализующий IEnumerable.
    /// </summary>
    /// <typeparam name="T">Тип элементов списка.</typeparam>
    public class IterLinkedList<T> : IEnumerable<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;

        /// <summary>
        /// Количество элементов в списке.
        /// </summary>
        public int Count { get; private set; }

        public IterLinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        /// <summary>
        /// Добавляет элемент в конец списка.
        /// </summary>
        public void Add(T value)
        {
            var newNode = new LinkedListNode<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            Count++;
        }

        /// <summary>
        /// Удаляет первое вхождение указанного значения.
        /// </summary>
        public bool Remove(T value)
        {
            LinkedListNode<T> current = head;
            LinkedListNode<T> previous = null;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    if (previous == null)
                    {
                        // Удаляем head
                        head = current.Next;
                        if (head == null)
                        {
                            tail = null;
                        }
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            // Удаляем tail
                            tail = previous;
                        }
                    }
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Проверяет, содержит ли список указанное значение.
        /// </summary>
        public bool Contains(T value)
        {
            foreach (var item in this)
            {
                if (EqualityComparer<T>.Default.Equals(item, value))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Очищает список.
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        /// <summary>
        /// Итератор для списка.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
