using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Shared.Domain
{
    public class MenuItem : BaseDomainModel
    {
        public string FoodName { get; set; }
        public double Cost { get; set; }
        
    }

}
