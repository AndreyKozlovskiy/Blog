using System;
using System.Collections.Generic;
using System.Linq;
using ItBlog.Models;
using System.Web;

namespace ItBlog.ControllerLogic
{
    
    public static class DbLogic
    {
        static BlogContext db = new BlogContext();
        static public BlogContext GetDB()
        {
            return db;
        }
        static public List<Article> GetArticlesOfUser(string userMail)
        {
            return (from t in db.Articles
                    where t.UserMail == userMail
                    select t).ToList<Article>(); 

        }
        static public void DeleteArticle(int articleId)
        {
            Article article=db.Articles.Find(articleId);
            db.Articles.Remove(article);
            db.SaveChanges();
        }
        static public Article GetArticle(int? id)
        {
            Article article=db.Articles.Find(id);
            return article;
        }
        static public void SetDb(BlogContext Db)
        {
            db = Db;
            db.SaveChanges();
        }
        static public IQueryable<Tag> GetTags(BlogContext db)
        {
            return (from t in db.Tags
                    select t);
        }
        static public IQueryable<Category> GetCategories(BlogContext db)
        {
            return (from t in db.Categories
                    select t);
        }
    }
}