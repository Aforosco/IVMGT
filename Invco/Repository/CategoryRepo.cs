using System;
using Invco.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invco.Repository
{
	public interface ICategoryRepo
	{
        void InsertCategory(Category C);
        List<Category> GetAllCategories();
        void DeleteCategory(int Id);


    }
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public void DeleteCategory(int Id)
        {
            var deleteItem = _db.Categories.Find(Id);
            if (deleteItem == null)
                throw new KeyNotFoundException($"Itemm with ID {Id} was not found");
            _db.Categories.Remove(deleteItem);
        }

        public List<Category> GetAllCategories()
        {
            return  _db.Categories.ToList();
        }

        public void InsertCategory(Category C)
        {
            _db.Categories.Add(C);
            _db.SaveChanges();
        }
    }
}

