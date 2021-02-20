using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1_CésarSilva_1184519_JonnathanLanuza_1082219.Models.Data;

namespace Lab1_CésarSilva_1184519_JonnathanLanuza_1082219.Controllers
{
    public class CPlayers : Controller
    {
        LinkedList<string> plyers = new LinkedList<string>();
        // GET: CPlayers
        public ActionResult Index()
        {
            return View(Singleton.Playrs.ListPlayers);
        }

        // GET: CPlayers/Details/5
        public ActionResult Details(string Name)
        {
            return View();
        }

        // GET: CPlayers/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Name, string LastName, string Position, string Club, int Salary)
        {
            ViewData["SearchName"] = Name;
            ViewData["SearchLastName"] = LastName;
            ViewData["SearchPosition"] = Position;
            ViewData["SearchClub"] = Club;
            ViewData["SearchSalary"] = Salary;
            Singleton.Playrs.ListPlayers.Clear();

            if (Name != null)
            {
                for (int i = 0; i < Singleton.Playrs.ListPlayers.Count() - 1; i++)
                {
                    if (Singleton.Playrs.ListPlayers[i].Name == Name)
                    {
                        Singleton.Playrs.ListPlayers.Add(Singleton.Playrs.ListPlayers[i]);
                    }
                }
                return View(Singleton.Playrs.ListPlayers);
            }

            if (LastName != null)
            {
                for (int i = 0; i < Singleton.Playrs.ListPlayers.Count() - 1; i++)
                {
                    if (Singleton.Playrs.ListPlayers[i].LastName == LastName)
                    {
                        Singleton.Playrs.ListPlayers.Add(Singleton.Playrs.ListPlayers[i]);
                    }
                }
                return View(Singleton.Playrs.ListPlayers);
            }

            if (Position != null)
            {
                for (int i = 0; i < Singleton.Playrs.ListPlayers.Count() - 1; i++)
                {
                    if (Singleton.Playrs.ListPlayers[i].Position == Position)
                    {
                        Singleton.Playrs.ListPlayers.Add(Singleton.Playrs.ListPlayers[i]);
                    }
                }
                return View(Singleton.Playrs.ListPlayers);
            }

            if (Club != null)
            {
                for (int i = 0; i < Singleton.Playrs.ListPlayers.Count() - 1; i++)
                {
                    if (Singleton.Playrs.ListPlayers[i].Club == Club)
                    {
                        Singleton.Playrs.ListPlayers.Add(Singleton.Playrs.ListPlayers[i]);
                    }
                }
                return View(Singleton.Playrs.ListPlayers);
            }

            if (Salary > 0)
            {
                for (int i = 0; i < Singleton.Playrs.ListPlayers.Count() - 1; i++)
                {
                    if (Singleton.Playrs.ListPlayers[i].Salary == Salary)
                    {
                        Singleton.Playrs.ListPlayers.Add(Singleton.Playrs.ListPlayers[i]);
                    }
                }
                return View(Singleton.Playrs.ListPlayers);
            }
            return View();
        }
        // POST: CPlayers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CPlayers/Edit/5
        public ActionResult Edit(int Salary)
        {
            return View();
        }

        // POST: CPlayers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Salary, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CPlayers/Edit/5
        public ActionResult Edit(string Club)
        {
            var editp = Singleton.Playrs.ListPlayers.Find(x => x.Club == Club);
            return View(editp);
        }

        // POST: CPlayers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string Club, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CPlayers/Delete/5
        public ActionResult Delete(string Name)
        {
            return View();
        }

        // POST: CPlayers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string Name, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
