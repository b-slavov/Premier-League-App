namespace MvcTemplate.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using PremierLeagueApp.Data;
    using PremierLeagueApp.Data.Models;
    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;

    public class AddNewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private IList<Club> GetPremierLeagueTeams()
        {
            var client = new WebClient();
            string content = client.DownloadString("http://api.football-data.org/v1/soccerseasons/398/teams");
            IList<Club> clubs = JsonConvert.DeserializeObject<FootballData>(content).Teams;
            return clubs;
        }

        // GET: AddNews
        public ActionResult Index()
        {
            var news = this.db.News.Include(n => n.Club);
            return this.View(news.ToList());
        }

        // GET: AddNews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            News news = this.db.News.Find(id);
            if (news == null)
            {
                return this.HttpNotFound();
            }

            return this.View(news);
        }

        // GET: AddNews/Create
        public ActionResult Create()
        {
            this.ViewBag.ClubId = new SelectList(this.db.Clubs, "Id", "Name");
            this.ViewData["Teams"] = this.GetPremierLeagueTeams()
                .Select(x => new SelectListItem
                {
                    Text = x.Name, Value = x.Id.ToString()
                });

            return this.View();
        }

        // POST: AddNews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,Title,Content,ClubId,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] News news)
        {
            if (this.ModelState.IsValid)
            {
                news.CreatedOn = DateTime.Now;
                this.db.News.Add(news);
                this.db.SaveChanges();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewBag.ClubId = new SelectList(this.db.Clubs, "Id", "Name", news.ClubId);
            return this.View(news);
        }

        // GET: AddNews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            News news = this.db.News.Find(id);
            if (news == null)
            {
                return this.HttpNotFound();
            }

            this.ViewBag.ClubId = new SelectList(this.db.Clubs, "Id", "Name", news.ClubId);
            return this.View(news);
        }

        // POST: AddNews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,Title,Content,ClubId,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] News news)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Entry(news).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            this.ViewBag.ClubId = new SelectList(this.db.Clubs, "Id", "Name", news.ClubId);
            return this.View(news);
        }

        // GET: AddNews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            News news = this.db.News.Find(id);
            if (news == null)
            {
                return this.HttpNotFound();
            }

            return this.View(news);
        }

        // POST: AddNews/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = this.db.News.Find(id);
            this.db.News.Remove(news);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
