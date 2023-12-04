﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Entities.Models
{
    [Table("Administrator")]
    public class Administrator : KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

    }
}
