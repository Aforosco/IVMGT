using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invco.Data.Entities
{
	public class Asset
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

	    public string? AssetName { get; set; }

		public string? AssetUser { get; set; }
        public string? SerialNumber { get; set; }
        public DateTime? Purchasedate { get; set; }
		[ForeignKey("Id")]
		public int CategoryId { get; set; }
		public virtual Category? Category { get; set; }
        [ForeignKey("Id")]
        public int DepartmentId { get; set; }
		public virtual Department? Departments { get; set; }


	}
}

