from tn import *
from ntn import *


# Тестирование функций
def test_binary_tree():
    print("=== Тестирование двоичного дерева ===")
    # Пример дерева:
    #        1
    #       / \
    #      2   3
    #     /   / \
    #    4   5   6
    node4 = TreeNode(4)
    node2 = TreeNode(2, left=node4)
    node5 = TreeNode(5)
    node6 = TreeNode(6)
    node3 = TreeNode(3, left=node5, right=node6)
    root = TreeNode(1, left=node2, right=node3)

    # Тест обходов
    print("Preorder (NLR):", preorder_traversal(root))
    print("Inorder (LNR):", inorder_traversal(root))
    print("Postorder (LRN):", postorder_traversal(root))

    # Применение функции: например, печать каждого узла
    print("Применение функции (печать узла) в порядке preorder:")
    apply_to_each_node(root, lambda n: print("Узел:", n.value), order='preorder')

    # Подсчёт узлов и глубина
    print("Количество узлов:", count_nodes(root))
    print("Глубина дерева:", tree_depth(root))

    # Печать дерева
    print("Печать дерева:")
    print_tree(root)

    # Удаление дерева (разрыв связей)
    delete_tree(root)
    print("После удаления (обход должен вернуть пустой список):", preorder_traversal(root))

def test_edge_cases():
    print("\n=== Тест крайних случаев ===")
    # Пустое дерево
    empty_root = None
    print("Пустое дерево, preorder:", preorder_traversal(empty_root))
    print("Пустое дерево, количество узлов:", count_nodes(empty_root))
    print("Пустое дерево, глубина:", tree_depth(empty_root))

    # Дерево из одного узла
    single_node = TreeNode(100)
    print("Одиночный узел, preorder:", preorder_traversal(single_node))
    print("Одиночный узел, количество узлов:", count_nodes(single_node))
    print("Одиночный узел, глубина:", tree_depth(single_node))
    print("Печать одиночного узла:")
    print_tree(single_node)

    # Вырожденное дерево (каждый узел имеет только правого потомка)
    degenerate = TreeNode(1)
    current = degenerate
    for i in range(2, 6):
        current.right = TreeNode(i)
        current = current.right
    print("Вырожденное дерево, preorder:", preorder_traversal(degenerate))
    print("Вырожденное дерево, количество узлов:", count_nodes(degenerate))
    print("Вырожденное дерево, глубина:", tree_depth(degenerate))
    print("Печать вырожденного дерева:")
    print_tree(degenerate)

def test_nary_tree():
    print("\n=== Тестирование n-арного (иерархического) дерева ===")
    # Пример n-арного дерева:
    #          'A'
    #         / | \
    #       'B''C''D'
    #           |
    #          'E'
    nodeB = NaryTreeNode('B')
    nodeE = NaryTreeNode('E')
    nodeC = NaryTreeNode('C', children=[nodeE])
    nodeD = NaryTreeNode('D')
    root = NaryTreeNode('A', children=[nodeB, nodeC, nodeD])

    print("Preorder обход n-арного дерева:", nary_preorder_traversal(root))
    print("Количество узлов n-арного дерева:", nary_count_nodes(root))
    print("Глубина n-арного дерева:", nary_tree_depth(root))

    # Пример применения функции: печать каждого узла
    print("Применение функции (печать узла) для n-арного дерева:")
    nary_preorder_traversal(root, action=lambda n: print("Узел:", n.value))