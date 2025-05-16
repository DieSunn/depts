import networkx as nx
import matplotlib.pyplot as plt
import time
import aiofiles
import asyncio

# 1. Загрузка графа
G = nx.read_edgelist("facebook_combined.txt", nodetype=int)

print("Узлов:", G.number_of_nodes(), " Рёбер:", G.number_of_edges())

# 2. Degree и Closeness — точно, быстро
deg_centrality    = nx.degree_centrality(G)
closeness         = nx.closeness_centrality(G)

# 3. Betweenness — ПРИБЛИЖЁННО, с выборкой k узлов
k = 100           # число опорных вершин для выборки
start = time.time()
betweenness_approx = nx.betweenness_centrality(G, k=k, seed=42)
print(f"Betweenness (approxx k={k}) рассчитан за {time.time() - start:.2f} с")

# 4. Записываем атрибуты в граф
nx.set_node_attributes(G, deg_centrality,       "degree")
nx.set_node_attributes(G, closeness,            "closeness")
nx.set_node_attributes(G, betweenness_approx,   "betweenness")

# 5. Кластеры (связные компоненты)
components = list(nx.connected_components(G))
comp_map = {}
for i, comp in enumerate(components):
    for n in comp:
        comp_map[n] = i
colors = [comp_map[n] for n in G.nodes()]

# 6. Визуализация
plt.figure(figsize=(10, 8))
pos = nx.spring_layout(G, seed=1)

node_sizes = [3000 * deg_centrality[n] for n in G]
nx.draw_networkx_nodes(G, pos,
                       node_size=node_sizes,
                       node_color=colors,
                       cmap=plt.cm.Set3,
                       alpha=0.8)
nx.draw_networkx_edges(G, pos, alpha=0.2)
nx.draw_networkx_labels(G, pos, font_size=7)
plt.title(f"Graph: size∼degree, color∼component, betweenness≈k={k}")
plt.axis("off")
plt.show()

# 7. Топ‑5 узлов по каждой метрике
def top5(metric, name):
    items = sorted(metric.items(), key=lambda x: x[1], reverse=True)[:5]
    print(f"\nTop‑5 по {name}:")
    for node, val in items:
        print(f"  Узел {node}: {val:.4f}")

top5(deg_centrality,  "Degree Centrality")
top5(closeness,       "Closeness Centrality")
top5(betweenness_approx, "Betweenness Centrality (approx)")

nx.write_graphml(G, "graph.graphml")
print("GraphML сохранён в graph.graphml")
