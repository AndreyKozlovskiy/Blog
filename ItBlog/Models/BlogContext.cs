using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Drawing;
using System.Data.Entity.Validation;
using System.Net;

namespace ItBlog.Models
{
    public class BlogContext:DbContext
    {
        public DbSet<Article> Articles { get; set; }
    }
    
    public class BlogDbInitializer:DropCreateDatabaseAlways<BlogContext>
    {

        protected override void Seed(BlogContext db)
        {
            
            db.Articles.Add(new Article { Category = "C#", Name = "Name", FullDescription = "I love C#", ShortDescription = "Short Description", Time = new DateTime(2019, 10, 20), UserMail = "caratosandre@gmail.com", Tags = "sad", Picture = null, Comments = new List<Comment>() { new Comment() { Author = "carat", TextOfComment = "Very good", Time = DateTime.Now } } });
            db.Articles.Add(new Article { Category = "C#", Name = "Name", FullDescription = "I love C#", ShortDescription = "Short Description", Time = new DateTime(2019, 10, 20), UserMail = "caratosandre@gmail.com", Tags = "IE DS", Picture = null ,Comments=null});
            db.Articles.Add(new Article { Category = "C#", Name = "Name", FullDescription = "I love C#", ShortDescription = "Short Description", Time = new DateTime(2019, 10, 20), UserMail = "caratosandre@gmail.com", Tags="RD XC", Picture = null ,Comments=null}) ;
            db.SaveChanges();
            base.Seed(db);
        }
    }
}
