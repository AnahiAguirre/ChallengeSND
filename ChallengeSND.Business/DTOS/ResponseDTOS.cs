﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSND.Business.DTOS
{

    public class ResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
        public object Result { get; set; } = null!;
    }
}
