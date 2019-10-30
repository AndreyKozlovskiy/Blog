using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItBlog.Models
{
    public class ArticleCategoryViewModel
    {
        public List<Article> Articles { get; set; }
        public SelectList Categories { get; set; }
        public string ArticleCategory { get; set; }
        //public string SearchString { get; set; }
    }
}