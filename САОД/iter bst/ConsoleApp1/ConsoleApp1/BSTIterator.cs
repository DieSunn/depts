using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Класс итератора BST (Iter BST)
/// IEnumerator - Интерфейс, позволяющий использовать объект класса в foreach
/// </summary>

public class BSTIterator<T> : IEnumerator<T> where T : IComparable<T>
{
    // Стек для отслеживания узлов во время обхода.
    private readonly Stack<TreeNode<T>> _stack;
    // Значение текущего узла, на который указывает итератор.
    private T _currentValue;
    // Флаг, указывающий, переместился ли итератор к первому элементу.
    private bool _hasMoved = false;

    /// <summary>
    /// Конструктор итератора. Инициализирует стек, помещая в него
    /// все левые дочерние узлы от корня до самого левого узла.
    /// </summary>
    /// <param name="root">Корневой узел бинарного дерева поиска.</param>
    public BSTIterator(TreeNode<T> root)
    {
        _stack = new Stack<TreeNode<T>>();
        PushAllLeft(root);
    }

    /// <summary>
    /// Вспомогательный метод для помещения узла и всех его левых дочерних узлов в стек.
    /// </summary>
    /// <param name="node">Начальный узел.</param>
    private void PushAllLeft(TreeNode<T> node)
    {
        while (node != null)
        {
            _stack.Push(node);
            node = node.Left;
        }
    }

    /// <summary>
    /// Возвращает элемент в коллекции в текущей позиции перечислителя.
    /// </summary>
    public T Current
    {
        get
        {
            if (!_hasMoved)
            {
                // Или выбросить InvalidOperationException, если предпочтительнее, до первого MoveNext()
                throw new InvalidOperationException("MoveNext должен быть вызван перед доступом к Current.");
            }
            return _currentValue;
        }
    }

    // Явная реализация интерфейса для неженерикового IEnumerator
    object IEnumerator.Current => Current;

    /// <summary>
    /// Перемещает перечислитель к следующему элементу коллекции.
    /// </summary>
    /// <returns>true, если перечислитель успешно перемещен к следующему элементу;
    /// false, если перечислитель прошел конец коллекции.</returns>
    public bool MoveNext()
    {
        if (_stack.Count == 0)
        {
            _hasMoved = false; // Указываем на конец коллекции
            return false;
        }

        // Извлекаем верхний узел из стека (который является следующим наименьшим элементом в in-order обходе)
        TreeNode<T> currentNode = _stack.Pop();
        _currentValue = currentNode.Value; // Устанавливаем текущее значение

        // Если извлеченный узел имеет правого дочернего узла, помещаем правого дочернего узла
        // и всех его левых дочерних узлов в стек.
        if (currentNode.Right != null)
        {
            PushAllLeft(currentNode.Right);
        }

        _hasMoved = true; // Указываем, что мы переместились к допустимому элементу
        return true;
    }

    /// <summary>
    /// Устанавливает перечислитель в его начальное положение, которое находится перед первым элементом в коллекции.
    /// </summary>
    public void Reset()
    {
        _stack.Clear();
        throw new NotSupportedException("Reset не поддерживается для данной реализации итератора.");
    }

    /// <summary>
    /// Выполняет определяемые приложением задачи, связанные с освобождением, высвобождением
    /// или сбросом неуправляемых ресурсов.
    /// </summary>
    public void Dispose()
    {
        // Нет неуправляемых ресурсов для освобождения.
        // Стек будет собран сборщиком мусора.
    }
}