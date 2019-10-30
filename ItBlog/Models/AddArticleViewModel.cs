using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ItBlog.Models
{
    public class AddArticleViewModel
    {
        public int ArticleId { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Max 50 characters")]
        public string Name { get; set; }
        [Required]
        public string FullDescription { get; set; }
        [Required]
        public string Category { get; set; }
        public DateTime Time { get; set; }
        [MaxLength(100, ErrorMessage = "Max 100 characters")]
        public string ShortDescription { get; set; }
        public string UserMail { get; set; }
        public string Tags { get; set; }
    }
}