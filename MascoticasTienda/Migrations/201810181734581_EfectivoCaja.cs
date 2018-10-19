namespace MascoticasTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EfectivoCaja : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Destinoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 50, storeType: "nvarchar"),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Efectivoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, precision: 0),
                        Tipo = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        Moneda_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Monedas", t => t.Moneda_ID)
                .Index(t => t.Moneda_ID);
            
            CreateTable(
                "dbo.Monedas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MonedaDes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MovimientoEfectivoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Destino = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false, precision: 0),
                        Moneda_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Monedas", t => t.Moneda_ID)
                .Index(t => t.Moneda_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovimientoEfectivoes", "Moneda_ID", "dbo.Monedas");
            DropForeignKey("dbo.Efectivoes", "Moneda_ID", "dbo.Monedas");
            DropIndex("dbo.MovimientoEfectivoes", new[] { "Moneda_ID" });
            DropIndex("dbo.Efectivoes", new[] { "Moneda_ID" });
            DropTable("dbo.MovimientoEfectivoes");
            DropTable("dbo.Monedas");
            DropTable("dbo.Efectivoes");
            DropTable("dbo.Destinoes");
        }
    }
}
