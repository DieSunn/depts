import networkx as nx
import matplotlib.pyplot as plt

class TreeNode:
    def __init__(self, value):
        self.value = value
        self.left = None
        self.right = None

    def __repr__(self):
        return f"TreeNode({self.value})"

def create_tree():
    """Создаёт бинарное дерево из 5 узлов."""
    root = TreeNode(1)
    root.left = TreeNode(2)
    root.right = TreeNode(3)
    root.left.left = TreeNode(4)
    root.left.right = TreeNode(5)
    return root

def tree_to_graph(root):
    """Преобразует бинарное дерево в ориентированный граф networkx."""
    G = nx.DiGraph()
    def add_edges(node):
        if node:
            if node.left:
                G.add_edge(node.value, node.left.value)
                add_edges(node.left)
            if node.right:
                G.add_edge(node.value, node.right.value)
                add_edges(node.right)
    add_edges(root)
    return G

def hierarchy_pos(G, root, width=1.0, vert_gap=0.2, vert_loc=0, xcenter=0.5):
    pos = {root: (xcenter, vert_loc)}
    children = list(G.neighbors(root))
    if children:
        dx = width / len(children)
        nextx = xcenter - width / 2 - dx/2
        for child in children:
            nextx += dx
            pos.update(hierarchy_pos(G, child, width=dx, vert_gap=vert_gap,
                                       vert_loc=vert_loc - vert_gap, xcenter=nextx))
    return pos

def visualize_tree(root):
    """Визуализирует дерево в классическом виде сверху вниз."""
    G = tree_to_graph(root)
    pos = hierarchy_pos(G, root.value, width=1.0, vert_gap=0.2, vert_loc=0, xcenter=0.5)
    plt.figure(figsize=(8, 6))
    nx.draw(G, pos, with_labels=True, arrows=False,
            node_size=2000, node_color='lightblue', font_size=10)
    plt.title("Визуализация бинарного дерева")
    plt.show()

def find_node(root, value):
    """Ищет узел с заданным значением в бинарном дереве."""
    if root is None:
        return None
    if root.value == value:
        return root
    left_search = find_node(root.left, value)
    return left_search if left_search else find_node(root.right, value)

def delete_tree(root):
    """Удаляет дерево, обнуляя ссылки на потомков."""
    root.left = None
    root.right = None