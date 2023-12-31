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
    //[Authorize] // Require authentication for all actions
    public class Game_titlesController : Controller
    {
        private GamesDataEntities2 db = new GamesDataEntities2();

        // GET: Game_titles
        public ActionResult Index()
        {
            var gameTitles = db.Game_titles.ToList();
            return View(gameTitles);
        }
        public ActionResult ExploreGames()
        {
            List<Game_titles> allGames = db.Game_titles .ToList();
            return View(allGames);
        }
        public ActionResult GameDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Game_titles game = db.Game_titles.Find(id);

            if (game == null)
            {
                return HttpNotFound();
            }

            return View(game);
        }
        // GET: Game_titles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_titles game_titles = db.Game_titles.Find(id);
            if (game_titles == null)
            {
                return HttpNotFound();
            }
            return View(game_titles);
        }

        // GET: GameTitles/Create
        //[Authorize(Roles = "Admin")] // Only Admins can create new game titles
        public ActionResult Create()
        {
            return View();
        }



        // POST: Game_titles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")] // Only Admins can create new game titles
        public ActionResult Create([Bind(Include = "game_id,game_name,description,genre,platform,developer,release_date,ign_rate")] Game_titles game_titles)
        {
            if (ModelState.IsValid)
            {
                db.Game_titles.Add(game_titles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game_titles);
        }

        // GET: Game_titles/Edit/5
        //[Authorize(Roles = "Admin")] // Only Admins can edit game titles
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_titles game_titles = db.Game_titles.Find(id);
            if (game_titles == null)
            {
                return HttpNotFound();
            }
            return View(game_titles);
        }

        // POST: Game_titles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")] // Only Admins can edit game titles
        public ActionResult Edit([Bind(Include = "game_id,game_name,description,genre,platform,developer,release_date,ign_rate")] Game_titles game_titles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game_titles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game_titles);
        }

        // GET: Game_titles/Delete/5
        //[Authorize(Roles = "Admin")] // Only Admins can delete game titles
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_titles game_titles = db.Game_titles.Find(id);
            if (game_titles == null)
            {
                return HttpNotFound();
            }
            return View(game_titles);
        }

        // POST: Game_titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")] // Only Admins can delete game titles
        public ActionResult DeleteConfirmed(int id)
        {
            Game_titles game_titles = db.Game_titles.Find(id);
            db.Game_titles.Remove(game_titles);
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
