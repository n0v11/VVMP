using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Library;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbActions _db = new DbActions();

        public ActionResult Index()
        {
            var users = _db.Select();
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name) || user.Age <= 0)
            {
                return BadRequest("Не введено имя пользователи или возраст равен или менее нуля");
            }
            else
            {
                _db.Add(user);    
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int? id, User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name) || user.Age <= 0)
            {
                return BadRequest("Не введено имя пользователи или возраст равен или менее нуля");
            }
            else
            {
                _db.Edit(id, user);
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            try
            {
                _db.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest("Введен неверный индекс элемента");
            }
        }
    }
}
