namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13112015 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Cliente");
            DropForeignKey("dbo.Item Pedido", "fk_idCupcake", "dbo.Cupcake Pedido");
            DropIndex("dbo.Pedido", new[] { "fk_idCliente" });
            DropIndex("dbo.Item Pedido", new[] { "fk_idCupcake" });
            AddColumn("dbo.Cupcake Pedido", "fk_idPedido", c => c.Int(nullable: false));
            AddColumn("dbo.Cupcake Pedido", "valorTotalCupcake", c => c.Double(nullable: false));
            AddColumn("dbo.Cupcake Pedido", "qtdeItem", c => c.Int(nullable: false));
            AlterColumn("dbo.Pedido", "fk_idCliente", c => c.Int());
            AlterColumn("dbo.Pedido", "statusPedido", c => c.Boolean());
            AlterColumn("dbo.Pedido", "vlrTotalPedido", c => c.Double());
            AlterColumn("dbo.Pedido", "dataPedido", c => c.DateTime());
            AddForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Cliente", "pk_idCliente");
            AddForeignKey("dbo.Cupcake Pedido", "fk_idPedido", "dbo.Pedido", "pk_idPedido", cascadeDelete: true);
            CreateIndex("dbo.Pedido", "fk_idCliente");
            CreateIndex("dbo.Cupcake Pedido", "fk_idPedido");
            DropColumn("dbo.Pedido", "dtRealizadoPedido");
            DropColumn("dbo.Pedido", "dtEntregaPedido");
            DropColumn("dbo.Item Pedido", "fk_idCupcake");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item Pedido", "fk_idCupcake", c => c.Int(nullable: false));
            AddColumn("dbo.Pedido", "dtEntregaPedido", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pedido", "dtRealizadoPedido", c => c.DateTime(nullable: false));
            DropIndex("dbo.Cupcake Pedido", new[] { "fk_idPedido" });
            DropIndex("dbo.Pedido", new[] { "fk_idCliente" });
            DropForeignKey("dbo.Cupcake Pedido", "fk_idPedido", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Cliente");
            AlterColumn("dbo.Pedido", "dataPedido", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pedido", "vlrTotalPedido", c => c.Double(nullable: false));
            AlterColumn("dbo.Pedido", "statusPedido", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Pedido", "fk_idCliente", c => c.Int(nullable: false));
            DropColumn("dbo.Cupcake Pedido", "qtdeItem");
            DropColumn("dbo.Cupcake Pedido", "valorTotalCupcake");
            DropColumn("dbo.Cupcake Pedido", "fk_idPedido");
            CreateIndex("dbo.Item Pedido", "fk_idCupcake");
            CreateIndex("dbo.Pedido", "fk_idCliente");
            AddForeignKey("dbo.Item Pedido", "fk_idCupcake", "dbo.Cupcake Pedido", "pk_idCupcake", cascadeDelete: true);
            AddForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Cliente", "pk_idCliente", cascadeDelete: true);
        }
    }
}
