using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Shared.Domain
{
    public class Order : BaseDomainModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int MenuItemID { get; set; }
        public int CustomerID { get; set; }
        public int RiderID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Rider Rider { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        
}

    }


