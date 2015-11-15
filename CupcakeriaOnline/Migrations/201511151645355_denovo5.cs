namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class denovo5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "fk_idEndereco", c => c.Int());
            AddForeignKey("dbo.Pedido", "fk_idEndereco", "dbo.Endereco", "pk_idEndereco");
            CreateIndex("dbo.Pedido", "fk_idEndereco");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Pedido", new[] { "fk_idEndereco" });
            DropForeignKey("dbo.Pedido", "fk_idEndereco", "dbo.Endereco");
            DropColumn("dbo.Pedido", "fk_idEndereco");
        }
    }
}
