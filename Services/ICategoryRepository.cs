using Project.Models;
using System.Collections.Generic;

namespace Project.Services
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        int Create(Category category);
    }
}