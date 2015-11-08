namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteSenhaCript : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "loginUsuSenhaCript", c => c.String(maxLength: 200));
            AlterColumn("dbo.Cliente", "loginUsuSenha", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cliente", "loginUsuSenha", c => c.String());
            DropColumn("dbo.Cliente", "loginUsuSenhaCript");
        }
    }
}
