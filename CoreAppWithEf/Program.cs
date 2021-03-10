using System;
using System.Collections.Generic;
using System.Threading;
using Library;


namespace CoreAppWithEf
{
    class Program
    {
        static void Main()
        {
            DbActions db = new DbActions();
            while (true)
            {
                List<User> user = db.Select();
                foreach (User e in user)
                {
                    Console.WriteLine($"Id - {e.Id}, Name - {e.Name}, Age - {e.Age}");
                }

                Console.WriteLine(@"
Выберите действие:
1.Добавить элемент
2.Изменить элемент (недоступно)
3.Удалить элемент
4.Выйти из приложения");
                string ans = Console.ReadLine();
                switch (ans)
                {
                    case "1": // Добавление элемента
                        User newUser = new User();
                        try
                        {
                            Console.Write("Введите имя ");
                            newUser.Name = Console.ReadLine();
                            Console.Write("\nВведите возраст ");
                            newUser.Age = int.Parse(Console.ReadLine());
                            db.Add(newUser);
                        }
                        catch
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.ReadKey();
                        }
                        Console.Clear();
                        break;
                    case "2": // Изменение элемента
                        Console.Clear();
                        break;
                    case "3": // Удаление элемента
                        Console.WriteLine("Введите номер элемента");
                        try
                        {
                            int id = int.Parse(Console.ReadLine() ?? string.Empty);
                            db.Delete(id);
                        }
                        catch
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.ReadKey();
                        }
                        Console.Clear();
                        break;
                    case "4": // Выход из приложения
                        Console.WriteLine("Приложение закроется через 2 сек");
                        Thread.Sleep(1500);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Некорректный ввод");
                        Thread.Sleep(500);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
