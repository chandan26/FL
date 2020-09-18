using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APTACONF.Models;
//System.Data.Entity;

namespace APTACONF.Controllers
{
    public class authorController : Controller
    {
        // GET: author
        public ActionResult Index()
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.authortable.ToList());
            }
           
        }

        // GET: author/Details/5
        public ActionResult Details(int? id)
        {
            using(aptadbEntities aptadb=new aptadbEntities())
            {
                return View(aptadb.authortable.Where(x =>x.authorid==id).FirstOrDefault());
            }

           // return View();

            ////////////////////To Do
        }

        // GET: author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: author/Create
        [HttpPost]
        public ActionResult Create(authortable author)
        {
            try
            {
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    aptadb.authortable.Add(author);
                    aptadb.SaveChanges();
                    //return View(aptadb.authortable.ToList());
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: author/Edit/5
        public ActionResult Edit(int id)
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.authortable.Where(x => x.authorid == id).FirstOrDefault());
            }
        }

        // POST: author/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, authortable author)
        {
            try
            {
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    //return View(aptadb.authortable.Where(x => x.authorid == id).FirstOrDefault());
                    aptadb.Entry(author).State = EntityState.Modified;
                    aptadb.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: author/Delete/5
        public ActionResult Delete(int id)
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.authortable.Where(x => x.authorid == id).FirstOrDefault());
            }
        }

        // POST: author/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    //aptadb.authortable.Add(author);
                    authortable authortable = aptadb.authortable.Where(x => x.authorid == id).FirstOrDefault();
                    aptadb.authortable.Remove(authortable);
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
