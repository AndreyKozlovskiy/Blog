using ItBlog.Models;

namespace ItBlog.ControllerLogic
{
    public static class EditCategoryLogic
    {
        static public void EditCategory(Category category)
        {
            BlogContext db = DbLogic.GetDB();
            Category changedCategory = db.Categories.Find(category.CategoryId);
            foreach(var b in db.Articles)
            {
                if(changedCategory.CategoryName==b.Category)
                {
                    b.Category = category.CategoryName;
                }
            }
            db.Categories.Remove(changedCategory);
            db.Categories.Add(category);
            db.SaveChanges();
            DbLogic.SetDb(db);
        }
    }
}