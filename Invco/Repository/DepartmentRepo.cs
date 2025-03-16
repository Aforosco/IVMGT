using System;
using Invco.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invco.Repository
{
	public interface IDepartmentRepo
	{
        void InsertDepartment(Department D);
        Task<List<Department>> GetAllDepartments();
        void DeleteDepartment(int Id);


    }
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDbContext _db;
        public DepartmentRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public void DeleteDepartment(int Id)
        {
            var deleteItem = _db.Departments.Find(Id);
            if (deleteItem == null)
                throw new KeyNotFoundException($"Itemm with ID {Id} was not found");
            _db.Departments.Remove(deleteItem);
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _db.Departments.ToListAsync();
        }

        public void InsertDepartment(Department D)
        {
            _db.Departments.Add(D);
            _db.SaveChanges();
        }
    }
}

