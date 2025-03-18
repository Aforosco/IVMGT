using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Invco.Models
{
	public class EditAssetViewModel
    {
        public int Id { get; set; }
        public string? AssetName { get; set; }

        public string? AssetUser { get; set; }

        public DateTime? Purchasedate { get; set; }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public string? SerialNumber { get; set; }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public IEnumerable<SelectListItem>? Categories { get; set; }
        public IEnumerable<SelectListItem>? Departments { get; set; }
    }
}

