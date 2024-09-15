#ifndef MYMODULE_H  // Проверяем, определено ли MYMODULE_H
#define MYMODULE_H  // Если нет, то определяем его. Это предотвращает повторное включение этого заголовочного файла.

#include <vector>  // Включаем заголовочный файл для работы с векторами
#include <string>  // Включаем заголовочный файл для работы со строками

using namespace std;  // Используем пространство имен std для упрощения кода

namespace MyModule {  // Объявляем пространство имен MyModule

	// Объявляем функцию для заполнения вектора случайными числами
	void fillArrayRandom(vector<int>& numbers);

	// Объявляем функцию для вычисления суммы элементов вектора
	int calculateSum(const vector<int>& numbers);

	// Объявляем функцию для записи результата в файл
	void writeToOutputFile(const string& filename, int result);

	// Объявляем функцию для чтения массива из файла
	void readArrayFromFile(const string& filename, vector<int>& numbers);

	// Объявляем функцию для записи массива в файл
	void writeArrayToFile(const string& filename, vector<int>& numbers);
}

#endif // !MYMODULE_H  // Заканчиваем условную компиляцию
