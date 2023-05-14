using Microsoft.EntityFrameworkCore;
using Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        Context context;

        public EmployeeRepository(Context _context)
        {
            context = _context;
        }

        public Employee GetByID(int id)
        {
            return context.Employees.FirstOrDefault(E => E.ID == id);
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public List<Employee> GetAllWithCategories()
        {
            return context.Employees.AsSingleQuery().Include(E => E.Category).ToList();
        }

        public int Create(Employee employee)
        {
            context.Employees.Add(employee);
            int RES = context.SaveChanges();
            return RES;
        }

        public int Update(int id, Employee newEmployee)
        {
            Employee oldEmployee = GetByID(id);

            if (oldEmployee != null)
            {
                oldEmployee.Name = newEmployee.Name == null ? oldEmployee.Name : newEmployee.Name;
                oldEmployee.Address = newEmployee.Address == null ? oldEmployee.Address : newEmployee.Address;
                oldEmployee.Level = newEmployee.Level == null ? oldEmployee.Level : newEmployee.Level;
                oldEmployee.CategoryID = newEmployee.CategoryID == 0 ? oldEmployee.CategoryID : newEmployee.CategoryID;

                int RES = context.SaveChanges();
                return RES;
            }

            return 0;
        }

        public int Delete(int id)
        {
            Employee employee = GetByID(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                int RES = context.SaveChanges();
                return RES;
            }
            return 0;

        }
    }
}
