using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APTACONF.Models;

namespace APTACONF.Controllers
{
    public class paperController : Controller
    {
        // GET: paper
        public ActionResult Index()
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.papertable.ToList());
            }
        }

        // GET: paper/Details/5
        public ActionResult Details(int? id)
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.papertable.Where(x => x.paperid == id).FirstOrDefault());
            }
        }

        // GET: paper/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: paper/Create
        [HttpPost]
        public ActionResult Create(papertable paper)
        {
            try
            {
                // TODO: Add insert logic here
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    aptadb.papertable.Add(paper);
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

        // GET: paper/Edit/5
        public ActionResult Edit(int? id)
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.papertable.Where(x => x.paperid == id).FirstOrDefault());
            }
        }

        // POST: paper/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, papertable paper)
        {
            try
            {
                // TODO: Add update logic here
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    //return View(aptadb.authortable.Where(x => x.authorid == id).FirstOrDefault());
                    aptadb.Entry(paper).State = EntityState.Modified;
                    aptadb.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: paper/Delete/5
        public ActionResult Delete(int? id)
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.papertable.Where(x => x.paperid == id).FirstOrDefault());
            }
        }

        // POST: paper/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    //aptadb.authortable.Add(author);
                    papertable ppertable = aptadb.papertable.Where(x => x.paperid == id).FirstOrDefault();
                    aptadb.papertable.Remove(ppertable);
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
