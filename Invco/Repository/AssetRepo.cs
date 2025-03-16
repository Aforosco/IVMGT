using System;
using Invco.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Invco.Repository
{
	public interface IAssetRepo
	{
		void InsertAsset(Asset A);
		Task<List<Asset>> GetAllAsset(int page = 1);
        Task<List<Asset>> GetAllAssetByDepartmentId(int Id, int page = 1);
		Asset GetSingleAsset(int Id);
		void DeleteAsset(int Id);
		void UpdateAsset(Asset A);
        int GetAssetCount();


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
        }

        public async Task<List<Asset>> GetAllAsset(int page = 1)
        {
            int pageSize = 10;
            var assets  = await _db.Assets.OrderBy(A=>A.Id).Skip((page-1)*pageSize).ToListAsync();
            return assets;
        }


        public int GetAssetCount()
        {
            return _db.Assets.Count();
        }
        public async Task<List<Asset>> GetAllAssetByDepartmentId(int Id, int page =1)
        {
            int pageSize = 10;
            return await _db.Assets.Where(d=>d.DepartmentId.Equals(Id)).OrderBy(A => A.Id).Skip((page - 1) * pageSize).ToListAsync();
        }

        public Asset GetSingleAsset(int Id)
        {
            var Item =  _db.Assets.Find(Id);
            if (Item == null)
                throw new KeyNotFoundException($"Itemm with ID {Id} was not found");
            return Item;
        }
    

        public void InsertAsset(Asset A)
        {
            _db.Assets.Add(A);
            _db.SaveChanges();
        }

        public void UpdateAsset(Asset As)
        {
            var assettoedit = _db.Assets.Where(A => A.Id == As.Id).FirstOrDefault();

            if (assettoedit == null)
                throw new KeyNotFoundException($"Itemm with ID {As.Id} was not found");
            assettoedit.AssetName = As.AssetName;
            assettoedit.AssetUser = As.AssetUser;
            assettoedit.Category = As.Category;
            assettoedit.Departments = As.Departments;
            assettoedit.Purchasedate = As.Purchasedate;
            _db.SaveChanges();
        }

       
    }
}

