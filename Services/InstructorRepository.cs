using Microsoft.EntityFrameworkCore;
using Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.Services
{
    public class InstructorRepository : IInstructorRepository
    {
        Context context;
        // Inject Context Object By Ioc Container
        public InstructorRepository(Context _context)
        {
            context = _context;
        }

        public Instructor getByName(string name)
        {
            return context.Instructors.FirstOrDefault(x => x.Name == name);
        }

        public List<Instructor> getAllByDeptId(int departmentId)
        {
            return context.Instructors.Where(I => I.DepartmentID == departmentId).ToList();
        }

        public List<Instructor> getAllWithDepartments()
        {
            // AsSingleQuery() Better Pereformance
            return context.Instructors.AsSingleQuery().Include(i => i.Department).ToList();
        }

        public Instructor getById(int id)
        {
            return context.Instructors.FirstOrDefault(I => I.ID == id);
        }

        public int Create(Instructor newInst)
        {
            context.Instructors.Add(newInst);
            int RES = context.SaveChanges();
            return RES;
        }

        public int Update(int id, Instructor NewInst)
        {
            Instructor inst = getById(id);

            if (inst != null)
            {
                inst.Name = NewInst.Name == null ? inst.Name : NewInst.Name;
                inst.Address = NewInst.Address == null ? inst.Address : NewInst.Address;
                inst.Image = NewInst.Image == null ? inst.Image : NewInst.Image;
                inst.Salary = NewInst.Salary == 0 ? inst.Salary : NewInst.Salary;
                inst.DepartmentID = NewInst.DepartmentID == 0 ? inst.DepartmentID : NewInst.DepartmentID;
                
                int RES = context.SaveChanges();
                return RES;
            }

            return 0;


        }

        public int Delete(int id)
        {
            Instructor instructor = getById(id);
            context.Instructors.Remove(instructor);

            int RES = context.SaveChanges();
            return RES;
        }


    }

}
