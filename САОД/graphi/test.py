def bubble_sort(arr):
  n = len(arr)

  for i in range(n):
    swapped = False

    for j in range(n - 1 - i):
      if arr[j] > arr[j+1]:
        arr[j], arr[j+1] = arr[j+1], arr[j]
        swapped = True 

    if not swapped:
      break

  return arr

# Пример использования:
my_list = [64, 34, 25, 12, 22, 11, 90]

print("Исходный список:", my_list)

sorted_list = bubble_sort(my_list)

print("Отсортированный список:", sorted_list)
