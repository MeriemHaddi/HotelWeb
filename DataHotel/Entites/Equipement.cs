using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataHotel.Entite
{
    public class Equipement
    {
        private int v;

        public string nom { get; set; }


        [Key]
        public int EquipementId { get; set; }

        [Required]
        [MaxLength(15)]
        public string code { get; set; }

        public string debit { get; set; }

        [Required]
        public double consommation { get; set; }
        public Equipement(double consommation, int EquipementId)
        {
            this.consommation = consommation;
            this.EquipementId = EquipementId;
        }
        public Equipement() { }

        public Equipement(int v)
        {
            this.v = v;
        }
    }
}