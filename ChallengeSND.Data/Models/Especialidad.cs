﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSND.Data.Models
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Medico> Medicos { get; set; }
    }

}