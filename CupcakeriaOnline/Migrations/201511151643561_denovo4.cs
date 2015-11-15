namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class denovo4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Endereco");
            DropIndex("dbo.Pedido", new[] { "fk_idCliente" });
            DropColumn("dbo.Pedido", "fk_idEndereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedido", "fk_idEndereco", c => c.Int());
            CreateIndex("dbo.Pedido", "fk_idEndereco");
            AddForeignKey("dbo.Pedido", "fk_idEndereco", "dbo.Endereco", "pk_idEndereco");
        }
    }
}
