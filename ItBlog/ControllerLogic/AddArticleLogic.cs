using ItBlog.Models;
using System;
using System.IO;
using System.Web;


namespace ItBlog.ControllerLogic
{
    static public class AddArticleLogic
    {
        static public  int AddArticle(AddArticleViewModel model, HttpPostedFileBase Photo,string UserMail)
        {

            byte[] imageDate = null;
            if (Photo != null)
            {
                using (var binaryReader = new BinaryReader(Photo.InputStream))
                {
                    imageDate = binaryReader.ReadBytes(Photo.ContentLength);
                }
            }
            string tagsString = null;
            foreach (var b in model.TagsList)
            {
                tagsString += b + " ";
            }
            Article article = new Article() { Name = model.Name, FullDescription = model.FullDescription, Tags = tagsString, ShortDescription = model.ShortDescription, Category = model.Category };
            article.Picture = new Picture() { Name = Convert.ToString(article.ArticleId), Image = imageDate, Id = article.ArticleId };
            article.Time = DateTime.Now;
            article.UserMail = UserMail;
            BlogContext  blogContext= DbLogic.GetDB();
            blogContext.Articles.Add(article);
            blogContext.SaveChanges();
            DbLogic.SetDb(blogContext);
            return article.ArticleId;
        }
    }
}