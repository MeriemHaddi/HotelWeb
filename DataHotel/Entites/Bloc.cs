using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataHotel.Entite
{
    public class Bloc
    {
        [Key]
        public int BlocId { get; set; }

        [Required]
        public int numero { get; set; }

        [MaxLength(25)]
        public string responsable { get; set; }

        public List<Chambre> chambres { get; set; }

        public Bloc(List<Chambre> chambres, int BlocId)
        {
            this.chambres = chambres;
            this.BlocId = BlocId;
        }

        public Bloc(List<Chambre> chambres)
        {
            this.chambres = chambres;
        }
        public Bloc() { }


    }
}