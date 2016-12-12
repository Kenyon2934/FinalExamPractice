using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalExamPractice.DAL;
using FinalExamPractice.Models;

namespace FinalExamPractice.Controllers
{
    public class MyUsersController : Controller
    {
        private MissionContext db = new MissionContext();

        // GET: MyUsers
        public ActionResult Index()
        {
            return View(db.MyUsers.ToList());
        }

        // GET: MyUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyUser myUser = db.MyUsers.Find(id);
            if (myUser == null)
            {
                return HttpNotFound();
            }
            return View(myUser);
        }

        // GET: MyUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserEmail,UserPassword,UserFirstName,UserLastName")] MyUser myUser)
        {
            if (ModelState.IsValid)
            {
                db.MyUsers.Add(myUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myUser);
        }

        // GET: MyUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyUser myUser = db.MyUsers.Find(id);
            if (myUser == null)
            {
                return HttpNotFound();
            }
            return View(myUser);
        }

        // POST: MyUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserEmail,UserPassword,UserFirstName,UserLastName")] MyUser myUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myUser);
        }

        // GET: MyUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyUser myUser = db.MyUsers.Find(id);
            if (myUser == null)
            {
                return HttpNotFound();
            }
            return View(myUser);
        }

        // POST: MyUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyUser myUser = db.MyUsers.Find(id);
            db.MyUsers.Remove(myUser);
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
