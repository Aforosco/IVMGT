﻿using System;
using Mapster;
using Invco.Repository;
using Invco.Models;
using Invco.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Invco.Service
{
    public interface IAssetService
	{
        void InsertAsset(CreateAssetViewModel A);
        AllAssetViewModel GetAllAsset(int page = 1);
        AllAssetViewModel GetAllAssetByDepartmentId(int Id,int page=1);
        AssetViewModel GetSingleAsset(int Id);
        void DeleteAsset(int Id);
        void UpdateAsset(EditAssetViewModel A);
    }

    public class AssetService :IAssetService
	{
		private readonly IAssetRepo _iar;
		public AssetService(IAssetRepo iar)
		{
            _iar = iar;
        }

        public void DeleteAsset(int Id)
        {
            _iar.DeleteAsset(Id);
        }

        public AllAssetViewModel GetAllAsset(int page =1 )
        {
            int pageSize = 10;
            var allAssets=   _iar.GetAllAsset(page);
            var totalCount =  _iar.GetAssetCount();

            var viewModel = new AllAssetViewModel
            {
                Assets = allAssets.Select(a => new AssetViewModel
                {
                    Id = a.Id,
                    AssetName = a.AssetName,
                    AssetUser = a.AssetUser,
                    Purchasedate = a.Purchasedate,
                    SerialNumber = a.SerialNumber,
                    CategoryId = a.CategoryId,
                    CategoryName = a.Category?.CategoryName, // Map category name
                    DepartmentId = a.DepartmentId,
                    DepartmentName = a.Departments?.DepartmentName // Map department name
                }).ToList(),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return viewModel;
        }

        public AllAssetViewModel GetAllAssetByDepartmentId(int Id, int page = 1)
        {
            int pageSize = 10;

            var assetsindept = _iar.GetAllAssetByDepartmentId(Id);
            var totalCount = _iar.GetAssetCount();
            var viewModel = new AllAssetViewModel
            {
                Assets = assetsindept.Adapt<List<AssetViewModel>>(),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return viewModel;
        }

        public AssetViewModel GetSingleAsset(int Id)
        {
            var asset = _iar.GetSingleAsset(Id);

           if (asset == null)
            {
                throw new KeyNotFoundException($"Asset with ID {Id} was not found");
            }

            return new AssetViewModel
            {
                Id = asset.Id,
                AssetName = asset.AssetName,
                AssetUser = asset.AssetUser,
                Purchasedate = asset.Purchasedate,
                SerialNumber = asset.SerialNumber,
                CategoryId = asset.CategoryId,
                DepartmentId = asset.DepartmentId,

                // Explicitly mapping the navigation properties
                CategoryName = asset.Category?.CategoryName ?? "N/A",
                DepartmentName = asset.Departments?.DepartmentName ?? "N/A"
            };


        }

        public void InsertAsset(CreateAssetViewModel A)
        {
            var newAsset = A.Adapt<Asset>();
            _iar.InsertAsset(newAsset);
        }

        public void UpdateAsset(EditAssetViewModel A)
        {
            var asset = A.Adapt<Asset>();
            _iar.UpdateAsset(asset);
        }

        

    }
}

