using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string TextOfComment { get; set; }
        public DateTime Time { get; set; }
    }
}