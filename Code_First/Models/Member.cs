using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Gmf.Demo.EFUpdate.Models
{
    public class Member:EntityBase
    {
        public Member()
        {
            Roles = new HashSet<Role>();
        }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
