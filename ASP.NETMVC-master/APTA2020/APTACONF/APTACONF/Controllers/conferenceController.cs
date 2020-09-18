using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APTACONF.Models;

namespace APTACONF.Controllers
{
    public class conferenceController : Controller
    {
        // GET: conference
        public ActionResult Index()
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.conferencetable.ToList());
            }
        }

        // GET: conference/Details/5
        public ActionResult Details(int? id)
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.conferencetable.Where(x => x.conferenceid == id).FirstOrDefault());
            }
        }

        // GET: conference/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: conference/Create
        [HttpPost]
        public ActionResult Create(conferencetable confer)
        {
            try
            {
                // TODO: Add insert logic here
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    aptadb.conferencetable.Add(confer);
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

        // GET: conference/Edit/5
        public ActionResult Edit(int? id)
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.conferencetable.Where(x => x.conferenceid == id).FirstOrDefault());
            }
        }

        // POST: conference/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, conferencetable cons)
        {
            try
            {
                // TODO: Add update logic here
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    //return View(aptadb.authortable.Where(x => x.authorid == id).FirstOrDefault());
                    aptadb.Entry(cons).State = EntityState.Modified;
                    aptadb.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: conference/Delete/5
        public ActionResult Delete(int? id)
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.conferencetable.Where(x => x.conferenceid == id).FirstOrDefault());
            }
        }

        // POST: conference/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    //aptadb.authortable.Add(author);
                   conferencetable confd = aptadb.conferencetable.Where(x => x.conferenceid == id).FirstOrDefault();
                    aptadb.conferencetable.Remove(confd);
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
