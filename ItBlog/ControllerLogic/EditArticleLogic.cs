using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ItBlog.Models;

namespace ItBlog.ControllerLogic
{
    public static class EditArticleLogic
    {
        static public int EditArticle(Article article,string UserMail)
        {
            BlogContext db = DbLogic.GetDB();
            Article changedArticle=db.Articles.Find(article.ArticleId);
            article.Time = DateTime.Now;
            article.UserMail = UserMail;
            db.Articles.Remove(changedArticle);
            db.Articles.Add(article);
            db.SaveChanges();
            DbLogic.SetDb(db);
            return article.ArticleId;
        }
    }
}