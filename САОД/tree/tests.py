from Treenode import *

def test():
    tree = create_tree()
    visualize_tree(tree)
    print("Содержимое узла 2:", find_node(tree, 2))
    delete_tree(tree)
    print("Дерево удалено.")
