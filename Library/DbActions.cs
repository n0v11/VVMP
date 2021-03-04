using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Library
{
    public class DbActions
    {
        public static List<User> Select()
        {
            using var db = new ApplicationsContext();
            var user = db.Users.ToList();
            return user;
        }

        public static void Add(User user)
        {
            using ApplicationsContext db = new ApplicationsContext();
            db.Add(user);
            db.SaveChanges();
        }

        public static void Delete(int? id) // Удаление по id с проверкой на null 
        {
            using ApplicationsContext db = new ApplicationsContext();
            User user = db.Users.FirstOrDefault(p => p.Id == id);
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
