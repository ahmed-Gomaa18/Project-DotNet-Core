using Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        Context context;
        // Inject Context Object By Ioc Container
        public DepartmentRepository(Context _context)
        {
            context = _context;
        }

        public List<Department> getAll()
        {
            return context.Departments.ToList();
        }
        public Department getById(int id)
        {
            return context.Departments.FirstOrDefault(D => D.ID == id);
        }
        public int Update(int id, Department department)
        {
            Department dept = getById(id);
            dept.Manager = department.Manager;

            int RES = context.SaveChanges();
            return RES;
        }
        public int Delete(int id)
        {
            Department department = getById(id);
            context.Departments.Remove(department);

            int RES = context.SaveChanges();
            return RES;
        }
    }
}
