using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Класс бинарного дерева поиска (BST).
/// Реализует вставку, удаление узлов и поддержку обхода через интерфейс IEnumerable.
/// </summary>
public class BinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
{
    /// <summary>
    /// Корневой узел дерева.
    /// </summary>
    public TreeNode<T> Root { get; private set; }

    /// <summary>
    /// Метод для вставки нового элемента в дерево.
    /// </summary>
    /// <param name="value">Значение, которое нужно вставить</param>
    public void Insert(T value)
    {
        Root = InsertRec(Root, value);
    }

    /// <summary>
    /// Рекурсивный метод вставки узла.
    /// </summary>
    /// <param name="node">Текущий узел</param>
    /// <param name="value">Значение для вставки</param>
    /// <returns>Новый (или обновлённый) узел</returns>
    private TreeNode<T> InsertRec(TreeNode<T> node, T value)
    {
        if (node == null)
            return new TreeNode<T>(value);

        // Если значение меньше, идём в левое поддерево, иначе в правое.
        if (value.CompareTo(node.Value) < 0)
            node.Left = InsertRec(node.Left, value);
        else if (value.CompareTo(node.Value) > 0)
            node.Right = InsertRec(node.Right, value);
        // Если значение уже существует, оно не вставляется (можно модифицировать при необходимости)

        return node;
    }

    /// <summary>
    /// Удаление узла с заданным значением из дерева.
    /// </summary>
    /// <param name="value">Значение для удаления</param>
    public void Delete(T value)
    {
        Root = DeleteRec(Root, value);
    }

    /// <summary>
    /// Рекурсивный метод удаления узла.
    /// </summary>
    /// <param name="node">Текущий узел</param>
    /// <param name="value">Значение для удаления</param>
    /// <returns>Обновлённый узел после удаления</returns>
    private TreeNode<T> DeleteRec(TreeNode<T> node, T value)
    {
        if (node == null)
            return null;

        // Находим узел для удаления
        if (value.CompareTo(node.Value) < 0)
        {
            node.Left = DeleteRec(node.Left, value);
        }
        else if (value.CompareTo(node.Value) > 0)
        {
            node.Right = DeleteRec(node.Right, value);
        }
        else
        {
            // Если узел найден

            // Если узел имеет только один потомок или не имеет их вовсе:
            if (node.Left == null)
                return node.Right;
            else if (node.Right == null)
                return node.Left;

            // Если оба потомка присутствуют, находим минимальное значение в правом поддереве
            node.Value = MinValue(node.Right);

            // Удаляем узел с минимальным значением из правого поддерева
            node.Right = DeleteRec(node.Right, node.Value);
        }

        return node;
    }

    /// <summary>
    /// Находит минимальное значение в дереве (используется при удалении).
    /// </summary>
    /// <param name="node">Корневой узел поддерева</param>
    /// <returns>Минимальное значение</returns>
    private T MinValue(TreeNode<T> node)
    {
        T minv = node.Value;
        while (node.Left != null)
        {
            minv = node.Left.Value;
            node = node.Left;
        }
        return minv;
    }

    /// <summary>
    /// Возвращает итератор для обхода дерева в порядке in-order.
    /// </summary>
    /// <returns>Итератор, реализующий IEnumerator&lt;T&gt;</returns>
    public IEnumerator<T> GetEnumerator()
    {
        // Используем созданный нами итератор
        return new BSTIterator<T>(Root);
    }

    /// <summary>
    /// Невариантная реализация интерфейса IEnumerable.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
