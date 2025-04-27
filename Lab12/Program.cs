using Plants;
using System;

namespace Lab12
{
    public class Program
    {
        static MyList<Plant> list = new MyList<Plant>(); // Двусвязный список для растений
        static MyHashTable<int, Plant> hashTable = null!; // Хеш-таблица для растений
        static bool isListCreated = false; // Флаг создания списка
        static bool isHashTableCreated = false; // Флаг создания хеш-таблицы

        static void PrintMainMenu() // Выводит главное меню
        {
            Console.WriteLine("-----------------------------------ГЛАВНОЕ МЕНЮ-----------------------------------");
            Console.WriteLine("1) Работа с двусвязным списком (Задание 1)");
            Console.WriteLine("2) Работа с хеш-таблицей (Задание 2)");
            Console.WriteLine("3) Выход");
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

        static void Main(string[] args) // Главный метод программы
        {
            bool exit = false;
            while (!exit)
            {
                PrintMainMenu();
                Console.Write("Выберите действие (1-3): ");
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
                        exit = true;
                        Console.WriteLine("Программа завершена.");
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, выберите 1, 2 или 3.");
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

        static void CreateList() // Создаёт двусвязный список
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
            list = new MyList<Plant>(length); // Создаёт список заданной длины
            Console.WriteLine($"Список длиной {length} успешно создан!");
            isListCreated = true;
        }

        static void PrintList() // Выводит список
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

        static void RemoveByName() // Удаляет элементы по имени
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

        static void AddKToStart() // Добавляет K элементов в начало списка
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

        static void DeepCopyList() // Клонирует список
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

        static void DeleteList() // Удаляет список из памяти
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

        static void CreateHashTable() // Создаёт хеш-таблицу
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

        static void PrintHashTable() // Выводит хеш-таблицу
        {
            if (!isHashTableCreated)
            {
                Console.WriteLine("Хеш-таблица не создана или пуста.");
                return;
            }
            Console.WriteLine("Содержимое хеш-таблицы:");
            hashTable.Print();
        }

        static void FindElementById() // Ищет элемент по ID
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

        static void RemoveElementById() // Удаляет элемент по ID
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

        static void AddElementToHashTable() // Добавляет элемент в хеш-таблицу
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
    }
}