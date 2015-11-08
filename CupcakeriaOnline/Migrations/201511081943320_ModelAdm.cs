namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelAdm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrador",
                c => new
                    {
                        pk_idAdministracao = c.Int(nullable: false, identity: true),
                        loginAdmSenha = c.String(maxLength: 4000),
                        loginAdmSalt = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.pk_idAdministracao);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Administrador");
        }
    }
}
