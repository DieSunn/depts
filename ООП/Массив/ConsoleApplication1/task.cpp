#include "task.h"
#include <fstream>
#include <cstdlib>
#include <ctime>

using namespace std;

namespace MyModule {

	// Функция для заполнения вектора случайными числами
	void fillArrayRandom(vector<int>& numbers) {
		for (int& num : numbers) {
			num = rand() % 25;  // Заполняем каждый элемент вектора случайным числом от 0 до 24
		}
	}

	// Функция для вычисления суммы элементов вектора
	int calculateSum(const vector<int>& numbers) {
		int sum = 0;

		for (const int& num : numbers) {
			sum += abs(num);  // Добавляем абсолютное значение каждого числа к сумме
		}

		return sum;  // Возвращаем итоговую сумму
	}

	// Функция для записи результата в файл
	void writeToOutputFile(const string& filename, int result) {
		ofstream outputFile(filename);  // Открываем файл для записи

		if (!outputFile.is_open()) {  // Если файл не удалось открыть, выбрасываем исключение
			throw runtime_error("Unable to open the output file.");
		}

		outputFile << "Result: " << result << endl;  // Записываем результат в файл
		outputFile.close();  // Закрываем файл
	}

	// Функция для чтения массива из файла
	void readArrayFromFile(const string& filename, vector<int>& numbers) {
		ifstream inputFile(filename);  // Открываем файл для чтения

		if (!inputFile.is_open()) {  // Если файл не удалось открыть, выбрасываем исключение
			throw runtime_error("");
		}

		numbers.clear();  // Очищаем вектор перед заполнением

		int num;
		while (inputFile >> num) {  // Читаем числа из файла и добавляем их в вектор
			numbers.push_back(num);
		}

		inputFile.close();  // Закрываем файл
	}

	// Функция для записи массива в файл
	void writeArrayToFile(const string& filename, vector<int>& numbers) {
		ofstream outputFile(filename);  // Открываем файл для записи

		if (!outputFile.is_open()) {  // Если файл не удалось открыть, выбрасываем исключение
			throw runtime_error("");
		}

		for (const int& num : numbers) {  // Записываем каждое число из вектора в файл
			outputFile << num << " ";
		}

		outputFile.close();  // Закрываем файл
	}
}
