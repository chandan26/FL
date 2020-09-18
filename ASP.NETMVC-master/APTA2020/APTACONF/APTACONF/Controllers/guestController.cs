using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APTACONF.Models;

namespace APTACONF.Controllers
{
    public class guestController : Controller
    {
        // GET: guest
        public ActionResult Index()
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.guesttable.ToList());
            }
        }

        // GET: guest/Details/5
        public ActionResult Details(int? id)
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.guesttable.Where(x => x.guestid == id).FirstOrDefault());
            }
        }

        // GET: guest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: guest/Create
        [HttpPost]
        public ActionResult Create(guesttable guest)
        {
            try
            {
                // TODO: Add insert logic here
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    aptadb.guesttable.Add(guest);
                    aptadb.SaveChanges();
                    //return View(aptadb.authortable.ToList());
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: guest/Edit/5
        public ActionResult Edit(int? id)
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.guesttable.Where(x => x.guestid == id).FirstOrDefault());
            }
        }

        // POST: guest/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, guesttable guest)
        {
            try
            {
                // TODO: Add update logic here
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    //return View(aptadb.authortable.Where(x => x.authorid == id).FirstOrDefault());
                    aptadb.Entry(guest).State = EntityState.Modified;
                    aptadb.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: guest/Delete/5
        public ActionResult Delete(int? id)
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.guesttable.Where(x => x.guestid == id).FirstOrDefault());
            }
        }

        // POST: guest/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    //aptadb.authortable.Add(author);
                    guesttable gsttable= aptadb.guesttable.Where(x => x.guestid == id).FirstOrDefault();
                    aptadb.guesttable.Remove(gsttable);
                    aptadb.SaveChanges();
                    //return View(aptadb.authortable.ToList());
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
