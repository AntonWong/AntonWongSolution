using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gmf.Demo.EFUpdate.Models;

namespace Code_First.Models
{
    public class Department : EntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
