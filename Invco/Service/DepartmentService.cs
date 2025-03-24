using System;
using Invco.Data.Entities;
using Invco.Data.Migrations;
using Invco.Models;
using Invco.Repository;
using Mapster;
namespace Invco.Service

{
	public interface IDepartmentService
	{
        void InsertDepartment(CreateDepartmentViewModel D);
        AllDepartmentViewModel GetAllDepartments();
        void DeleteDepartment(int Id);
        int GetDepartmentCount();
    }

	
	public class DepartmentService : IDepartmentService
	{
        private readonly IDepartmentRepo _idr;
        public DepartmentService(IDepartmentRepo idr)
		{
            _idr = idr;
        }

        public void DeleteDepartment(int Id)
        {
            _idr.DeleteDepartment(Id);
        }

        public AllDepartmentViewModel GetAllDepartments()
        {
            var Dept = _idr.GetAllDepartments();
            var viewModel = new AllDepartmentViewModel
            {
                departments = Dept.Select(d => new DepartmentViewModel
                {
                    Id = d.Id,
                    DepartmentName = d.DepartmentName
                }).ToList()
            };
            return viewModel;
        }

        public void InsertDepartment(CreateDepartmentViewModel D)
        {
            var newDept = D.Adapt<Department>();
            _idr.InsertDepartment(newDept);
        }

        public int GetDepartmentCount()
        {
            return _idr.GetDepartmentCount();
        }
    }
}

