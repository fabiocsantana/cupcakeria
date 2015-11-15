namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NonNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Cliente");
            DropIndex("dbo.Pedido", new[] { "fk_idCliente" });
            //RenameColumn(table: "dbo.Pedido", name: "fk_idCliente", newName: "fk_idEndereco");
            AddForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Cliente", "pk_idCliente");
            CreateIndex("dbo.Pedido", "fk_idCliente");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Pedido", new[] { "fk_idCliente" });
            DropForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Cliente");
            RenameColumn(table: "dbo.Pedido", name: "fk_idEndereco", newName: "fk_idCliente");
            CreateIndex("dbo.Pedido", "fk_idCliente");
            AddForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Cliente", "pk_idCliente");
        }
    }
}
