﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Giorno1.GestioneEsami.Core.Entities
{
    public class Esame
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Passato { get; set; }
        public int IdStudente { get; set; }
    }
}
