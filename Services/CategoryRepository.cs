using Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        Context context;

        public CategoryRepository(Context _context)
        {
            context = _context;
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public int Create(Category category)
        {
            context.Categories.Add(category);
            int RES = context.SaveChanges();
            return RES;
        }


    }
}
