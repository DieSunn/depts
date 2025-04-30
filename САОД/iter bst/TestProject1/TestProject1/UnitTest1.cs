using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class BinarySearchTreeTests
{
    /// <summary>
    /// Тестируем корректность вставки элементов и обхода дерева.
    /// </summary>
    [Test]
    public void InOrderTraversal_ReturnsElementsInSortedOrder()
    {
        // Arrange
        var bst = new BinarySearchTree<int>();
        int[] inputValues = { 50, 30, 70, 20, 40, 60, 80 };
        foreach (var value in inputValues)
        {
            bst.Insert(value);
        }

        // Ожидаемый результат при обходе in-order (сортировка по возрастанию)
        var expectedOrder = new List<int> { 20, 30, 40, 50, 60, 70, 80 };

        // Act
        var actualOrder = new List<int>();
        foreach (var value in bst)
        {
            actualOrder.Add(value);
        }

        // Assert
        Assert.AreEqual(expectedOrder, actualOrder);
    }

    /// <summary>
    /// Тестируем удаление элемента из дерева.
    /// </summary>
    [Test]
    public void Delete_RemovesElement_CorrectOrderAfterDeletion()
    {
        // Arrange
        var bst = new BinarySearchTree<int>();
        int[] inputValues = { 50, 30, 70, 20, 40, 60, 80 };
        foreach (var value in inputValues)
        {
            bst.Insert(value);
        }
        // Ожидаемое состояние дерева после удаления 30
        var expectedOrderAfterDelete = new List<int> { 20, 40, 50, 60, 70, 80 };

        // Act
        bst.Delete(30);
        var actualOrderAfterDelete = new List<int>();
        foreach (var value in bst)
        {
            actualOrderAfterDelete.Add(value);
        }

        // Assert
        Assert.AreEqual(expectedOrderAfterDelete, actualOrderAfterDelete);
    }

    /// <summary>
    /// Тестируем поведение итератора для пустого дерева.
    /// </summary>
    [Test]
    public void Iterator_ForEmptyTree_ReturnsNoElements()
    {
        // Arrange
        var bst = new BinarySearchTree<int>();

        // Act
        var actualOrder = new List<int>();
        foreach (var value in bst)
        {
            actualOrder.Add(value);
        }

        // Assert
        Assert.IsEmpty(actualOrder);
    }
}
