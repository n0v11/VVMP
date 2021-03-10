using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace Library
{
    public class DbActions
    {
        private static readonly ApplicationsContext db = new ApplicationsContext();

        public List<User> Select()
        {
            db.Database.EnsureCreated(); // Создание базы если на момент запуска ее не существует.
            return db.Users.ToList();
        }

        public void Add(User user)
        {
            db.Add(user);
            db.SaveChanges();
        }

        public void Delete(int? id) // Удаление по id с проверкой на null 
        {
            db.Users.Remove(db.Users.FirstOrDefault(p => p.Id == id));
            db.SaveChanges();
        }
    }
}
