using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Code_First.Models;

namespace Gmf.Demo.EFUpdate.Models
{
    public class Role:EntityBase
    {
        public Role()
        {
            Members = new HashSet<Member>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
