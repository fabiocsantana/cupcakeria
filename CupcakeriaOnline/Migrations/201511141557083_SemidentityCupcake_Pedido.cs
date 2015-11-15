namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SemidentityCupcake_Pedido : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cupcake Pedido", "pk_idCupcake", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cupcake Pedido", "pk_idCupcake", c => c.Int(nullable: false, identity: true));
        }
    }
}
