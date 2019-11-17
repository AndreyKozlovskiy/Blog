using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItBlog.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FullDescription { get; set; }
        [Required]
        public string Category { get; set; }
        public DateTime Time { get; set; }
        public string ShortDescription { get; set; }
        public string UserMail { get; set; }
        public string Tags { get; set; }
        public Picture Picture { get; set; }
        public List<Comment> Comments { get; set; }
    }
}