using System;
namespace Invco.Models
{
	public class AllAssetViewModel
	{
        public IEnumerable<AssetViewModel> Assets { get; set; } = new List<AssetViewModel>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}

