# Бонус: реализация узлов с произвольным числом потомков (n-арное дерево)
class NaryTreeNode:
    def __init__(self, value, children=None):
        """
        Инициализация узла n-арного дерева.
        :param value: значение узла
        :param children: список потомков (список объектов NaryTreeNode)
        """
        self.value = value
        self.children = children if children is not None else []

def nary_preorder_traversal(node, action=None, result=None):
    """
    Обход n-арного дерева в порядке pre-order.
    :param node: текущий узел (NaryTreeNode)
    :param action: функция, применяемая к узлу
    :param result: список для накопления значений
    :return: список значений узлов в порядке обхода
    """
    if result is None:
        result = []
    if node is None:
        return result
    if action:
        action(node)
    result.append(node.value)
    for child in node.children:
        nary_preorder_traversal(child, action, result)
    return result

def nary_count_nodes(node):
    """
    Подсчёт числа узлов в n-арном дереве.
    :param node: текущий узел (NaryTreeNode)
    :return: количество узлов
    """
    if node is None:
        return 0
    count = 1
    for child in node.children:
        count += nary_count_nodes(child)
    return count

def nary_tree_depth(node):
    """
    Определение глубины n-арного дерева.
    :param node: текущий узел (NaryTreeNode)
    :return: глубина дерева
    """
    if node is None or not node.children:
        return 1 if node is not None else 0
    return 1 + max(nary_tree_depth(child) for child in node.children)
