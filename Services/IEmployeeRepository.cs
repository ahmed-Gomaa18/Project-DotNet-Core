using Project.Models;
using System.Collections.Generic;

namespace Project.Services
{
    public interface IEmployeeRepository
    {
        int Create(Employee employee);
        int Delete(int id);
        List<Employee> GetAll();

        List<Employee> GetAllWithCategories();

        Employee GetByID(int id);
        int Update(int id, Employee newEmployee);
    }
}