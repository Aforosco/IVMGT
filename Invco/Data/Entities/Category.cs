using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invco.Data.Entities
{
	public class Category
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		public string? CategoryName { get; set; }
		public ICollection<Asset>? Asset { get; set; }
	}
}

