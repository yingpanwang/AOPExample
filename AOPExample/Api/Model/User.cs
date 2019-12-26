using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class User
    {

        [Required]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(11,ErrorMessage ="电话号码为11位")]
        [MinLength(11,ErrorMessage ="电话号码不少于11位")]
        public string PhoneNumber { get; set; }
    }
}
