using System;

/// <summary>
/// Класс узла бинарного дерева поиска.
/// Хранит значение, ссылку на левое и правое поддерево.
/// </summary>
public class TreeNode<T> where T : IComparable<T>
{
    /// <summary>
    /// Значение узла.
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// Ссылка на левый потомок.
    /// </summary>
    public TreeNode<T> Left { get; set; }

    /// <summary>
    /// Ссылка на правый потомок.
    /// </summary>
    public TreeNode<T> Right { get; set; }

    /// <summary>
    /// Конструктор узла с заданным значением.
    /// </summary>
    /// <param name="value">Хранимое значение</param>
    public TreeNode(T value)
    {
        Value = value;
    }
}
