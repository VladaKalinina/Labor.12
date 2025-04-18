using Plants;
using System;

namespace Lab12
{
    public class Program
    {
        static MyList<Plant> list = new MyList<Plant>(); // Хранит двунаправленный список растений
        static bool isListCreated = false; // Указывает, создан ли список

        static void PrintMainMenu()
        {
            Console.WriteLine("-----------------------------------МЕНЮ-----------------------------------"); // Выводит заголовок главного меню
            Console.WriteLine("1) Создать двунаправленный список");
            Console.WriteLine("2) Выход");
            Console.WriteLine("-----------------------------------ВЫХОД-----------------------------------");
        }

        static void PrintSubMenu()
        {
            Console.WriteLine("-----------------------------------ПОДМЕНЮ-----------------------------------"); // Выводит заголовок подменю
            Console.WriteLine("1) Распечатать список");
            Console.WriteLine("2) Удалить элементы по имени");
            Console.WriteLine("3) Добавить K элементов в начало");
            Console.WriteLine("4) Выполнить глубокое клонирование списка");
            Console.WriteLine("5) Удалить список из памяти");
            Console.WriteLine("6) Выход");
            Console.WriteLine("-----------------------------------ВЫХОД-----------------------------------");
        }

        static void Main(string[] args)
        {
            bool exit = false; // Флаг для выхода из программы
            while (!exit)
            {
                if (!isListCreated)
                {
                    PrintMainMenu(); // Показывает главное меню, если список не создан
                    Console.Write("Выберите действие (1-2): ");
                    char choice = Console.ReadKey().KeyChar; // Считывает выбор пользователя
                    Console.WriteLine();
                    switch (choice)
                    {
                        case '1':
                            CreateList(); // Создает новый список
                            break;
                        case '2':
                            exit = true; // Завершает программу
                            Console.WriteLine("Программа завершена.");
                            break;
                        default:
                            Console.WriteLine("Неверный ввод. Пожалуйста, выберите 1 или 2.");
                            break;
                    }
                }
                else
                {
                    PrintSubMenu(); // Показывает подменю для работы со списком
                    Console.Write("Выберите действие (1-6): ");
                    char choice = Console.ReadKey().KeyChar; // Считывает выбор действия
                    Console.WriteLine();
                    switch (choice)
                    {
                        case '1':
                            PrintList(); // Выводит содержимое списка
                            break;
                        case '2':
                            RemoveByName(); // Удаляет элементы по имени
                            break;
                        case '3':
                            AddKToStart(); // Добавляет элементы в начало
                            break;
                        case '4':
                            DeepCopyList(); // Клонирует список
                            break;
                        case '5':
                            DeleteList(); // Удаляет список
                            break;
                        case '6':
                            exit = true; // Завершает программу
                            Console.WriteLine("Программа завершена.");
                            break;
                        default:
                            Console.WriteLine("Неверный ввод. Пожалуйста, выберите действие от 1 до 6.");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        static void CreateList()
        {
            Console.WriteLine("Введите желаемую длину списка:");
            if (!int.TryParse(Console.ReadLine(), out int length) || length < 0) // Проверяет корректность ввода длины
            {
                Console.WriteLine("Некорректный ввод длины списка.");
                return;
            }

            Random rnd = new Random(); // Генератор случайных чисел
            if (length == 0)
            {
                Console.WriteLine("Пустой список успешно создан!");
                isListCreated = true; // Отмечает, что список создан
                return;
            }

            for (int i = 0; i < length; i++)
            {
                int objectType = rnd.Next(1, 5); // Выбирает случайный тип объекта (1-4)
                switch (objectType)
                {
                    case 1:
                        Plant plant = new Plant(); // Создает объект Plant
                        plant.RandomInit(); // Инициализирует случайными данными
                        list.Add(plant); // Добавляет в список
                        break;
                    case 2:
                        Tree tree = new Tree(); // Создает объект Tree
                        tree.RandomInit();
                        list.Add(tree);
                        break;
                    case 3:
                        Flower flower = new Flower(); // Создает объект Flower
                        flower.RandomInit();
                        list.Add(flower);
                        break;
                    case 4:
                        Rose rose = new Rose(); // Создает объект Rose
                        rose.RandomInit();
                        list.Add(rose);
                        break;
                }
            }
            Console.WriteLine($"Список длиной {length} успешно создан!");
            isListCreated = true;
        }

        static void PrintList()
        {
            if (!isListCreated || list.Count == 0) // Проверяет, создан ли список и не пуст ли он
            {
                Console.WriteLine("Список пуст или не был создан, выводить нечего ;(");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Содержимое списка:");
            Point<Plant>? current = list.beg; // Начинает с первого элемента списка
            while (current != null)
            {
                Console.WriteLine(current.Data?.ToString() ?? "null"); // Выводит данные элемента
                current = current.Next; // Переходит к следующему элементу
            }
        }

        static void RemoveByName()
        {
            if (!isListCreated) // Проверяет, создан ли список
            {
                Console.WriteLine("Список не был создан. Пожалуйста, создайте и заполните его.");
                return;
            }
            Console.WriteLine("Введите имя для удаления:");
            string name = Console.ReadLine(); // Считывает имя для удаления
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Некорректный ввод имени.");
                return;
            }
            list.RemoveByName(name); // Удаляет элементы с указанным именем
        }

        static void AddKToStart()
        {
            if (!isListCreated) // Проверяет, создан ли список
            {
                Console.WriteLine("Список не был создан. Пожалуйста, создайте и заполните его.");
                return;
            }
            Console.WriteLine("Введите количество элементов для добавления:");
            if (!int.TryParse(Console.ReadLine(), out int k) || k < 0) // Проверяет корректность ввода K
            {
                Console.WriteLine("Некорректный ввод количества.");
                return;
            }
            list.AddKToStart(k); // Добавляет K элементов в начало
        }

        static void DeepCopyList()
        {
            if (!isListCreated) // Проверяет, создан ли список
            {
                Console.WriteLine("Список не был создан, копировать нечего ;(");
                return;
            }
            MyList<Plant> clonedList = list.DeepCopyList(); // Создает глубокую копию списка
            Console.WriteLine("Исходный список:");
            PrintList(); // Выводит исходный список
            Console.WriteLine("Склонированный список:");
            Point<Plant>? current = clonedList.beg; // Начинает с первого элемента копии
            while (current != null)
            {
                Console.WriteLine(current.Data?.ToString() ?? "null"); // Выводит данные элемента копии
                current = current.Next;
            }
        }

        static void DeleteList()
        {
            if (!isListCreated) // Проверяет, создан ли список
            {
                Console.WriteLine("Список не был создан.");
                return;
            }
            list.DeleteList(); // Удаляет список из памяти
            isListCreated = false; // Сбрасывает флаг создания списка
            Console.WriteLine("Список успешно удален из памяти.");
        }
    }
}