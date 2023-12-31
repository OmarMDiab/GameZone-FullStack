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
    public class Game_storesController : Controller
    {
        private GamesDataEntities2 db = new GamesDataEntities2();

        // GET: Game_stores
        public ActionResult Index()
        {
            var game_stores = db.Game_stores.Include(g => g.Game_titles);
            return View(game_stores.ToList());
        }
        public ActionResult ExploreStores()
        {
            List<Game_stores> allStores = db.Game_stores.ToList();
            return View(allStores);
        }
        public ActionResult StoreDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Game_stores store = db.Game_stores.Find(id);

            if (store == null)
            {
                return HttpNotFound();
            }

            return View(store);
        }
        // GET: Game_stores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_stores game_stores = db.Game_stores.Find(id);
            if (game_stores == null)
            {
                return HttpNotFound();
            }
            return View(game_stores);
        }

        // GET: Game_stores/Create
        public ActionResult Create()
        {
            ViewBag.store_game_id = new SelectList(db.Game_titles, "game_id", "game_name");
            return View();
        }

        // POST: Game_stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "store_id,store_name,store_game_id,store_description")] Game_stores game_stores)
        {
            if (ModelState.IsValid)
            {
                db.Game_stores.Add(game_stores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.store_game_id = new SelectList(db.Game_titles, "game_id", "game_name", game_stores.store_game_id);
            return View(game_stores);
        }

        // GET: Game_stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_stores game_stores = db.Game_stores.Find(id);
            if (game_stores == null)
            {
                return HttpNotFound();
            }
            ViewBag.store_game_id = new SelectList(db.Game_titles, "game_id", "game_name", game_stores.store_game_id);
            return View(game_stores);
        }

        // POST: Game_stores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "store_id,store_name,store_game_id,store_description")] Game_stores game_stores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game_stores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.store_game_id = new SelectList(db.Game_titles, "game_id", "game_name", game_stores.store_game_id);
            return View(game_stores);
        }

        // GET: Game_stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_stores game_stores = db.Game_stores.Find(id);
            if (game_stores == null)
            {
                return HttpNotFound();
            }
            return View(game_stores);
        }

        // POST: Game_stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game_stores game_stores = db.Game_stores.Find(id);
            db.Game_stores.Remove(game_stores);
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
