using ItBlog.Models;
using System;
using System.Linq;

namespace ItBlog.ControllerLogic
{
    static public class AddCategoryLogic
    {
        static public string AddCategory(Category model)
        {
            BlogContext db= DbLogic.GetDB();
            if(db.Categories.Contains(model))
            {
                return "This category is exists";
            }
            if(model!=null)
            db.Categories.Add(model);
            return ("Your category was created");
        }   
    }
}