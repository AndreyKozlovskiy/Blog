using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ItBlog.Models;

namespace ItBlog.ControllerLogic
{
    public static class StartPageLogic
    {
        static public List<Article> Search(string articleCat, string searchString, DateTime? fromDate, DateTime? forDate)
        {
            BlogContext db = DbLogic.GetDB();
            if (fromDate == null)
                fromDate = new DateTime(2019, 1, 1);
            if (forDate == null)
                forDate = new DateTime(2080, 1, 1);
            bool isTagsContainsAll = true;
            if (!String.IsNullOrEmpty(searchString) && articleCat == "All")
            {
                var art = new List<Article>();
                var tagsToFind = searchString.Split(' ').ToList<string>();
                foreach (Article b in db.Articles)
                {
                    if (!String.IsNullOrEmpty(b.Tags))
                    {
                        if (b.Time > fromDate && b.Time < forDate)
                        {
                            isTagsContainsAll = true;
                            foreach (var i in tagsToFind)
                            {
                                if (!b.Tags.Contains(i))
                                {
                                    isTagsContainsAll = false;
                                }
                            }
                            if (isTagsContainsAll)
                                art.Add(b);
                        }
                    }
                }
                return art;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                var tagsToFind = searchString.Split(' ').ToList<string>();
                var art = new List<Article>();
                foreach (Article b in db.Articles)
                {
                    if (!String.IsNullOrEmpty(b.Tags))
                    {
                        if (b.Tags.Contains(searchString) && articleCat == b.Category && b.Time > fromDate && b.Time < forDate)
                        {
                            isTagsContainsAll = true;
                            foreach (var i in tagsToFind)
                            {
                                if (!b.Tags.Contains(i))
                                {
                                    isTagsContainsAll = false;
                                }
                            }
                            if (isTagsContainsAll)
                                art.Add(b);
                        }
                    }
                }
                return art;
            }
            var article = new List<Article>();
            foreach (Article b in db.Articles)
            {
                if (b.Time > fromDate && b.Time < forDate)
                    article.Add(b);
            }
            return article;
        }
    }
}