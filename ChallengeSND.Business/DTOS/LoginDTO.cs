using System.ComponentModel.DataAnnotations;

namespace ChallengeSND.Business.DTOS
{
    public class LoginDTO
    {
        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
