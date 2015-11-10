namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aceitaNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Cliente");
            DropIndex("dbo.Pedido", new[] { "fk_idCliente" });
            AlterColumn("dbo.Pedido", "fk_idCliente", c => c.Int());
            AlterColumn("dbo.Pedido", "statusPedido", c => c.Boolean());
            AlterColumn("dbo.Pedido", "vlrTotalPedido", c => c.Double());
            AlterColumn("dbo.Pedido", "dataPedido", c => c.DateTime());
            AddForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Cliente", "pk_idCliente");
            CreateIndex("dbo.Pedido", "fk_idCliente");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Pedido", new[] { "fk_idCliente" });
            DropForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Cliente");
            AlterColumn("dbo.Pedido", "dataPedido", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pedido", "vlrTotalPedido", c => c.Double(nullable: false));
            AlterColumn("dbo.Pedido", "statusPedido", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Pedido", "fk_idCliente", c => c.Int(nullable: false));
            CreateIndex("dbo.Pedido", "fk_idCliente");
            AddForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Cliente", "pk_idCliente", cascadeDelete: true);
        }
    }
}
