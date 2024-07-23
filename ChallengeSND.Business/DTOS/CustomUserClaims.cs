using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSND.Business.DTOS
{
    public record CustomUserClaims(string Name = null!, string Email = null!);
}
