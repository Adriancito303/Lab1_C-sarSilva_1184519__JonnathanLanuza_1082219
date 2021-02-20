    using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab1_CésarSilva_1184519_JonnathanLanuza_1082219.Models.Data;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Lab1_CésarSilva_1184519_JonnathanLanuza_1082219.Controllers
{
    public class Players : Controller
    {
        List<string> plyers = new List<string>();
        // GET: Players
        public ActionResult Index()
        {
            return View(Singleton.Playrs.ListPlayers);
        }

        // GET: Players/Details/5
        public ActionResult Details(string Name)
        {
            return View();
        }

        // GET: Players/Create
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
        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var newplayerlist = new Models.MLSplayers
                {
                    Club = collection["Club"],
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    Position = collection["Position"],
                    Salary = Convert.ToInt32(collection["Salary"])
                };
                plyers.Add(newplayerlist.ToString());
                Singleton.Playrs.ListPlayers.Add(newplayerlist);
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

        // GET: Players/Delete/5
        public ActionResult Delete(string Name)
        {
            return View();
        }

        // POST: Players/Delete/5
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
//Lectura CSV

//[HttpPost]
//public ActionResult Index(HttPostedFileBase postedFile)
//{
//    string Lpath = string.Empty;
//    if(postedFile != null)
//    {
//        string path = Server.MapPath("~/Uploads/");
//        if (!Directory.Exists(path))
//        {
//            Directory.CreateDirectory(path);
//        }
//        filePath = path + Phat.GetFileName(postedFile.FileName);
//        string extencions = Path.GetExtension(postedFile.FileName);
//        postedFile.SaveAs(filePath);

//        string csvData = File.ReadAllText(filePath);
//        foreach (String row in  csvData.Split('\n'))
//        {
//            if (!string.IsNullOrEmpty(row))
//            {
//                plyers.Add(new string { Club = row.Split(',')[0]),
//                    Name = row.Split(',')[1]),
//                    });
//            }
//        }
//    }
//    return View();
//}
