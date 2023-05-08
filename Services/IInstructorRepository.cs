using Project.Models;
using System.Collections.Generic;

namespace Project.Services
{
    public interface IInstructorRepository
    {
        int Create(Instructor newInst);
        int Delete(int id);
        List<Instructor> getAllByDeptId(int departmentId);
        List<Instructor> getAllWithDepartments();
        Instructor getById(int id);
        Instructor getByName(string name);
        int Update(int id, Instructor NewInst);
    }
}