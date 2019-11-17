using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ItBlog.Models;

namespace ItBlog.ControllerLogic
{
    public static class AddCommentLogic
    {
        public static void AddComment(string textOfComment, int articleId, string UserMail)
        {
            Comment comment = new Comment() { Author = UserMail, Time = DateTime.Now, TextOfComment = textOfComment };
            Article articl = DbLogic.GetArticle(articleId);
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
            BlogContext db = DbLogic.GetDB();
            db.Entry(articl).State = EntityState.Modified;
            db.SaveChanges();
            DbLogic.SetDb(db);
        }
    }
}