using ItBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace ItBlog.Controllers
{
    public class HomeController : Controller
    {
        BlogContext db = new BlogContext();
 
        
        public ActionResult Index(string articleCat, string searchString,DateTime? fromDate,DateTime? forDate)
        {
            if (fromDate == null)
                fromDate = new DateTime(2019, 1, 1);
            if (forDate == null)
                forDate = new DateTime(2080, 1, 1);
            if (!String.IsNullOrEmpty(searchString) && articleCat=="All")
            {
                var art = new List<Article>();
                foreach(Article b in db.Articles)
                {
                    if (!String.IsNullOrEmpty(b.Tags))
                    {
                        if (b.Tags.Contains(searchString) && b.Time > fromDate && b.Time < forDate)
                        {
                            art.Add(b);
                        }
                    }
                }
                ViewBag.Articles = art;
                return View();
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                var art = new List<Article>();
                foreach (Article b in db.Articles)
                {
                    if(!String.IsNullOrEmpty(b.Tags))
                    {
                        if (b.Tags.Contains(searchString) && articleCat == b.Category && b.Time > fromDate && b.Time < forDate)
                        {
                            art.Add(b);
                        }
                    }
                }
                ViewBag.Articles = art;
                return View();
            }
            if (articleCat!="All" && articleCat!=null)
            {
                var art = new List<Article>();
                foreach (Article b in db.Articles)
                {
                    if (articleCat == b.Category && b.Time > fromDate && b.Time < forDate)
                        art.Add(b);
                }
                ViewBag.Articles = art;
                return View();
            }
            var article = new List<Article>();
            foreach (Article b in db.Articles)
            {
                
                if (b.Time > fromDate && b.Time < forDate)
                    article.Add(b);
            }
            ViewBag.Articles = article;
            return View();
        }
        public ActionResult DeleteArticle(int? id)
        {
            Article article = db.Articles.Find(id);
            if(article==null)
            {
                return Redirect("MyArticles");
            }
            return View(article);
        }
        [HttpPost,ActionName("DeleteArticle")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return Redirect("MyArticles");
        }

        [Authorize]
        public ActionResult MyArticles()
        {
            List<Article> yourArticles = new List<Article>();
            foreach(var b in db.Articles)
            {
                if(b.UserMail==User.Identity.Name)
                {
                    yourArticles.Add(b);
                }
            }
            ViewBag.Articles = yourArticles;
            return View();
        }
        public RedirectResult YourArticle(Article article)
        {
            return Redirect($"/Home/ShowFull?id={article.ArticleId}");
        }
        [HttpGet]
        [Authorize]
        public ActionResult EditArticle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Article article = db.Articles.Find(id);
            if (article != null)
            {
                return View(article);
            }
            return HttpNotFound();
        }
        [HttpPost]
        [Authorize]
        public RedirectResult EditArticle(Article article)
        {
            article.Time = DateTime.Now;
            article.UserMail = User.Identity.Name;
            db.Entry(article).State = EntityState.Modified;
            db.SaveChanges();
            return YourArticle(article);
        }
        [Authorize]
        public ActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddArticle(AddArticleViewModel model,HttpPostedFileBase Photo)
        {
            byte[] imageDate = null;
            if (Photo != null)
            {
                using (var binaryReader = new BinaryReader(Photo.InputStream))
                {
                    imageDate = binaryReader.ReadBytes(Photo.ContentLength);
                }
            }
            Article article = new Article() { Name=model.Name,FullDescription=model.FullDescription,Tags=model.Tags,ShortDescription=model.ShortDescription,Category=model.Category};
            article.Picture = new Picture() { Name= Convert.ToString(article.ArticleId) ,Image= imageDate ,Id=article.ArticleId};
            article.Time = DateTime.Now;
            article.UserMail = User.Identity.Name;
            db.Articles.Add(article);
            db.SaveChanges();
            return YourArticle(article);
        }
        [HttpGet]
        public ActionResult ShowFull(int id)
        {
            Article article = db.Articles.Find(id);
            if(article==null)
            {
                return HttpNotFound();
            }
            ViewBag.Article = article;
            return View();
        }

        [HttpPost]
        [Authorize]
        public RedirectResult ShowFull(string textOfComment, int articleid)
        {
            Comment comment = new Comment() { Author = User.Identity.Name, Time = DateTime.Now, TextOfComment = textOfComment };
            Article articl = db.Articles.Find(articleid);
            if (articl != null)
            {
                if (articl.Comments == null)
                {
                    articl.Comments = new List<Comment>() { comment };
                }
                else
                {
                    articl.Comments.Add(comment);
                }
            }
            db.Entry(articl).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect($"ShowFull?id={articl.ArticleId}");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}