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
            Console.Clear();
            DbActions.Select();
        }
    }
}
