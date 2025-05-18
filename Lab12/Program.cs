﻿using Plants;
using System;

namespace Lab12
{
    public class Program
    {
        static MyList<Plant> list = new MyList<Plant>(); // Двусвязный список для растений
        static MyHashTable<int, Plant> hashTable = null!; // Хеш-таблица для растений
        static MyTree<Plant> tree = null!; // Бинарное дерево для растений
        static bool isListCreated = false; // Флаг создания списка
        static bool isHashTableCreated = false; // Флаг создания хеш-таблицы
        static bool isTreeCreated = false; // Флаг создания дерева

        static void PrintMainMenu() // Выводит главное меню
        {
            Console.WriteLine("-----------------------------------ГЛАВНОЕ МЕНЮ-----------------------------------");
            Console.WriteLine("1) Работа с двусвязным списком (Задание 1)");
            Console.WriteLine("2) Работа с хеш-таблицей (Задание 2)");
            Console.WriteLine("3) Работа с бинарным деревом (Задание 3)");
            Console.WriteLine("4) Выход");
            Console.WriteLine("-----------------------------------ВЫХОД-----------------------------------");
        }

        static void PrintListSubMenu() // Выводит подменю для списка
        {
            Console.WriteLine("-----------------------------------ПОДМЕНЮ СПИСКА-----------------------------------");
            Console.WriteLine("1) Создать двусвязный список");
            Console.WriteLine("2) Вывести список");
            Console.WriteLine("3) Удалить элементы по имени");
            Console.WriteLine("4) Добавить K элементов в начало");
            Console.WriteLine("5) Выполнить глубокое клонирование списка");
            Console.WriteLine("6) Удалить список из памяти");
            Console.WriteLine("7) Вернуться в главное меню");
            Console.WriteLine("-----------------------------------НАЗАД-----------------------------------");
        }

        static void PrintHashTableSubMenu() // Выводит подменю для хеш-таблицы
        {
            Console.WriteLine("-----------------------------------ПОДМЕНЮ ХЕШ-ТАБЛИЦЫ-----------------------------------");
            Console.WriteLine("1) Создать хеш-таблицу");
            Console.WriteLine("2) Вывести хеш-таблицу");
            Console.WriteLine("3) Найти элемент по ID");
            Console.WriteLine("4) Удалить элемент по ID");
            Console.WriteLine("5) Добавить элемент в хеш-таблицу");
            Console.WriteLine("6) Вернуться в главное меню");
            Console.WriteLine("-----------------------------------НАЗАД-----------------------------------");
        }

        static void PrintTreeSubMenu() // Выводит подменю для дерева
        {
            Console.WriteLine("-----------------------------------ПОДМЕНЮ ДЕРЕВА-----------------------------------");
            Console.WriteLine("1) Создать идеально сбалансированное дерево");
            Console.WriteLine("2) Вывести дерево");
            Console.WriteLine("3) Найти среднее арифметическое высоты деревьев");
            Console.WriteLine("4) Преобразовать в АВЛ-дерево поиска");
            Console.WriteLine("5) Удалить элемент по имени");
            Console.WriteLine("6) Удалить дерево из памяти");
            Console.WriteLine("7) Вернуться в главное меню");
            Console.WriteLine("-----------------------------------НАЗАД-----------------------------------");
        }

