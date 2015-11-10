namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rollback : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cupcake Pedido", "valorCupcake", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cupcake Pedido", "valorCupcake", c => c.Double(nullable: false));
        }
    }
}
