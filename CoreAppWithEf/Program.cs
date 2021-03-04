using System;
using Library;


namespace CoreAppWithEf
{
    class Program
    {
        static void Main() // В процессе
        {
            var user = DbActions.Select();
            foreach (var e in user)
            {
                Console.WriteLine($"Id - {e.Id}, Name - {e.Name}, Age - {e.Age}");
            }
            Console.ReadKey();
            //Actions.Add("Petr", 46); // пример добавления новой записи в бд. Есть вариант программы где реализованы дополнительно update и delete функции.
            Console.Clear();
            DbActions.Select();
        }
    }
}
