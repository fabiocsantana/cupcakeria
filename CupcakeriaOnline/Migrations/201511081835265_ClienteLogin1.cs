namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteLogin1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cliente", "loginUsuSenha", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cliente", "loginUsuSenha", c => c.String(maxLength: 20));
        }
    }
}