        static void Main(string[] args) // Главный метод программы
        {
            bool exit = false;
            while (!exit)
            {
                PrintMainMenu();
                Console.Write("Выберите действие (1-4): ");
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        HandleListMenu(); // Обрабатывает меню списка
                        break;
                    case '2':
                        HandleHashTableMenu(); // Обрабатывает меню хеш-таблицы
                        break;
                    case '3':
                        HandleTreeMenu(); // Обрабатывает меню дерева
                        break;
                    case '4':
                        exit = true;
                        Console.WriteLine("Программа завершена.");
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, выберите 1, 2, 3 или 4.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void HandleListMenu() // Обрабатывает подменю списка
        {
            bool back = false;
            while (!back)
            {
                if (!isListCreated)
                {
                    PrintListSubMenu();
                    Console.Write("Выберите действие (1 или 7): ");
                    char choice = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    switch (choice)
                    {
                        case '1':
                            CreateList();
                            break;
                        case '7':
                            back = true;
                            break;
                        default:
                            Console.WriteLine("Неверный ввод. Пожалуйста, выберите 1 или 7.");
                            break;
                    }
                }
                else
                {
                    PrintListSubMenu();
                    Console.Write("Выберите действие (1-7): ");
                    char choice = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    switch (choice)
                    {
                        case '1':
                            CreateList();
                            break;
                        case '2':
                            PrintList();
                            break;
                        case '3':
                            RemoveByName();
                            break;
                        case '4':
                            AddKToStart();
                            break;
                        case '5':
                            DeepCopyList();
                            break;
                        case '6':
                            DeleteList();
                            break;
                        case '7':
                            back = true;
                            break;
                        default:
                            Console.WriteLine("Неверный ввод. Пожалуйста, выберите 1-7.");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        static void HandleHashTableMenu() // Обрабатывает подменю хеш-таблицы
        {
            bool back = false;
            while (!back)
            {
                PrintHashTableSubMenu();
                Console.Write("Выберите действие (1-6): ");
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (choice)
                {
                    case '1':
                        CreateHashTable();
                        break;
                    case '2':
                        PrintHashTable();
                        break;
                    case '3':
                        FindElementById();
                        break;
                    case '4':
                        RemoveElementById();
                        break;
                    case '5':
                        AddElementToHashTable();
                        break;
                    case '6':
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, выберите 1-6.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void HandleTreeMenu() // Обрабатывает подменю дерева
        {
            bool back = false;
            while (!back)
            {
                PrintTreeSubMenu();
                Console.Write("Выберите действие (1-7): ");
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (choice)
                {
                    case '1':
                        CreateTree();
                        break;
                    case '2':
                        PrintTree();
                        break;
                    case '3':
                        FindAverageAge();
                        break;
                    case '4':
                        TransformToSearchTree();
                        break;
                    case '5':
                        RemoveElementByName();
                        break;
                    case '6':
                        DeleteTree();
                        break;
                    case '7':
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, выберите 1-7.");
                        break;
                }
                Console.WriteLine();
            }
        }

        // Методы для двусвязного списка
        static void CreateList()
        {
            Console.WriteLine("Введите желаемую длину списка:");
            if (!int.TryParse(Console.ReadLine(), out int length) || length < 0)
            {
                Console.WriteLine("Некорректный ввод длины списка.");
                return;
            }
            Random rnd = new Random();
            if (length == 0)
            {
                Console.WriteLine("Пустой список успешно создан!");
                isListCreated = true;
                return;
            }
            list = new MyList<Plant>(length);
            Console.WriteLine($"Список длиной {length} успешно создан!");
            isListCreated = true;
        }

        static void PrintList()
        {
            if (!isListCreated || list.Count == 0)
            {
                Console.WriteLine("Список пуст или не создан.");
                return;
            }
            Console.WriteLine("Содержимое списка:");
            foreach (var item in list)
            {
                Console.WriteLine(item?.ToString() ?? "null");
            }
        }

        static void RemoveByName()
        {
            if (!isListCreated)
            {
                Console.WriteLine("Список не создан. Пожалуйста, создайте и заполните его.");
                return;
            }
            Console.WriteLine("Введите имя для удаления:");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Некорректный ввод имени.");
                return;
            }
            int removed = list.RemoveByName(name);
            Console.WriteLine($"Удалено {removed} элементов с именем '{name}'.");
        }

        static void AddKToStart()
        {
            if (!isListCreated)
            {
                Console.WriteLine("Список не создан. Пожалуйста, создайте и заполните его.");
                return;
            }
            Console.WriteLine("Введите количество элементов для добавления:");
            if (!int.TryParse(Console.ReadLine(), out int k) || k < 0)
            {
                Console.WriteLine("Некорректный ввод количества.");
                return;
            }
            list.AddKToStart(k);
            Console.WriteLine($"Добавлено {k} элементов в начало списка.");
        }

        static void DeepCopyList()
        {
            if (!isListCreated)
            {
                Console.WriteLine("Список не создан, копировать нечего.");
                return;
            }
            MyList<Plant> clonedList = list.DeepCopyList();
            Console.WriteLine("Исходный список:");
            PrintList();
            Console.WriteLine("Склонированный список:");
            foreach (var item in clonedList)
            {
                Console.WriteLine(item?.ToString() ?? "null");
            }
        }

        static void DeleteList()
        {
            if (!isListCreated)
            {
                Console.WriteLine("Список не создан.");
                return;
            }
            list.DeleteList();
            isListCreated = false;
            Console.WriteLine("Список успешно удалён из памяти.");
        }

        // Методы для хеш-таблицы
        static void CreateHashTable()
        {
            Console.WriteLine("Введите количество объектов:");
            if (!int.TryParse(Console.ReadLine(), out int tableSize) || tableSize < 1)
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }
            hashTable = new MyHashTable<int, Plant>(tableSize);
            isHashTableCreated = true;
            Random rnd = new Random();
            for (int i = 0; i < tableSize; i++)
            {
                int objectType = rnd.Next(1, 5);
                Plant plant = objectType switch
                {
                    1 => new Plant(),
                    2 => new Tree(),
                    3 => new Flower(),
                    4 => new Rose(),
                    _ => new Plant()
                };
                plant.RandomInit();
                hashTable.AddItem(plant.Id.Number, plant);
            }
            Console.WriteLine($"Хеш-таблица размером {tableSize} успешно создана!");
        }

        static void PrintHashTable()
        {
            if (!isHashTableCreated)
            {
                Console.WriteLine("Хеш-таблица не создана или пуста.");
                return;
            }
            Console.WriteLine("Содержимое хеш-таблицы:");
            hashTable.Print();
        }

        static void FindElementById()
        {
            if (!isHashTableCreated)
            {
                Console.WriteLine("Хеш-таблица не создана или пуста, поиск невозможен.");
                return;
            }
            Console.Write("Введите ID для поиска: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Некорректный ввод ID.");
                return;
            }
            Plant foundPlant = hashTable.FindByKey(id);
            if (foundPlant != null)
            {
                Console.WriteLine("Найден элемент:");
                Console.WriteLine(foundPlant);
            }
            else
            {
                Console.WriteLine("Элемент с указанным ID не найден.");
            }
        }

        static void RemoveElementById()
        {
            if (!isHashTableCreated)
            {
                Console.WriteLine("Хеш-таблица не создана или пуста, удаление невозможно.");
                return;
            }
            Console.Write("Введите ID для удаления: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Некорректный ввод ID.");
                return;
            }
            bool removed = hashTable.RemoveByKey(id);
            if (removed)
            {
                Console.WriteLine("Элемент успешно удалён из хеш-таблицы.");
            }
            else
            {
                Console.WriteLine("Элемент с указанным ID не найден.");
            }
        }

        static void AddElementToHashTable()
        {
            if (!isHashTableCreated)
            {
                Console.WriteLine("Хеш-таблица не создана, невозможно добавить элемент.");
                return;
            }
            Console.WriteLine("Введите информацию о новом элементе:");
            Console.WriteLine("Выберите тип элемента:");
            Console.WriteLine("1) Растение");
            Console.WriteLine("2) Дерево");
            Console.WriteLine("3) Цветок");
            Console.WriteLine("4) Роза");
            if (!int.TryParse(Console.ReadLine(), out int typeChoice) || typeChoice < 1 || typeChoice > 4)
            {
                Console.WriteLine("Некорректный выбор типа элемента.");
                return;
            }
            Plant newPlant = typeChoice switch
            {
                1 => new Plant(),
                2 => new Tree(),
                3 => new Flower(),
                4 => new Rose(),
                _ => new Plant()
            };
            newPlant.RandomInit();
            hashTable.AddItem(newPlant.Id.Number, newPlant);
            Console.WriteLine("Элемент успешно добавлен в хеш-таблицу.");
            Console.WriteLine($"Текущая ёмкость таблицы: {hashTable.Capacity}, Количество элементов: {hashTable.Count}");
        }

        // Методы для бинарного дерева
        static void CreateTree()
        {
            Console.WriteLine("Введите количество объектов для дерева:");
            if (!int.TryParse(Console.ReadLine(), out int size) || size < 1)
            {
                Console.WriteLine("Некорректный ввод размера.");
                return;
            }
            Random rnd = new Random();
            Plant[] plants = new Plant[size];
            for (int i = 0; i < size; i++)
            {
                int objectType = rnd.Next(1, 5);
                plants[i] = objectType switch
                {
                    1 => new Plant(),
                    2 => new Tree(),
                    3 => new Flower(),
                    4 => new Rose(),
                    _ => new Plant()
                };
                plants[i].RandomInit();
            }
            tree = new MyTree<Plant>(plants);
            isTreeCreated = true;
            Console.WriteLine($"Идеально сбалансированное дерево размером {size} успешно создано!");
        }

        static void PrintTree()
        {
            if (!isTreeCreated || tree.Count == 0)
            {
                Console.WriteLine("Дерево пусто или не создано.");
                return;
            }
            Console.WriteLine("Содержимое дерева:");
            tree.ShowTree();
        }

        static void FindAverageAge()
        {
            if (!isTreeCreated || tree.Count == 0)
            {
                Console.WriteLine("Дерево пусто или не создано.");
                return;
            }
            double average = tree.FindAverageAge();
            Console.WriteLine($"Среднее арифметическое высоты деревьев: {average:F2} м");
        }

        static void TransformToSearchTree()
        {
            if (!isTreeCreated || tree.Count == 0)
            {
                Console.WriteLine("Дерево пусто или не создано.");
                return;
            }
            MyTree<Plant> searchTree = tree.TransformToSearchTree();
            Console.WriteLine("Исходное дерево:");
            tree.ShowTree();
            Console.WriteLine("АВЛ-дерево поиска:");
            searchTree.ShowTree();
        }

        static void RemoveElementByName()
        {
            if (!isTreeCreated || tree.Count == 0)
            {
                Console.WriteLine("Дерево пусто или не создано.");
                return;
            }
            Console.WriteLine("Введите имя растения для удаления:");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Некорректный ввод имени.");
                return;
            }
            Plant dummyPlant = new Plant { Name = name };
            bool removed = tree.RemoveByKey(dummyPlant);
            if (removed)
            {
                Console.WriteLine($"Элемент с именем '{name}' успешно удалён.");
            }
            else
            {
                Console.WriteLine($"Элемент с именем '{name}' не найден.");
            }
        }

        static void DeleteTree()
        {
            if (!isTreeCreated)
            {
                Console.WriteLine("Дерево не создано.");
                return;
            }
            tree.DeleteTree();
            isTreeCreated = false;
            Console.WriteLine("Дерево успешно удалено из памяти.");
        }
    }
}