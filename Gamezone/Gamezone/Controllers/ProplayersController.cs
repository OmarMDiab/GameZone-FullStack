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
    public class ProplayersController : Controller
    {
        private GamesDataEntities2 db = new GamesDataEntities2();

        // GET: Proplayers
        public ActionResult Index()
        {
            var proplayers = db.Proplayers.Include(p => p.Team);
            return View(proplayers.ToList());
        }
        public ActionResult ExplorePlayers()
        {
            List<Proplayer> allPlayers = db.Proplayers.ToList();
            return View(allPlayers);
        }
        public ActionResult PlayerDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Proplayer player = db.Proplayers.Find(id);

            if (player == null)
            {
                return HttpNotFound();
            }

            return View(player);
        }
        // GET: Proplayers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proplayer proplayer = db.Proplayers.Find(id);
            if (proplayer == null)
            {
                return HttpNotFound();
            }
            return View(proplayer);
        }

        // GET: Proplayers/Create
        public ActionResult Create()
        {
            ViewBag.player_team_id = new SelectList(db.Teams, "team_id", "team_name");
            return View();
        }

        // POST: Proplayers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "player_id,player_name,player_nationality,player_team,player_achievements,player_team_id")] Proplayer proplayer)
        {
            if (ModelState.IsValid)
            {
                db.Proplayers.Add(proplayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.player_team_id = new SelectList(db.Teams, "team_id", "team_name", proplayer.player_team_id);
            return View(proplayer);
        }

        // GET: Proplayers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proplayer proplayer = db.Proplayers.Find(id);
            if (proplayer == null)
            {
                return HttpNotFound();
            }
            ViewBag.player_team_id = new SelectList(db.Teams, "team_id", "team_name", proplayer.player_team_id);
            return View(proplayer);
        }

        // POST: Proplayers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "player_id,player_name,player_nationality,player_team,player_achievements,player_team_id")] Proplayer proplayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proplayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.player_team_id = new SelectList(db.Teams, "team_id", "team_name", proplayer.player_team_id);
            return View(proplayer);
        }

        // GET: Proplayers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proplayer proplayer = db.Proplayers.Find(id);
            if (proplayer == null)
            {
                return HttpNotFound();
            }
            return View(proplayer);
        }

        // POST: Proplayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proplayer proplayer = db.Proplayers.Find(id);
            db.Proplayers.Remove(proplayer);
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
