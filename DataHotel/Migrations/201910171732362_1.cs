namespace DataHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blocs",
                c => new
                    {
                        BlocId = c.Int(nullable: false, identity: true),
                        numero = c.Int(nullable: false),
                        responsable = c.String(maxLength: 25),
                        Hotell_HotellId = c.Int(),
                    })
                .PrimaryKey(t => t.BlocId)
                .ForeignKey("dbo.Hotells", t => t.Hotell_HotellId)
                .Index(t => t.Hotell_HotellId);
            
            CreateTable(
                "dbo.Chambres",
                c => new
                    {
                        ChambreId = c.Int(nullable: false, identity: true),
                        numero = c.Int(nullable: false),
                        type = c.String(maxLength: 15),
                        Bloc_BlocId = c.Int(),
                    })
                .PrimaryKey(t => t.ChambreId)
                .ForeignKey("dbo.Blocs", t => t.Bloc_BlocId)
                .Index(t => t.Bloc_BlocId);
            
            CreateTable(
                "dbo.Equipements",
                c => new
                    {
                        EquipementId = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        code = c.String(nullable: false, maxLength: 15),
                        debit = c.String(),
                        consommation = c.Double(nullable: false),
                        coeff = c.Double(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Chambre_ChambreId = c.Int(),
                    })
                .PrimaryKey(t => t.EquipementId)
                .ForeignKey("dbo.Chambres", t => t.Chambre_ChambreId)
                .Index(t => t.Chambre_ChambreId);
            
            CreateTable(
                "dbo.Hotells",
                c => new
                    {
                        HotellId = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false, maxLength: 25),
                        adresse = c.String(),
                        numtel = c.String(nullable: false, maxLength: 8),
                        dateouverture = c.DateTime(nullable: false),
                        mail = c.String(nullable: false, maxLength: 25),
                        responsable = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.HotellId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blocs", "Hotell_HotellId", "dbo.Hotells");
            DropForeignKey("dbo.Chambres", "Bloc_BlocId", "dbo.Blocs");
            DropForeignKey("dbo.Equipements", "Chambre_ChambreId", "dbo.Chambres");
            DropIndex("dbo.Equipements", new[] { "Chambre_ChambreId" });
            DropIndex("dbo.Chambres", new[] { "Bloc_BlocId" });
            DropIndex("dbo.Blocs", new[] { "Hotell_HotellId" });
            DropTable("dbo.Hotells");
            DropTable("dbo.Equipements");
            DropTable("dbo.Chambres");
            DropTable("dbo.Blocs");
        }
    }
}
