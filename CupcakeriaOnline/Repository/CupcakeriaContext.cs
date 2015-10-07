using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CupcakeriaOnline.Repository
{
    public class CupcakeriaContext : DbContext
    {
        public CupcakeriaContext()
            : base("name=CadastroContext")
        {

            Database.Connection.ConnectionString =@"Data Source=LAB03-08;Initial Catalog=Alunos;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

        } 

        //public DbSet<Aluno> Alunos { get; set; }
        //public DbSet<Turmas> Turmas { get; set; }
    }
}