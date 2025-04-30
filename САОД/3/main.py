import sys
import collections
import unittest

# Определяем класс узла бинарного дерева
class TreeNode:
    def __init__(self, value):
        self.value = value
        self.left = None
        self.right = None

# Класс бинарного дерева поиска (BST)
class BinarySearchTree:
    def __init__(self):
        self.root = None

    def insert(self, value):
        """Вставка нового значения в дерево."""
        if self.root is None:
            self.root = TreeNode(value)
        else:
            self._insert(self.root, value)

    def _insert(self, node, value):
        if value < node.value:
            if node.left is None:
                node.left = TreeNode(value)
            else:
                self._insert(node.left, value)
        elif value > node.value:
            if node.right is None:
                node.right = TreeNode(value)
            else:
                self._insert(node.right, value)
        # Если значение уже существует, ничего не делаем.

    def bfs(self):
        """Обход дерева в ширину (BFS). Возвращает список значений в порядке обхода."""
        if self.root is None:
            return []
        queue = collections.deque([self.root])
        result = []
        while queue:
            current = queue.popleft()
            result.append(current.value)
            if current.left:
                queue.append(current.left)
            if current.right:
                queue.append(current.right)
        return result

    def copy(self):
        """
        Создаёт копию бинарного дерева поиска с использованием обхода в ширину.
        Возвращает новый объект BinarySearchTree.
        """
        if self.root is None:
            return BinarySearchTree()
        new_tree = BinarySearchTree()
        # Словарь для хранения соответствий между оригинальными и новыми узлами
        mapping = {}
        queue = collections.deque([self.root])
        new_tree.root = TreeNode(self.root.value)
        mapping[self.root] = new_tree.root
        while queue:
            current = queue.popleft()
            new_current = mapping[current]
            if current.left:
                new_left = TreeNode(current.left.value)
                new_current.left = new_left
                mapping[current.left] = new_left
                queue.append(current.left)
            if current.right:
                new_right = TreeNode(current.right.value)
                new_current.right = new_right
                mapping[current.right] = new_right
                queue.append(current.right)
        return new_tree

    def max_safe_height(self, safety_margin=50):
        """
        Бонус: Определяет максимальную высоту дерева для корректной работы
        рекурсивного алгоритма обхода, чтобы не произошло переполнение стека.
        Используется текущий лимит рекурсии sys.getrecursionlimit() с запасом.
        """
        return sys.getrecursionlimit() - safety_margin

# Примеры использования итераторов для стандартных коллекций

def example_iterators():
    # Пример для списка (аналог std::list)
    py_list = [1, 2, 3, 4, 5]
    print("Итерация по списку с использованием цикла for:")
    for item in py_list:
        print(item, end=" ")
    print("\n")

    print("Итерация по списку с использованием явного итератора:")
    list_iterator = iter(py_list)
    while True:
        try:
            item = next(list_iterator)
            print(item, end=" ")
        except StopIteration:
            break
    print("\n")

    # Пример для множества (set) как другой стандартной коллекции
    py_set = {10, 20, 30, 40, 50}
    print("Итерация по множеству с использованием цикла for:")
    for item in py_set:
        print(item, end=" ")
    print("\n")

    print("Итерация по множеству с использованием явного итератора:")
    set_iterator = iter(py_set)
    while True:
        try:
            item = next(set_iterator)
            print(item, end=" ")
        except StopIteration:
            break
    print("\n")

# Тесты для класса BinarySearchTree

class TestBinarySearchTree(unittest.TestCase):
    def test_insert_and_bfs(self):
        bst = BinarySearchTree()
        values = [50, 30, 70, 20, 40, 60, 80]
        for v in values:
            bst.insert(v)
        # Ожидаемый порядок обхода в ширину: сначала корень, затем его дети и т.д.
        expected_bfs = [50, 30, 70, 20, 40, 60, 80]
        self.assertEqual(bst.bfs(), expected_bfs)

    def test_copy(self):
        bst = BinarySearchTree()
        values = [50, 30, 70, 20, 40, 60, 80]
        for v in values:
            bst.insert(v)
        copied_tree = bst.copy()
        # Проверяем, что обход в ширину копии совпадает с оригиналом
        self.assertEqual(copied_tree.bfs(), bst.bfs())
        # Убедимся, что корни – разные объекты (глубокое копирование)
        self.assertIsNot(copied_tree.root, bst.root)
        # Изменение копии не должно влиять на оригинальное дерево
        copied_tree.insert(25)
        self.assertNotEqual(copied_tree.bfs(), bst.bfs())

    def test_max_safe_height(self):
        bst = BinarySearchTree()
        safe_height = bst.max_safe_height()
        self.assertTrue(safe_height > 0)
        self.assertTrue(safe_height < sys.getrecursionlimit())

if __name__ == '__main__':
    print("Примеры использования итераторов:")
    example_iterators()

    print("Запуск тестов для BinarySearchTree:")
    unittest.main()
