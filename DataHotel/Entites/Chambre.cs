using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataHotel.Entite
{
    public class Chambre
    {
        private List<Equipement> equipements;

        [Key]
        public int ChambreId { get; set; }

        [Required]
        public int numero { get; set; }

        [MaxLength(15)]
        public string type { get; set; }
        public List<Equipement> Eqts { get; set; }

        public Chambre()
        {

        }

        public Chambre(List<Equipement> Eqts, int ChambreId)
        {
            this.Eqts = Eqts;
            this.ChambreId = ChambreId;
        }

        public Chambre(List<Equipement> equipements)
        {
            this.equipements = equipements;
        }

        public double calcul_consommation()
        {
            double sum = 0;
            foreach (Equipement e in Eqts)
            {
                sum = sum + e.consommation;
            }
            return sum;


        }
    }
}