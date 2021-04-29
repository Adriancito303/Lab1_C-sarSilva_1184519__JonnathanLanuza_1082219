using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Lab1_CésarSilva_1184519_JonnathanLanuza_1082219.Models.Data;
using Lab1_CésarSilva_1184519_JonnathanLanuza_1082219.Models;
using Lab1_CésarSilva_1184519__JonnathanLanuza_1082219.Models.ViewModels;


namespace Lab1_CésarSilva_1184519_JonnathanLanuza_1082219.Controllers
{
    public class Players : Controller
    {
        List<string> plyers = new List<string>();
        private readonly IWebHostEnvironment hostingEnvironment;
        public Players(IWebHostEnvironment hostEnvironment)
        {
            hostingEnvironment = hostEnvironment;
        }
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
        public ActionResult FileUpload()
        {
            return View();
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult CreatePlayers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePlayers(IFormCollection Dplayers)
        {
            var Player = new Models.MLSplayers
            {
                Club = Dplayers["Club"],
                Name = Dplayers["Name"],
                LastName = Dplayers["LastName"],
                Position = Dplayers["Position"],
                Salary = Convert.ToInt32(Dplayers["Salary"])
            };
            Singleton.Playrs.ListPlayers.Add(Player);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Search()
        {
            return View(Singleton.Playrs.ListPlayers);
        }
        [HttpPost]
        public ActionResult Search(string Name, string LastName, string Position, string Club, int Salary)
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
        public ActionResult Create(MLSModelView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string uniquefilename = null;
                    if (model.SelectList != null)
                    {
                        //Subir archivo
                        string uploadsfolder = Path.Combine(hostingEnvironment.WebRootPath, "Uploads");
                        uniquefilename = Guid.NewGuid().ToString() + "_" + model.SelectList.FileName;
                        string filepath = Path.Combine(uploadsfolder, uniquefilename);
                        model.SelectList.CopyTo(new FileStream(filepath, FileMode.Create));
                        //Leer archivo
                        StreamReader lector = new StreamReader("filepath");
                        //interpretar linea para leer info de medicina
                        string read = lector.ReadLine();
                        int cont = 0;
                        //insertar en la lista de medicinas
                        while (!lector.EndOfStream)
                        {
                            string leer = lector.ReadLine();
                            for (int i = 0; i < 6; i++)
                            {
                                if (read[i] == ',')
                                {
                                    if (read[i + 1] != ',')
                                    {

                                        //LECTURA.lmed(leer);
                                    }
                                    else
                                    {

                                        //LECTURA.lmed(leer);
                                    }
                                    cont++;
                                }
                            }

                            //insertar en el indice de busqueda Binaria
                            //BinaryTree.Add(Singleton.Instance.MClientsList);
                        }

                    };

                    return RedirectToAction("Index");
                }
                return View();
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
                var Player = new Models.MLSplayers
                {
                    Club = collection["Club"],
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    Position = collection["Position"],
                    Salary = Convert.ToInt32(collection["Salary"])
                };
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
                Singleton.Playrs.ListPlayers.Clear();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
