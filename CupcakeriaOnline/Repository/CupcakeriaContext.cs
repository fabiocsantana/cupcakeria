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
        public CupcakeriaContext()
            : base("name=CadastroContext")
        {

            Database.Connection.ConnectionString = @"Data Source=LAB03-12;Initial Catalog=DB_CUPCAKERIA;Integrated Security=True";

        } 

        public DbSet<CoberturaModel> Coberturas { get; set; }
        public DbSet<RecheioModel> Recheios { get; set; }
        public DbSet<Item_PedidoModel> Item_Pedidos { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<EnderecoModel> Endereco { get; set; }
        public DbSet<MassaModel> Massa { get; set; }
    }
}