using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APTACONF.Models;

namespace APTACONF.Controllers
{
    public class reservationController : Controller
    {
        // GET: reservation
        public ActionResult Index()
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.reservationtable.ToList());
            }
        }

        // GET: reservation/Details/5
        public ActionResult Details(int? id)
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.reservationtable.Where(x => x.reservationID == id).FirstOrDefault());
            }
        }

        // GET: reservation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: reservation/Create
        [HttpPost]
        public ActionResult Create(reservationtable reserve)
        {
            try
            {
                // TODO: Add insert logic here
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    aptadb.reservationtable.Add(reserve);
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

        // GET: reservation/Edit/5
        public ActionResult Edit(int? id)
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.reservationtable.Where(x => x.reservationID == id).FirstOrDefault());
            }
        }

        // POST: reservation/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, reservationtable reserv)
        {
            try
            {
                // TODO: Add update logic here
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    //return View(aptadb.authortable.Where(x => x.authorid == id).FirstOrDefault());
                    aptadb.Entry(reserv).State = EntityState.Modified;
                    aptadb.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: reservation/Delete/5
        public ActionResult Delete(int? id)
        {
            using (aptadbEntities aptadb = new aptadbEntities())
            {
                return View(aptadb.reservationtable.Where(x => x.reservationID == id).FirstOrDefault());
            }
        }

        // POST: reservation/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (aptadbEntities aptadb = new aptadbEntities())
                {
                    //aptadb.authortable.Add(author);
                    reservationtable resable = aptadb.reservationtable.Where(x => x.reservationID == id).FirstOrDefault();
                    aptadb.reservationtable.Remove(resable);
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
