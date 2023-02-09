using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet length requirements")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Address does not meet length requirements")]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}",ErrorMessage = "Contact Number is not a valid phone number")]
        public string Contact { get; set; }
      
    }

}
 