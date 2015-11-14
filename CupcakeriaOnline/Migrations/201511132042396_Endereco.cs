namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Endereco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "fk_idEndereco", c => c.Int());
            AddForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Endereco", "pk_idEndereco");
            //CreateIndex("dbo.Pedido", "fk_idCliente");
        }
        
        public override void Down()
        {
            //DropIndex("dbo.Pedido", new[] { "fk_idCliente" });
            //DropForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Endereco");
            DropColumn("dbo.Pedido", "fk_idEndereco");
        }
    }
}
