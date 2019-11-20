using ItBlog.Models;

namespace ItBlog.Repositories
{
    public interface IBlogRepository
    {
        BlogContext GetData();
    }
}
