import matplotlib.pyplot as plt
import networkx as nx
import pydot

class Node:
    def __init__(self, key):
        self.key = key
        self.parent = None
        self.left = None
        self.right = None

class SplayTree:
    def __init__(self):
        self.root = None

    def _left_rotate(self, x):
        y = x.right
        x.right = y.left
        if y.left:
            y.left.parent = x
        y.parent = x.parent
        if not x.parent:
            self.root = y
        elif x == x.parent.left:
            x.parent.left = y
        else:
            x.parent.right = y
        y.left = x
        x.parent = y

    def _right_rotate(self, x):
        y = x.left
        x.left = y.right
        if y.right:
            y.right.parent = x
        y.parent = x.parent
        if not x.parent:
            self.root = y
        elif x == x.parent.left:
            x.parent.left = y
        else:
            x.parent.right = y
        y.right = x
        x.parent = y

    def _splay(self, x):
        while x.parent:
            if not x.parent.parent:
                if x == x.parent.left:
                    self._right_rotate(x.parent)
                else:
                    self._left_rotate(x.parent)
            elif x == x.parent.left and x.parent == x.parent.parent.left:
                self._right_rotate(x.parent.parent)
                self._right_rotate(x.parent)
            elif x == x.parent.right and x.parent == x.parent.parent.right:
                self._left_rotate(x.parent.parent)
                self._left_rotate(x.parent)
            elif x == x.parent.right and x.parent == x.parent.parent.left:
                self._left_rotate(x.parent)
                self._right_rotate(x.parent)
            else:
                self._right_rotate(x.parent)
                self._left_rotate(x.parent)

    def insert(self, key):
        node = Node(key)
        y = None
        x = self.root
        while x:
            y = x
            if node.key < x.key:
                x = x.left
            else:
                x = x.right

        node.parent = y
        if not y:
            self.root = node
        elif node.key < y.key:
            y.left = node
        else:
            y.right = node

        self._splay(node)

    def find(self, key):
        x = self.root
        while x:
            if key < x.key:
                x = x.left
            elif key > x.key:
                x = x.right
            else:
                self._splay(x)
                return x
        return None

    def get_nodes_and_edges(self):
        nodes = []
        edges = []

        def traverse_and_collect(node):
            if node:
                nodes.append(node.key)
                if node.left:
                    edges.append((node.key, node.left.key))
                    traverse_and_collect(node.left)
                if node.right:
                    edges.append((node.key, node.right.key))
                    traverse_and_collect(node.right)

        traverse_and_collect(self.root)
        return nodes, edges

    def visualize(self, filename="splay_tree"):
        nodes, edges = self.get_nodes_and_edges()

        if not nodes:
            print("Дерево пустое, нечего визуализировать.")
            return

        G = nx.DiGraph()
        G.add_nodes_from(nodes)
        G.add_edges_from(edges)

        # Создание объекта Graphviz
        dot_graph = nx.drawing.nx_pydot.to_pydot(G)

       # Настройка внешнего вида узлов (например, формы, цвета)
        for pydot_node in dot_graph.get_nodes():
            pydot_node.set_shape("circle")
            pydot_node.set_style("filled")
            pydot_node.set_fillcolor("lightblue")

        try:
            dot_graph.write_png(f"{filename}.png")
            print(f"Визуализация сохранена в {filename}.png")
        except Exception as e:
            print(f"Ошибка при сохранении визуализации: {e}")
            print("Убедитесь, что Graphviz установлен и доступен в PATH.")

if __name__ == "__main__":
    splay_tree = SplayTree()
    values_to_insert = [10, 5, 15, 2, 7, 12, 17]
    for i, value in enumerate(values_to_insert):
        print(f"Вставляем: {value}")
        splay_tree.insert(value)
        splay_tree.visualize(f"splay_tree_insert_{i+1}")

    print("\nПоиск 7:")
    splay_tree.find(7)
    splay_tree.visualize("splay_tree_find_7")

    print("\nПоиск 15:")
    splay_tree.find(15)
    splay_tree.visualize("splay_tree_find_15")