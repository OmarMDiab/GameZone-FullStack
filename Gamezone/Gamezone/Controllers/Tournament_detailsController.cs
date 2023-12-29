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
    public class Tournament_detailsController : Controller
    {
        private GamesDataEntities1 db = new GamesDataEntities1();

        // GET: Tournament_details
        public ActionResult Index()
        {
            var tournament_details = db.Tournament_details.Include(t => t.Game_titles);
            return View(tournament_details.ToList());
        }

        // GET: Tournament_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament_details tournament_details = db.Tournament_details.Find(id);
            if (tournament_details == null)
            {
                return HttpNotFound();
            }
            return View(tournament_details);
        }

        // GET: Tournament_details/Create
        public ActionResult Create()
        {
            ViewBag.tournament_game_id = new SelectList(db.Game_titles, "game_id", "game_name");
            return View();
        }

        // POST: Tournament_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tournament_id,tournament_name,description,tournament_game_id,tournament_game_name")] Tournament_details tournament_details)
        {
            if (ModelState.IsValid)
            {
                db.Tournament_details.Add(tournament_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tournament_game_id = new SelectList(db.Game_titles, "game_id", "game_name", tournament_details.tournament_game_id);
            return View(tournament_details);
        }

        // GET: Tournament_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament_details tournament_details = db.Tournament_details.Find(id);
            if (tournament_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.tournament_game_id = new SelectList(db.Game_titles, "game_id", "game_name", tournament_details.tournament_game_id);
            return View(tournament_details);
        }

        // POST: Tournament_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tournament_id,tournament_name,description,tournament_game_id,tournament_game_name")] Tournament_details tournament_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournament_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tournament_game_id = new SelectList(db.Game_titles, "game_id", "game_name", tournament_details.tournament_game_id);
            return View(tournament_details);
        }

        // GET: Tournament_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament_details tournament_details = db.Tournament_details.Find(id);
            if (tournament_details == null)
            {
                return HttpNotFound();
            }
            return View(tournament_details);
        }

        // POST: Tournament_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tournament_details tournament_details = db.Tournament_details.Find(id);
            db.Tournament_details.Remove(tournament_details);
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
