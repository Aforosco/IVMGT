using System;
using Invco.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invco.Models
{
	public class AssetViewModel
    {
        
        public int Id { get; set; }

        public string? AssetName { get; set; }

        public string? AssetUser { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Purchasedate { get; set; }
        
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public string? SerialNumber { get; set; }
       
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}

