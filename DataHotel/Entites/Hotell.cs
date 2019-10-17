using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataHotel.Entite
{
    public class Hotell
    {
        [Key]
        public int HotellId { get; set; }

        [MaxLength(25, ErrorMessage = "error")]
        [Required]
        public string nom { get; set; }

        public string adresse { get; set; }

        [Required]
        [MaxLength(8)]
        public string numtel { get; set; }

        public DateTime dateouverture { get; set; }

        [Required]
        [MaxLength(25)]
        public string mail { get; set; }

        [MaxLength(25)]
        public string responsable { get; set; }
        public List<Bloc> blocs { get; set; }

        public Hotell(List<Bloc> blocs, int HotellId)
        {
            this.blocs = blocs;
            this.HotellId = HotellId;
        }

        public Hotell(List<Bloc> blocs)
        {
            this.blocs = blocs;
        }
        public Hotell() { }


    }
}