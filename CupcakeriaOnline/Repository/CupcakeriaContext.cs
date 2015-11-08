using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CupcakeriaOnline.Models;

namespace CupcakeriaOnline.Repository
{
    public class CupcakeriaContext : DbContext
    {
        public DbSet<AdministracaoModel> AdministracaoModels { get; set; }

        public DbSet<ClienteModel> Cliente { get; set; }

        public DbSet<EnderecoModel> Endereco { get; set; }

        public DbSet<PedidoModel> Pedidos { get; set; }

        public DbSet<Item_PedidoModel> Item_Pedidos { get; set; }
        
        public DbSet<MassaModel> Massa { get; set; }

        public DbSet<CoberturaModel> Coberturas { get; set; }

        public DbSet<RecheioModel> Recheios { get; set; }

        public CupcakeriaContext()
            : base("name=CadastroContext")
        {

            Database.Connection.ConnectionString = @"<!-- INSERIR CONNECTION STRING >";
            Database.SetInitializer<CupcakeriaContext>(null);

        }

        public DbSet<Cupcake_Pedido> Cupcake_Pedido { get; set; }     
    }
}