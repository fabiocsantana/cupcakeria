namespace CupcakeriaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cobertura",
                c => new
                    {
                        pk_idCobertura = c.Int(nullable: false, identity: true),
                        descrCobertura = c.String(nullable: false),
                        valorUnitCobertura = c.Double(nullable: false),
                        dtCadastroCobertura = c.DateTime(),
                        dispCobertura = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pk_idCobertura);
            
            CreateTable(
                "dbo.Recheio",
                c => new
                    {
                        pk_idRecheio = c.Int(nullable: false, identity: true),
                        descrRecheio = c.String(nullable: false),
                        valorUnitRecheio = c.Double(nullable: false),
                        dtCadastroRecheio = c.DateTime(),
                        dispRecheio = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pk_idRecheio);
            
            CreateTable(
                "dbo.Item Pedido",
                c => new
                    {
                        pk_idItemPedido = c.Int(nullable: false, identity: true),
                        fk_idCupcake = c.Int(nullable: false),
                        qtdeItem = c.Int(nullable: false),
                        valorItem = c.Double(nullable: false),
                        dataItem_Pedido = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.pk_idItemPedido)
                .ForeignKey("dbo.Cupcake Pedido", t => t.fk_idCupcake, cascadeDelete: true)
                .Index(t => t.fk_idCupcake);
            
            CreateTable(
                "dbo.Cupcake Pedido",
                c => new
                    {
                        pk_idCupcake = c.Int(nullable: false, identity: true),
                        fk_idMassa = c.Int(nullable: false),
                        fk_idRecheio = c.Int(nullable: false),
                        fk_idCobertura = c.Int(nullable: false),
                        valorCupcake = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.pk_idCupcake)
                .ForeignKey("dbo.Massa", t => t.fk_idMassa, cascadeDelete: true)
                .ForeignKey("dbo.Recheio", t => t.fk_idRecheio, cascadeDelete: true)
                .ForeignKey("dbo.Cobertura", t => t.fk_idCobertura, cascadeDelete: true)
                .Index(t => t.fk_idMassa)
                .Index(t => t.fk_idRecheio)
                .Index(t => t.fk_idCobertura);
            
            CreateTable(
                "dbo.Massa",
                c => new
                    {
                        pk_idMassa = c.Int(nullable: false, identity: true),
                        descrMassa = c.String(nullable: false),
                        valorUnitMassa = c.Double(nullable: false),
                        dtCadastroMassa = c.DateTime(),
                        dispMassa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pk_idMassa);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        pk_idPedido = c.Int(nullable: false, identity: true),
                        fk_idCliente = c.Int(nullable: false),
                        statusPedido = c.Boolean(nullable: false),
                        vlrTotalPedido = c.Double(nullable: false),
                        dtRealizadoPedido = c.DateTime(nullable: false),
                        dtEntregaPedido = c.DateTime(nullable: false),
                        dataPedido = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.pk_idPedido)
                .ForeignKey("dbo.Cliente", t => t.fk_idCliente, cascadeDelete: true)
                .Index(t => t.fk_idCliente);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        pk_idCliente = c.Int(nullable: false, identity: true),
                        nomeCliente = c.String(nullable: false),
                        dataNascCliente = c.DateTime(nullable: false),
                        telCliente = c.String(nullable: false, maxLength: 10),
                        emailCliente = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.pk_idCliente);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        pk_idEndereco = c.Int(nullable: false, identity: true),
                        fk_idCliente = c.Int(nullable: false),
                        cepEndereco = c.String(nullable: false, maxLength: 8),
                        logrEndereco = c.String(nullable: false),
                        numEndereco = c.Double(nullable: false),
                        complEndereco = c.String(),
                        bairroEndereco = c.String(nullable: false),
                        cidEndereco = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.pk_idEndereco)
                .ForeignKey("dbo.Cliente", t => t.fk_idCliente, cascadeDelete: true)
                .Index(t => t.fk_idCliente);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Endereco", new[] { "fk_idCliente" });
            DropIndex("dbo.Pedido", new[] { "fk_idCliente" });
            DropIndex("dbo.Cupcake Pedido", new[] { "fk_idCobertura" });
            DropIndex("dbo.Cupcake Pedido", new[] { "fk_idRecheio" });
            DropIndex("dbo.Cupcake Pedido", new[] { "fk_idMassa" });
            DropIndex("dbo.Item Pedido", new[] { "fk_idCupcake" });
            DropForeignKey("dbo.Endereco", "fk_idCliente", "dbo.Cliente");
            DropForeignKey("dbo.Pedido", "fk_idCliente", "dbo.Cliente");
            DropForeignKey("dbo.Cupcake Pedido", "fk_idCobertura", "dbo.Cobertura");
            DropForeignKey("dbo.Cupcake Pedido", "fk_idRecheio", "dbo.Recheio");
            DropForeignKey("dbo.Cupcake Pedido", "fk_idMassa", "dbo.Massa");
            DropForeignKey("dbo.Item Pedido", "fk_idCupcake", "dbo.Cupcake Pedido");
            DropTable("dbo.Endereco");
            DropTable("dbo.Cliente");
            DropTable("dbo.Pedido");
            DropTable("dbo.Massa");
            DropTable("dbo.Cupcake Pedido");
            DropTable("dbo.Item Pedido");
            DropTable("dbo.Recheio");
            DropTable("dbo.Cobertura");
        }
    }
}
