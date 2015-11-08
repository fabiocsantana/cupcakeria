namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteLogin2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "loginUsuSalt", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Cliente", "loginUsuSenha", c => c.String(maxLength: 4000));
            DropColumn("dbo.Cliente", "loginUsuSenhaCript");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cliente", "loginUsuSenhaCript", c => c.String(maxLength: 200));
            AlterColumn("dbo.Cliente", "loginUsuSenha", c => c.String(maxLength: 200));
            DropColumn("dbo.Cliente", "loginUsuSalt");
        }
    }
}
