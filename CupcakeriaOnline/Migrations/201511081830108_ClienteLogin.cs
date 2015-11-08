namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteLogin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cliente", "telCliente", c => c.String(maxLength: 10));
            AlterColumn("dbo.Cliente", "emailCliente", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cliente", "emailCliente", c => c.String(nullable: false));
            AlterColumn("dbo.Cliente", "telCliente", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
