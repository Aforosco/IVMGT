using System;
using Invco.Data.Entities;
using Invco.Models;
using Invco.Repository;
using Mapster;

namespace Invco.Service
{
	public interface ICategoryService
	{
        void InsertCategory(CreateCategoryViewModel C);
        AllCategoryViewModel GetAllCategories();
        void DeleteCategory(int Id);

    }
    public class CategoryService :ICategoryService
	{
		private readonly ICategoryRepo _icr;
		public CategoryService(ICategoryRepo icr)
		{
            _icr = icr;
        }

        public void DeleteCategory(int Id)
        {
            _icr.DeleteCategory(Id);
        }

        public AllCategoryViewModel GetAllCategories()
        {
            var cat = _icr.GetAllCategories();
            var viewModel = new AllCategoryViewModel
            {
                Categories = cat.Adapt<List<CategoryViewModel>>()
            };
            return viewModel;
        }
        public void InsertCategory(CreateCategoryViewModel C)
        {
            var newCategory = C.Adapt<Category>();
            _icr.InsertCategory(newCategory);
        }
    }
}

