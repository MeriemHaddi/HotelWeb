using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataHotel.Entite
{
    public class EquipementSolaire : Equipement
    {


        [Required]
        public double coeff { get; set; }
    }
    
    
}