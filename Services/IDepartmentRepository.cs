using Project.Models;
using System.Collections.Generic;

namespace Project.Services
{
    public interface IDepartmentRepository
    {
        int Delete(int id);
        List<Department> getAll();
        Department getById(int id);
        int Update(int id, Department department);
    }
}