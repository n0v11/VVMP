using System;
using System.Collections.Generic;
using System.Threading;
using Library;


namespace CoreAppWithEf
{
    class Program
    {
        static void Main() // В процессе
        {
            DbActions db = new DbActions();
            List<User> user = db.Select();
            foreach (var e in user)
            {
                Console.WriteLine($"Id - {e.Id}, Name - {e.Name}, Age - {e.Age}");
            }
            Thread.Sleep(3000);
            User newUser = new User() {Age = 30, Name = "Ivan"};
            db.Add(newUser);
            Console.WriteLine($"Добавлен новый пользователь. Имя: {newUser.Name}, возраст: {newUser.Age}");
            Thread.Sleep(3000);
        }
    }
}
