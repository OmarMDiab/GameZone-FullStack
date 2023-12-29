using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gamezone.Models;

namespace Gamezone.Controllers
{
    public class gaming_organizationController : Controller
    {
        private GamesDataEntities1 db = new GamesDataEntities1();

        // GET: gaming_organization
        public ActionResult Index()
        {
            return View(db.gaming_organization.ToList());
        }

        // GET: gaming_organization/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gaming_organization gaming_organization = db.gaming_organization.Find(id);
            if (gaming_organization == null)
            {
                return HttpNotFound();
            }
            return View(gaming_organization);
        }

        // GET: gaming_organization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: gaming_organization/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "org_id,org_name,org_establishment_date,org_team_name,org_achievements")] gaming_organization gaming_organization)
        {
            if (ModelState.IsValid)
            {
                db.gaming_organization.Add(gaming_organization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gaming_organization);
        }

        // GET: gaming_organization/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gaming_organization gaming_organization = db.gaming_organization.Find(id);
            if (gaming_organization == null)
            {
                return HttpNotFound();
            }
            return View(gaming_organization);
        }

        // POST: gaming_organization/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "org_id,org_name,org_establishment_date,org_team_name,org_achievements")] gaming_organization gaming_organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gaming_organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gaming_organization);
        }

        // GET: gaming_organization/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gaming_organization gaming_organization = db.gaming_organization.Find(id);
            if (gaming_organization == null)
            {
                return HttpNotFound();
            }
            return View(gaming_organization);
        }

        // POST: gaming_organization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gaming_organization gaming_organization = db.gaming_organization.Find(id);
            db.gaming_organization.Remove(gaming_organization);
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
