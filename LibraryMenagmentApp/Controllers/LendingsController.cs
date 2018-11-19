using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryMenagmentApp.Models;

namespace LibraryMenagmentApp.Controllers
{
    public class LendingsController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Lendings
        public ActionResult Index()
        {
            var lendings = db.Lendings.Include(l => l.Book).Include(l => l.Client);
            return View(lendings.ToList());
        }

        // GET: Lendings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lending lending = db.Lendings.Find(id);
            if (lending == null)
            {
                return HttpNotFound();
            }
            return View(lending);
        }

        // GET: Lendings/Create
        public ActionResult Create()
        {
            ViewBag.FK_Book = new SelectList(db.Books, "Id", "Title");
            ViewBag.FK_Client = new SelectList(db.Clients, "Id", "Name");
            return View();
        }

        // POST: Lendings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FK_Book,FK_Client,dateofreceipt,ReturnDate")] Lending lending)
        {
            if (ModelState.IsValid)
            {
                db.Lendings.Add(lending);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Book = new SelectList(db.Books, "Id", "Title", lending.FK_Book);
            ViewBag.FK_Client = new SelectList(db.Clients, "Id", "Name", lending.FK_Client);
            return View(lending);
        }

        // GET: Lendings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lending lending = db.Lendings.Find(id);
            if (lending == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Book = new SelectList(db.Books, "Id", "Title", lending.FK_Book);
            ViewBag.FK_Client = new SelectList(db.Clients, "Id", "Name", lending.FK_Client);
            return View(lending);
        }

        // POST: Lendings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FK_Book,FK_Client,dateofreceipt,ReturnDate")] Lending lending)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lending).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Book = new SelectList(db.Books, "Id", "Title", lending.FK_Book);
            ViewBag.FK_Client = new SelectList(db.Clients, "Id", "Name", lending.FK_Client);
            return View(lending);
        }

        // GET: Lendings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lending lending = db.Lendings.Find(id);
            if (lending == null)
            {
                return HttpNotFound();
            }
            return View(lending);
        }

        // POST: Lendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lending lending = db.Lendings.Find(id);
            db.Lendings.Remove(lending);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
