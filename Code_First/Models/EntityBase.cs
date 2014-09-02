using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gmf.Demo.EFUpdate.Models
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            AddDate = DateTime.Now;
            IsDeleted = false;
        }

        public int Id { get; set; }

        public DateTime AddDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
