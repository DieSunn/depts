﻿#include <iostream>
#include <cassert>
#include <fstream>
#include "task.h"

using namespace std;
using namespace MyModule; // Пространство имен модуля

int main() {
	///Ввод размера массива
	try {
		// Размер массива
		int n;
		cout << "Введите количество элементов: ";
		cin >> n;

		// Проверка на положительное значение n
		if (n <= 0) {
			throw invalid_argument("n не может быть меньше 0");
		}

		// Динамический массив чисел
		vector<int> numbers(n);

		// Рандомное заполнение массива
		fillArrayRandom(numbers);

		// Проверка, что массив не пустой
		assert(!numbers.empty());

		cout << "Сгенерирован массив из " << n << " целых чисел: " << endl;
		for (const int& num : numbers) {
			cout << num << " ";
		}
		cout << endl;

		// Запись введенного массива в файл
		writeArrayToFile("input.txt", numbers);

		// Чтение массива из файла
		vector<int> inputFileNumbers;
		readArrayFromFile("input.txt", inputFileNumbers);

		// Проверка на соответствие введенного и файла
		assert(numbers == inputFileNumbers);

		// Вычисление суммы абсолютных значений чисел
		int result = calculateSum(numbers);

		// Проверка суммы по формуле
		assert(result == calculateSum(numbers));

		// Запись результата в файл
		writeToOutputFile("output.txt", result);

		// Проверка, что файл с результатом успешно записан
		ifstream outFile("output.txt");
		assert(outFile.is_open());

		cout << "Вычисления выполнены. Результат записан в файле output.txt." << endl;

	}
	catch (const exception& e) {
		// Обработка и вывод ошибок
		cerr << "Ошибка: " << e.what() << endl;
		return 1;
	}

	return 0;
}