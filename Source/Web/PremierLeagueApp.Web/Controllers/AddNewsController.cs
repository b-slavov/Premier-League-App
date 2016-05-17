namespace MvcTemplate.Web.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using PagedList;

    using PremierLeagueApp.Data;
    using PremierLeagueApp.Data.Models;
    using PremierLeagueApp.Web.ViewModels.Home;

    public class AddNewsController : Controller
    {
        private const int PageSize = 12;

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int page = 1)
        {
            var news = this.db.News.Include(n => n.Club).OrderByDescending(x => x.Id).ToList().ToPagedList(page, PageSize);

            return this.View(news);
        }

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

        public ActionResult Create()
        {
            this.ViewData["Teams"] = this.db.Clubs.OrderBy(x => x.Name)
                .Select(x => new SelectListItem
                {
                    Text = x.Name, Value = x.Id.ToString()
                });

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsViewModel news)
        {
            var article = new News();
            if (this.ModelState.IsValid)
            {
                article.ImageUrl = news.ImageUrl;
                article.Title = news.Title;
                article.Content = news.Content;
                article.CreatedOn = DateTime.Now;
                article.ClubId = news.ClubId;
                this.db.News.Add(article);
                this.db.SaveChanges();

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(news);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News news)
        {
            if (this.ModelState.IsValid)
            {
                news.ModifiedOn = DateTime.Now;
                this.db.Entry(news).State = EntityState.Modified;
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            this.ViewBag.ClubId = new SelectList(this.db.Clubs, "Id", "Name", news.ClubId);
            return this.View(news);
        }

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
