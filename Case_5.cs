using System;
using System.Collections.Generic;

namespace StudentApp
{
    public class Student
    {    
        // Приватные поля
        private string _name;
        private int _age;
        private double _averageGrade;

        // Свойства
        public string Name
        {
            get { return _name; }
            set 
            { 
                if (!string.IsNullOrWhiteSpace(value))
                    _name = value;
                else
                    Console.WriteLine("Ошибка: Имя не может быть пустым.");
            }
        }

        public int Age
        {
            get { return _age; }
            set 
            { 
                // Проверка корректности возраста
                if (value >= 16 && value <= 100)
                {
                    _age = value;
                }
                else
                {
                    // Вывод в чьей карточке ошибка
                    Console.WriteLine($"[ОШИБКА] В карточке ({_name ?? "Неизвестный"}): Возраст {value} недопустим. Ожидается от 16 до 100.");
                }
            }
        }

        public double AverageGrade
        {
            get { return _averageGrade; }
            set 
            { 
                // Проверка корректности балла
                if (value >= 0 && value <= 10)
                {
                    _averageGrade = value;
                }
                else
                {
                    // Вывод в чьей карточке ошибка
                    Console.WriteLine($"[ОШИБКА] В карточке ({_name ?? "Неизвестный"}): Балл {value} недопустим. Ожидается от 0 до 10.");
                }
            }
        }

        public List<string> Courses { get; private set; }

        public Student(string name, int age, double averageGrade)
        {
            // Устанавливаем первым имя, чтобы при ошибке в возрасте или балле консоль могла вывести имя студента, где ошибка
            Name = name;
            Age = age;
            AverageGrade = averageGrade;
            Courses = new List<string>();
        }

        // Подсчет оценки
        public string GetPerformanceStatus()
        {
            if (_averageGrade > 8) return "Отлично";
            if (_averageGrade >= 6) return "Хорошо";
            if (_averageGrade >= 4) return "Удовлетворительно";
            return "Неудовлетворительно";
        }

        // Запись на курс (доп. функция)
        public void EnrollCourse(string courseName)
        {
            Courses.Add(courseName);
            Console.WriteLine($"[ИНФО] Студент {Name} записан на курс: {courseName}");
        }

        // Вывод полной информации
        public void DisplayInfo()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($" Студент:      {Name}");
            Console.WriteLine($" Возраст:      {Age}");
            Console.WriteLine($" Средний балл: {AverageGrade:F1} ({GetPerformanceStatus()})");
            
            if (Courses.Count > 0)
                Console.WriteLine($" Курсы:        {string.Join(", ", Courses)}");
            else
                Console.WriteLine($" Курсы:        Нет активных курсов");
                
            Console.WriteLine("-----------------------------");
        }
    }

    // Основная программа
  
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Данные о студентах:\n");

            //Создание объектов
            Student alexey = new Student("Алексей Петров", 20, 7.5); 
            Student maria = new Student("Мария Иванова", 19, 3.8);   
            Student dmitry = new Student("Дмитрий Сидоров", 18, 9.9); 

            // Вывод объектов
            Console.WriteLine("Общий список студентов:");
            alexey.DisplayInfo();
            maria.DisplayInfo();
            dmitry.DisplayInfo();

            // Изменяем данные Марии, добавляя Курс Основы С# 
            Console.WriteLine("\nИзменение данных Марии:");
            maria.AverageGrade = 6.0; 
            maria.EnrollCourse("Основы C#");
            maria.DisplayInfo();

            // Изменяем данные Дмитрия на некорректные
            Console.WriteLine("\nИзменение данных Дмитрия:");
            dmitry.Age = 1500; 
            dmitry.AverageGrade = -5.0;
            dmitry.AverageGrade = 15.5;
            dmitry.DisplayInfo();

            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}