# Класс для двоичного дерева
class TreeNode:
    def __init__(self, value, left=None, right=None):
        self.value = value
        self.left = left
        self.right = right

# Обходы двоичного дерева

def preorder_traversal(node, action=None, result=None):
    """
    Обход дерева в порядке NLR (Preorder).
    :param node: текущий узел (TreeNode)
    :param action: функция, применяемая к узлу (если задана)
    :param result: список накопления значений (для рекурсии)
    :return: список значений узлов в порядке обхода
    """
    if result is None:
        result = []
    if node is None:
        return result
    if action:
        action(node)
    result.append(node.value)
    preorder_traversal(node.left, action, result)
    preorder_traversal(node.right, action, result)
    return result

def inorder_traversal(node, action=None, result=None):
    """
    Обход дерева в порядке LNR (Inorder).
    :param node: текущий узел (TreeNode)
    :param action: функция, применяемая к узлу (если задана)
    :param result: список накопления значений (для рекурсии)
    :return: список значений узлов в порядке обхода
    """
    if result is None:
        result = []
    if node is None:
        return result
    inorder_traversal(node.left, action, result)
    if action:
        action(node)
    result.append(node.value)
    inorder_traversal(node.right, action, result)
    return result

def postorder_traversal(node, action=None, result=None):
    """
    Обход дерева в порядке LRN (Postorder).
    :param node: текущий узел (TreeNode)
    :param action: функция, применяемая к узлу (если задана)
    :param result: список накопления значений (для рекурсии)
    :return: список значений узлов в порядке обхода
    """
    if result is None:
        result = []
    if node is None:
        return result
    postorder_traversal(node.left, action, result)
    postorder_traversal(node.right, action, result)
    if action:
        action(node)
    result.append(node.value)
    return result

# Дополнительные функции для двоичного дерева

def delete_tree(node):
    """
    Рекурсивное "удаление" дерева: разрываем ссылки, чтобы сборщик мусора мог освободить память.
    :param node: текущий узел (TreeNode)
    """
    if node is None:
        return
    delete_tree(node.left)
    delete_tree(node.right)
    # Обнуляем ссылки
    node.left = None
    node.right = None
    # Опционально можно обнулить значение: node.value = None

def count_nodes(node):
    """
    Подсчёт числа узлов в дереве.
    :param node: текущий узел (TreeNode)
    :return: целое число узлов
    """
    if node is None:
        return 0
    return 1 + count_nodes(node.left) + count_nodes(node.right)

def tree_depth(node):
    """
    Определение глубины дерева.
    :param node: текущий узел (TreeNode)
    :return: глубина дерева (целое число)
    """
    if node is None:
        return 0
    return 1 + max(tree_depth(node.left), tree_depth(node.right))

def print_tree(node, indent=0):
    """
    Печать дерева в виде бокового представления (корень слева, листья справа).
    :param node: текущий узел (TreeNode)
    :param indent: текущий отступ (количество пробелов)
    """
    if node is None:
        return
    # Сначала печатаем правое поддерево с большим отступом
    print_tree(node.right, indent + 4)
    print(" " * indent + str(node.value))
    print_tree(node.left, indent + 4)

# Функция для применения произвольной функции к каждому узлу дерева.
# Здесь функция применяется в порядке обхода (например, pre-order).
def apply_to_each_node(node, func, order='preorder'):
    """
    Применение функции func к каждому узлу дерева.
    :param node: корень дерева (TreeNode)
    :param func: функция, принимающая один аргумент (узел)
    :param order: порядок обхода: 'preorder', 'inorder' или 'postorder'
    """
    if order == 'preorder':
        preorder_traversal(node, action=func)
    elif order == 'inorder':
        inorder_traversal(node, action=func)
    elif order == 'postorder':
        postorder_traversal(node, action=func)
    else:
        raise ValueError("Неподдерживаемый порядок обхода: " + order)

