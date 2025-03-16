using System;
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
        Asset GetSingleAsset(int Id);
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
            var allasset=   _iar.GetAllAsset(page);
            var totalCount =  _iar.GetAssetCount();

            var viewModel = new AllAssetViewModel
            {
                Assets = allasset.Adapt<List<AssetViewModel>>(), 
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

        public Asset GetSingleAsset(int Id)
        {
            var assets = _iar.GetSingleAsset(Id);
            return assets;
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

