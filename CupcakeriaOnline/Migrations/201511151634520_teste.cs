namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pedido", name: "fk_idEndereco", newName: "Endereco_pk_idEndereco");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Pedido", name: "Endereco_pk_idEndereco", newName: "fk_idEndereco");
        }
    }
}
