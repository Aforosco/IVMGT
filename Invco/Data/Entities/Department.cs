using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invco.Data.Entities
{
	public class Department
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? DepartmentName { get; set; }
        public ICollection<Asset>? Asset { get; set; }
    }
}


