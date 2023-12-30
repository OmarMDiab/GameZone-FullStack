using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gamezone.Models;
using Gamezone.ViewModels;

namespace Gamezone.Controllers
{
    public class Streamer_detailsController : Controller
    {
        private GamesDataEntities2 db = new GamesDataEntities2();

        // GET: Streamer_details
        public ActionResult Index()
        {
            var streamer_details = db.Streamer_details.Include(s => s.Game_titles);
            return View(streamer_details.ToList());
        }
        public ActionResult GuestSDIndex()
        {
            var streamer_details = db.Streamer_details.Include(s => s.Game_titles);
            return View(streamer_details.ToList());
        }

        // GET: Streamer_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Streamer_details streamer_details = db.Streamer_details.Find(id);
            if (streamer_details == null)
            {
                return HttpNotFound();
            }
            return View(streamer_details);
        }
        public ActionResult ExploreStreamer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Streamer_details streamer_details = db.Streamer_details.Find(id);

            if (streamer_details == null)
            {
                return HttpNotFound();
            }

            // Create a view model to pass the required data to the view
            var streamerViewModel = new ExploreStreamerViewModel
            {
                StreamerName = streamer_details.streamer_name,
                Thumbnail = streamer_details.thumbnail
                // Add other properties you may need
            };

            return View(streamerViewModel);
        }
        public ActionResult GuestSDDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Streamer_details streamer_details = db.Streamer_details.Find(id);
            if (streamer_details == null)
            {
                return HttpNotFound();
            }
            return View(streamer_details);
        }

        // GET: Streamer_details/Create
        public ActionResult Create()
        {
            ViewBag.game_id = new SelectList(db.Game_titles, "game_id", "game_name");
            return View();
        }

        // POST: Streamer_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "streamer_id,streamer_name,twitch_rank,description,most_streamed_game,number_of_followers,game_id")] Streamer_details streamer_details)
        {
            if (ModelState.IsValid)
            {
                db.Streamer_details.Add(streamer_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.game_id = new SelectList(db.Game_titles, "game_id", "game_name", streamer_details.game_id);
            return View(streamer_details);
        }

        // GET: Streamer_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Streamer_details streamer_details = db.Streamer_details.Find(id);
            if (streamer_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.game_id = new SelectList(db.Game_titles, "game_id", "game_name", streamer_details.game_id);
            return View(streamer_details);
        }

        // POST: Streamer_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "streamer_id,streamer_name,twitch_rank,description,most_streamed_game,number_of_followers,game_id")] Streamer_details streamer_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(streamer_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.game_id = new SelectList(db.Game_titles, "game_id", "game_name", streamer_details.game_id);
            return View(streamer_details);
        }

        // GET: Streamer_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Streamer_details streamer_details = db.Streamer_details.Find(id);
            if (streamer_details == null)
            {
                return HttpNotFound();
            }
            return View(streamer_details);
        }

        // POST: Streamer_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Streamer_details streamer_details = db.Streamer_details.Find(id);
            db.Streamer_details.Remove(streamer_details);
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
