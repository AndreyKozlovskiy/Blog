using ItBlog.Models;
using System;

namespace ItBlog.Repositories
{
    public class BlogRepository:IBlogRepository
    {
        private readonly BlogContext _blogContext;

        public BlogRepository(BlogContext blogContext)
        {
            if (blogContext == null)
            {
                throw new NullReferenceException();
            }

            _blogContext = blogContext;
        }
        public BlogContext GetData()
        {
            return _blogContext;

        }
    }
}