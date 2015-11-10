namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pedidoModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedido", "fk_idCupcake", "dbo.Cupcake Pedido");
            DropIndex("dbo.Pedido", new[] { "fk_idCupcake" });
            AddColumn("dbo.Cupcake Pedido", "fk_idPedido", c => c.Int(nullable: false));
            AddForeignKey("dbo.Cupcake Pedido", "fk_idPedido", "dbo.Pedido", "pk_idPedido", cascadeDelete: true);
            CreateIndex("dbo.Cupcake Pedido", "fk_idPedido");
            DropColumn("dbo.Pedido", "fk_idCupcake");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedido", "fk_idCupcake", c => c.Int(nullable: false));
            DropIndex("dbo.Cupcake Pedido", new[] { "fk_idPedido" });
            DropForeignKey("dbo.Cupcake Pedido", "fk_idPedido", "dbo.Pedido");
            DropColumn("dbo.Cupcake Pedido", "fk_idPedido");
            CreateIndex("dbo.Pedido", "fk_idCupcake");
            AddForeignKey("dbo.Pedido", "fk_idCupcake", "dbo.Cupcake Pedido", "pk_idCupcake", cascadeDelete: true);
        }
    }
}
