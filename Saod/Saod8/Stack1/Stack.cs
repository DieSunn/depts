﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

    public class Stack<T> // Объявляем класс стэка с использованием обобщений
    {
        private T[] items; // Массив для хранения элементов стэка
        private int top; // Индекс верхнего элемента стэка
    private int count; // Количество элементов в стеке

    public Stack(int size=10) // Конструктор, который принимает размер стэка
        {
            items = new T[size]; // Инициализируем массив заданным размером
            top = -1; // Устанавливаем индекс верхнего элемента в -1, чтобы указать на пустой стэк
        }

        public void Push(T item) // Метод для добавления элемента в стэк
        {
            if (top == items.Length - 1) // Проверяем, полон ли стэк
            {
                throw new Exception("Stack overflow"); // Если стэк полон, выбрасываем исключение
            }

            top++; // Увеличиваем индекс верхнего элемента на 1
            items[top] = item; // Добавляем элемент на вершину стэка
        count++; // Увеличиваем количество элементов на 1

    }

    public T Pop() // Метод для удаления и возврата верхнего элемента стэка
        {
            if (top == -1) // Проверяем, пуст ли стэк
            {
                throw new Exception("Stack underflow"); // Если стэк пуст, выбрасываем исключение
            }

            T item = items[top]; // Сохраняем верхний элемент стэка в переменную
            top--; // Уменьшаем индекс верхнего элемента на 1
        count--; // Уменьшаем количество элементов на 1

        return item; // Возвращаем удаленный элемент
        }

        public T Peek() // Метод для просмотра верхнего элемента стэка без удаления
        {
            if (top == -1) // Проверяем, пуст ли стэк
            {
                throw new Exception("Stack is empty"); // Если стэк пуст, выбрасываем исключение
            }

            return items[top]; // Возвращаем верхний элемент стэка
        }

        public bool IsEmpty() // Метод для проверки, пуст ли стэк
        {
            return (top == -1); // Возвращаем true, если индекс верхнего элемента равен -1 (то есть, стэк пуст)
        }

        public bool IsFull() // Метод для проверки, полон ли стэк
        {
            return (top == items.Length - 1); // Возвращаем true, если индекс верхнего элемента равен длине массива - 1 (то есть, стэк полон)
        }

    public int Count() // Метод для получения количества элементов в стеке
    {
        return count; // Возвращаем текущее количество элементов
    }

}


