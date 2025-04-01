using System;
using Invco.Data.Entities;
using Invco.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace Invco.Repository
{
	public interface IAssetRepo
	{
		void InsertAsset(Asset A);
		List<Asset> GetAllAsset(int page = 1, string SortColumn = "Id", string IconClass = "fa-sort-asc");
        List<Asset> GetAllAssetByDepartmentId(int Id, int page = 1);
		Asset GetSingleAsset(int Id);
		void DeleteAsset(int Id);
		void UpdateAsset(Asset A);
        int GetAssetCount();
        int GetAssetCountbydepartmetID(int Id);


    }

    public class AssetRepo : IAssetRepo
    {
        private readonly ApplicationDbContext _db;
        public AssetRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public void DeleteAsset(int Id)
        {
            var deleteItem = _db.Assets.Find(Id);
            if (deleteItem == null)
                throw new KeyNotFoundException($"Itemm with ID {Id} was not found");
            _db.Assets.Remove(deleteItem);
            _db.SaveChanges();
        }

        public List<Asset> GetAllAsset(int page = 1, string SortColumn = "Id", string IconClass = "fa-sort-asc")
        {
            int pageSize = 10;

            IQueryable<Asset> query = _db.Assets
                .Include(a => a.Category)
                .Include(a => a.Departments);

            if (IconClass == "fa-sort-asc")
            {
                if (SortColumn == "DepartmentId")
                {
                    query = query.OrderBy(o => o.DepartmentId);
                }
                else if (SortColumn == "CategoryId")
                {
                    query = query.OrderBy(o => o.CategoryId);
                }
                else if (SortColumn == "AssetName")
                {
                    query = query.OrderBy(o => o.AssetName);
                }
                else
                {
                    query = query.OrderBy(o => o.Id); 
                }
            }
            else
            {
                if (SortColumn == "DepartmentId")
                {
                    query = query.OrderByDescending(o => o.DepartmentId);
                }
                else if (SortColumn == "CategoryId")
                {
                    query = query.OrderByDescending(o => o.CategoryId);
                }
                else if (SortColumn == "AssetName")
                {
                    query = query.OrderByDescending(o => o.AssetName);
                }
                else
                {
                    query = query.OrderByDescending(o => o.Id); 
                }
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }


        public int GetAssetCount()
        {
            return _db.Assets.Count();
        }
        public List<Asset> GetAllAssetByDepartmentId(int Id, int page =1)
        {
            int pageSize = 10;
             var assetsbydepartment =  _db.Assets.Include(c=>c.Category).Include(d=>d.Departments).Where(d=>d.DepartmentId.Equals(Id)).OrderBy(A => A.Id).Skip((page - 1) * pageSize).ToList();
            Console.WriteLine(assetsbydepartment);


            return assetsbydepartment;
        }
        public int GetAssetCountbydepartmetID(int Id)
        {
            var assetsbydepartmentcount =  _db.Assets.Include(c=>c.Category).Include(d=>d.Departments).Where(d => d.DepartmentId.Equals(Id)).Count();
            return assetsbydepartmentcount;

        }

        public Asset GetSingleAsset(int Id)
        {
            var Item = _db.Assets.Include(a => a.Category)
                 .Include(a => a.Departments).Where(s => s.Id == Id).FirstOrDefault() ?? throw new KeyNotFoundException($"Itemm with ID {Id} was not found");
            return Item;
        }
    

        public void InsertAsset(Asset A)
        {
            _db.Assets.Add(A);
            _db.SaveChanges();
        }

        public void UpdateAsset(Asset asset)
        {
            var assettoedit = _db.Assets.Find(asset.Id);
            if (assettoedit == null) throw new KeyNotFoundException("Asset not found");

            // Updating properties
            assettoedit.AssetName = asset.AssetName;
            assettoedit.AssetUser = asset.AssetUser;
            assettoedit.Purchasedate = asset.Purchasedate;
            assettoedit.SerialNumber = asset.SerialNumber;

            // Updating relationships
            assettoedit.CategoryId = asset.CategoryId;
            assettoedit.DepartmentId = asset.DepartmentId;

            _db.SaveChanges();

        }



    }
}

