namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class denovo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pedido", name: "fk_idCliente", newName: "Cliente_pk_idCliente");
            RenameColumn(table: "dbo.Pedido", name: "fk_idEndereco", newName: "Endereco_pk_idEndereco");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Pedido", name: "Endereco_pk_idEndereco", newName: "fk_idEndereco");
            RenameColumn(table: "dbo.Pedido", name: "Cliente_pk_idCliente", newName: "fk_idCliente");
        }
    }
}
