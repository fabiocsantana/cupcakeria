namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cupcake_pedidoIdentity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cupcake Pedido", "pk_idCupcake", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cupcake Pedido", "pk_idCupcake", c => c.Int(nullable: false));
        }
    }
}
