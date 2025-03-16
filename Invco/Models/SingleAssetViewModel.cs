using System;
namespace Invco.Models
{
	public class SingleAssetViewModel
    {
        public int Id { get; set; }

        public string? AssetName { get; set; }

        public string? AssetUser { get; set; }

        public DateTime? Purchasedate { get; set; }

        public int CategoryId { get; set; }

        public string? SerialNumber { get; set; }

        public int DepartmentId { get; set; }

    }
}

