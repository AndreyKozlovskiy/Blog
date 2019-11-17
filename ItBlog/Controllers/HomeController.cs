using ItBlog.ControllerLogic;
using ItBlog.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string articleCat, string searchString, DateTime? fromDate, DateTime? forDate)
        {
            BlogContext db=DbLogic.GetDB();
            ViewBag.Categories = DbLogic.GetCategories(db);
            ViewBag.Articles = StartPageLogic.Search(articleCat,searchString,fromDate,forDate);
            return View();
        }

        public ActionResult DeleteArticle(int? id)
        {
            Article article = DbLogic.GetArticle(id);
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
            DbLogic.DeleteArticle(id);
            return Redirect("MyArticles");
        }

        [Authorize]
        public ActionResult MyArticles()
        {
            ViewBag.Articles = DbLogic.GetArticlesOfUser(User.Identity.Name);
            return View();
        }
        public RedirectResult YourArticle(int articleId)
        {
            return Redirect($"/Home/ShowFull?id={articleId}");
        }
        [HttpGet]
        [Authorize]
        public ActionResult EditArticle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Article article = DbLogic.GetArticle(id);
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
            int articleId=EditArticleLogic.EditArticle(article, User.Identity.Name);
            return Redirect($"ShowFull?id={articleId}");
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddArticle()
        {
            AddArticleViewModel a = new AddArticleViewModel();
            BlogContext blogContext = DbLogic.GetDB();
            a.CategoryList = DbLogic.GetCategories(blogContext) ;
            a.TagsList = DbLogic.GetTags(blogContext).ToList<Tag>();
            return View(a);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddArticle(AddArticleViewModel model,HttpPostedFileBase Photo)
        {
            int articleId=AddArticleLogic.AddArticle(model, Photo, User.Identity.Name);
            return Redirect($"ShowFull?id={articleId}");
        }
        [HttpGet]
        public ActionResult ShowFull(int id)
        {
            Article article = DbLogic.GetArticle(id);
            if(article==null)
            {
                return HttpNotFound();
            }
            ViewBag.Article = article;
            return View();
        }

        [HttpPost]
        [Authorize]
        public RedirectResult ShowFull(string textOfComment, int articleId)
        {
            AddCommentLogic.AddComment(textOfComment, articleId, User.Identity.Name);
            return Redirect($"ShowFull?id={articleId}");
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