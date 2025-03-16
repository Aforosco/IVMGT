﻿using System;
namespace Invco.Models
{
	public class CreateAssetViewModel
    {
       
        public string? AssetName { get; set; }

        public string? AssetUser { get; set; }

        public DateTime? Purchasedate { get; set; }

        public int CategoryId { get; set; }

        public string? SerialNumber { get; set; }

        public int DepartmentId { get; set; }


    }
}

