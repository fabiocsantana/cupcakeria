namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteSenha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "loginUsuSenha", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "loginUsuSenha");
        }
    }
}
