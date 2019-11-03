using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItBlog.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public byte[] Image {get; set;}
    }
}