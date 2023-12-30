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
    public class Game_enginesController : Controller
    {
        private GamesDataEntities2 db = new GamesDataEntities2();

        // GET: Game_engines
        public ActionResult Index()
        {
            var game_engines = db.Game_engines.Include(g => g.Game_titles);
            return View(game_engines.ToList());
        }

        // GET: Game_engines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_engines game_engines = db.Game_engines.Find(id);
            if (game_engines == null)
            {
                return HttpNotFound();
            }
            return View(game_engines);
        }

        // GET: Game_engines/Create
        public ActionResult Create()
        {
            ViewBag.game_id = new SelectList(db.Game_titles, "game_id", "game_name");
            return View();
        }

        // POST: Game_engines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "game_engine_id,game_id,game_engine_name,game_engine_description")] Game_engines game_engines)
        {
            if (ModelState.IsValid)
            {
                db.Game_engines.Add(game_engines);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.game_id = new SelectList(db.Game_titles, "game_id", "game_name", game_engines.game_id);
            return View(game_engines);
        }

        // GET: Game_engines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_engines game_engines = db.Game_engines.Find(id);
            if (game_engines == null)
            {
                return HttpNotFound();
            }
            ViewBag.game_id = new SelectList(db.Game_titles, "game_id", "game_name", game_engines.game_id);
            return View(game_engines);
        }

        // POST: Game_engines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "game_engine_id,game_id,game_engine_name,game_engine_description")] Game_engines game_engines)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game_engines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.game_id = new SelectList(db.Game_titles, "game_id", "game_name", game_engines.game_id);
            return View(game_engines);
        }

        // GET: Game_engines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_engines game_engines = db.Game_engines.Find(id);
            if (game_engines == null)
            {
                return HttpNotFound();
            }
            return View(game_engines);
        }

        // POST: Game_engines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game_engines game_engines = db.Game_engines.Find(id);
            db.Game_engines.Remove(game_engines);
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
