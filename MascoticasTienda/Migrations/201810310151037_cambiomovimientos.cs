namespace MascoticasTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiomovimientos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovimientoEfectivoes", "Moneda_ID", "dbo.Monedas");
            DropIndex("dbo.MovimientoEfectivoes", new[] { "Moneda_ID" });
            CreateTable(
                "dbo.MovimientoDetalles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MoendaId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        MovimientoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Monedas", t => t.MoendaId, cascadeDelete: true)
                .ForeignKey("dbo.MovimientoEfectivoes", t => t.MovimientoId, cascadeDelete: true)
                .Index(t => t.MoendaId)
                .Index(t => t.MovimientoId);
            
            DropColumn("dbo.MovimientoEfectivoes", "Moneda_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovimientoEfectivoes", "Moneda_ID", c => c.Int());
            DropForeignKey("dbo.MovimientoDetalles", "MovimientoId", "dbo.MovimientoEfectivoes");
            DropForeignKey("dbo.MovimientoDetalles", "MoendaId", "dbo.Monedas");
            DropIndex("dbo.MovimientoDetalles", new[] { "MovimientoId" });
            DropIndex("dbo.MovimientoDetalles", new[] { "MoendaId" });
            DropTable("dbo.MovimientoDetalles");
            CreateIndex("dbo.MovimientoEfectivoes", "Moneda_ID");
            AddForeignKey("dbo.MovimientoEfectivoes", "Moneda_ID", "dbo.Monedas", "ID");
        }
    }
}
