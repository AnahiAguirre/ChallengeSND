using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSND.Business.DTOS
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, Compare(nameof(Password)), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
