using DataHotel.Entite;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHotel
{
    public class MyDBContextHotel : DbContext

    {
        public MyDBContextHotel() : base("MyBDContextHotel") { }
        public DbSet<Chambre> DbSetChambre { get; set; }

        public void addChambre(Chambre ch)
        {
            DbSetChambre.Add(ch);
            SaveChanges();
        }
        public DbSet<Bloc> DbSetBloc { get; set; }

        public void addBloc(Bloc ch)
        {
            DbSetBloc.Add(ch);
            SaveChanges();
        }



        public DbSet<Hotell> DbSetHotel { get; set; }

        public void addHotel(Hotell e)
        {
            DbSetHotel.Add(e);
            SaveChanges();
        }
        public DbSet<Equipement> DbSetEquipement { get; set; }

        public void addEquipement(Equipement eq)
        {
            DbSetEquipement.Add(eq);
            SaveChanges();
        }

        public DbSet<EquipementElectrique> DbSetEquipementElectrique { get; set; }

        public void addEquipementElectrique(EquipementElectrique ch)
        {
            DbSetEquipementElectrique.Add(ch);
            SaveChanges();
        }

        public DbSet<EquipementSolaire> DbSetEquipementSolaire { get; set; }

        public void addEquipementSolaire(EquipementSolaire ch2)
        {
            DbSetEquipementSolaire.Add(ch2);
            SaveChanges();
        }

        //protected override void OnModelCreating(DbModelBuilder DBM)
        //{
        //    DBM.Configurations.Add(new HotelConfiguration());
        //}
    }

}
