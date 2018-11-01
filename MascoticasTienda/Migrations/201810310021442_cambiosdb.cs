namespace MascoticasTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiosdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovimientoEfectivoes", "DestinoId", c => c.Int(nullable: false));
            CreateIndex("dbo.MovimientoEfectivoes", "DestinoId");
            AddForeignKey("dbo.MovimientoEfectivoes", "DestinoId", "dbo.Destinoes", "ID", cascadeDelete: true);
            DropColumn("dbo.MovimientoEfectivoes", "Destino");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovimientoEfectivoes", "Destino", c => c.Int(nullable: false));
            DropForeignKey("dbo.MovimientoEfectivoes", "DestinoId", "dbo.Destinoes");
            DropIndex("dbo.MovimientoEfectivoes", new[] { "DestinoId" });
            DropColumn("dbo.MovimientoEfectivoes", "DestinoId");
        }
    }
}
