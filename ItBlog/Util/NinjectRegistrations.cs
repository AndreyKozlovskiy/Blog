using ItBlog.Repositories;
using Ninject.Modules;

namespace ItBlog.Util
{
    public class NinjectRegistrations:  NinjectModule
    {
        public override void Load()
        {
            Bind<IBlogRepository>().To<BlogRepository>();
        }
    }
}