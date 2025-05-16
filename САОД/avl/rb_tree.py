import matplotlib.pyplot as plt
import networkx as nx
import pydot

# Определение цветов для узлов
RED = "red"
BLACK = "black"

class Node:
    def __init__(self, key, color=RED, parent=None, left=None, right=None):
        self.key = key
        self.color = color
        self.parent = parent
        self.left = left
        self.right = right

class RedBlackTree:
    def __init__(self):
        self.NIL = Node(None, color=BLACK) # Листья NIL всегда черные
        self.root = self.NIL

    def insert(self, key):
        """Вставляет новый узел с заданным ключом."""
        new_node = Node(key, parent=None, left=self.NIL, right=self.NIL)
        parent = None
        current = self.root

        # Обычная вставка как в бинарное дерево поиска
        while current != self.NIL:
            parent = current
            if new_node.key < current.key:
                current = current.left
            else:
                current = current.right

        new_node.parent = parent
        if parent is None:
            self.root = new_node
        elif new_node.key < parent.key:
            parent.left = new_node
        else:
            parent.right = new_node

        # Восстановление свойств красно-черного дерева
        self._fix_insert(new_node)

    def _fix_insert(self, k):
        """Восстанавливает свойства красно-черного дерева после вставки."""
        while k.parent.color == RED:
            if k.parent == k.parent.parent.left:
                u = k.parent.parent.right # Дядя
                if u.color == RED:
                    # Случай 1: Дядя красный
                    k.parent.color = BLACK
                    u.color = BLACK
                    k.parent.parent.color = RED
                    k = k.parent.parent
                else:
                    # Случай 2: Дядя черный, текущий узел - правый потомок
                    if k == k.parent.right:
                        k = k.parent
                        self._left_rotate(k)
                    # Случай 3: Дядя черный, текущий узел - левый потомок
                    k.parent.color = BLACK
                    k.parent.parent.color = RED
                    self._right_rotate(k.parent.parent)
            else:
                u = k.parent.parent.left # Дядя
                if u.color == RED:
                    # Случай 4: Дядя красный
                    k.parent.color = BLACK
                    u.color = BLACK
                    k.parent.parent.color = RED
                    k = k.parent.parent
                else:
                    # Случай 5: Дядя черный, текущий узел - левый потомок
                    if k == k.parent.left:
                        k = k.parent
                        self._right_rotate(k)
                    # Случай 6: Дядя черный, текущий узел - правый потомок
                    k.parent.color = BLACK
                    k.parent.parent.color = RED
                    self._left_rotate(k.parent.parent)
        self.root.color = BLACK # Корень всегда черный

    def _left_rotate(self, x):
        """Выполняет левый поворот вокруг узла x."""
        y = x.right
        x.right = y.left
        if y.left != self.NIL:
            y.left.parent = x
        y.parent = x.parent
        if x.parent is None:
            self.root = y
        elif x == x.parent.left:
            x.parent.left = y
        else:
            x.parent.right = y
        y.left = x
        x.parent = y

    def _right_rotate(self, y):
        """Выполняет правый поворот вокруг узла y."""
        x = y.left
        y.left = x.right
        if x.right != self.NIL:
            x.right.parent = y
        x.parent = y.parent
        if y.parent is None:
            self.root = x
        elif y == y.parent.right:
            y.parent.right = x
        else:
            y.parent.left = x
        x.right = y
        y.parent = x

    def inorder_traversal(self, node):
        """Обход дерева в порядке возрастания."""
        if node != self.NIL:
            self.inorder_traversal(node.left)
            print(node.key, node.color)
            self.inorder_traversal(node.right)

    def get_nodes_and_edges(self):
        """Возвращает списки узлов и ребер для визуализации."""
        nodes = []
        edges = []
        colors = []

        def traverse_and_collect(node):
            if node != self.NIL:
                nodes.append(node.key)
                colors.append(node.color)
                if node.left != self.NIL:
                    edges.append((node.key, node.left.key))
                    traverse_and_collect(node.left)
                if node.right != self.NIL:
                    edges.append((node.key, node.right.key))
                    traverse_and_collect(node.right)

        traverse_and_collect(self.root)
        return nodes, edges, colors

    def visualize(self, filename="rb_tree"):
        """Визуализирует дерево с использованием networkx и Graphviz."""
        nodes, edges, colors = self.get_nodes_and_edges()

        if not nodes:
            print("Дерево пустое, нет узлов для визуализации.")
            return

        G = nx.DiGraph()

        for node, color in zip(nodes, colors):
            G.add_node(node, color=color)

        G.add_edges_from(edges)

        # Создание объекта Graphviz
        dot_graph = nx.drawing.nx_pydot.to_pydot(G)

        # Установка цветов узлов в Graphviz
        for pydot_node in dot_graph.get_nodes():
            node_name = pydot_node.get_name().strip('"') # Получаем имя узла
            try:
                node_color = G.nodes[int(node_name)]['color'] # Получаем цвет из networkx графа
                pydot_node.set_fillcolor(node_color)
                pydot_node.set_style("filled")
                pydot_node.set_fontcolor("white" if node_color == BLACK else "black") # Белый текст на черном фоне, черный на красном
            except ValueError:
                # Обработка случая, если имя узла не является числом
                 node_color = G.nodes[node_name]['color']
                 pydot_node.set_fillcolor(node_color)
                 pydot_node.set_style("filled")
                 pydot_node.set_fontcolor("white" if node_color == BLACK else "black")


        # Сохранение в файл изображения (например, PNG)
        try:
            dot_graph.write_png(f"{filename}.png")
            print(f"Визуализация сохранена в {filename}.png")
        except Exception as e:
            print(f"Ошибка при сохранении визуализации: {e}")
            print("Убедитесь, что Graphviz установлен и доступен в PATH.")


# Пример использования:
if __name__ == "__main__":
    rb_tree = RedBlackTree()
    import random

    # Вставляем случайные числа и визуализируем после каждой вставки
    # for i in range(10):
    #     value = random.randint(1, 100)
    #     print(f"Вставляем: {value}")
    #     rb_tree.insert(value)
    #     rb_tree.visualize(f"rb_tree_insert_{i+1}")

    # Вставляем фиксированный набор чисел для демонстрации балансировки
    values_to_insert = [10, 20, 30, 40, 50, 25]
    for i, value in enumerate(values_to_insert):
        print(f"Вставляем: {value}")
        rb_tree.insert(value)
        rb_tree.visualize(f"rb_tree_insert_{i+1}")

    print("\nОбход дерева (inorder):")
    rb_tree.inorder_traversal(rb_tree.root)