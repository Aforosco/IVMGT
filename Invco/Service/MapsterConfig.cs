using System;
using Mapster;
using Invco.Data.Entities;
using Invco.Models;
using System.Reflection;
namespace Invco.Service
{
    public class MapsterConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AssetViewModel, Asset>().TwoWays()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.AssetName, s => s.AssetName)
                .Map(d => d.AssetUser, s => s.AssetUser)
                .Map(d => d.CategoryId, s => s.CategoryId)
                .Map(d => d.DepartmentId, s => s.DepartmentId)
                .Map(d => d.Purchasedate, s => s.Purchasedate)
                .Map(d => d.SerialNumber, s => s.SerialNumber);
            
            config.NewConfig<EditAssetViewModel, Asset>().TwoWays()
               .Map(d => d.AssetName, s => s.AssetName)
               .Map(d => d.AssetUser, s => s.AssetUser)
               .Map(d => d.CategoryId, s => s.CategoryId)
               .Map(d => d.DepartmentId, s => s.DepartmentId)
               .Map(d => d.Purchasedate, s => s.Purchasedate)
               .Map(d => d.SerialNumber, s => s.SerialNumber);
            config.NewConfig<CreateAssetViewModel, Asset>().TwoWays()
               .Map(d => d.AssetName, s => s.AssetName)
               .Map(d => d.AssetUser, s => s.AssetUser)
               .Map(d => d.CategoryId, s => s.CategoryId)
               .Map(d => d.DepartmentId, s => s.DepartmentId)
               .Map(d => d.Purchasedate, s => s.Purchasedate)
               .Map(d => d.SerialNumber, s => s.SerialNumber);

            config.NewConfig<SingleAssetViewModel, Asset>().TwoWays()
               .Map(d => d.Id, s => s.Id)
               .Map(d => d.AssetName, s => s.AssetName)
               .Map(d => d.AssetUser, s => s.AssetUser)
               .Map(d => d.CategoryId, s => s.CategoryId)
               .Map(d => d.DepartmentId, s => s.DepartmentId)
               .Map(d => d.Purchasedate, s => s.Purchasedate)
               .Map(d => d.SerialNumber, s => s.SerialNumber);
            config.NewConfig<CategoryViewModel, Category>().TwoWays()
               .Map(d => d.Id, s => s.Id)
               .Map(d => d.CategoryName, s => s.CategoryName);
            config.NewConfig<DepartmentViewModel, Department>().TwoWays()
              .Map(d => d.Id, s => s.Id)
              .Map(d => d.DepartmentName, s => s.DepartmentName);
            config.NewConfig<CreateDepartmentViewModel, Department>().TwoWays()
              .Map(d => d.DepartmentName, s => s.DepartmentName);
            config.NewConfig<CreateCategoryViewModel, Category>().TwoWays()
               .Map(d => d.CategoryName, s => s.CategoryName);



        }
    }
}
