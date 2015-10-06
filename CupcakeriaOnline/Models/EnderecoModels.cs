using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Web.Mvc;
using System.Linq;
using System.ComponentModel;

namespace CupcakeriaOnline.Models
{
    public class EnderecoModels
    {
        [Table("Endereco")]
        public class Endereco
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int pk_idEndereco { get; set; }

            public int ClienteId { get; set; }

            [Required(ErrorMessage = "CEP obrigatório")]
            [StringLength(8)]
            [DisplayFormat(DataFormatString = "{0:#####-###}")]
            [DisplayName("CEP")]
            public string cepEndereco { get; set; }

            [Required(ErrorMessage = "Logradouro obrigatório")]
            [DisplayName("Logradouro")]
            public string logrEndereco { get; set; }

            [DisplayName("Nº")]
            public double numEndereco { get; set; }

            [DisplayName("Complemento")]
            public string complEndereco { get; set; }

            [DisplayName("Bairro")]
            public string bairroEndereco { get; set; }

            [DisplayName("Complemento")]
            public string cidEndereco { get; set; }
        }
    }

    public class EnderecoContext : DbContext
    {
        public EnderecoContext()
            : base("name=EnderecoContext")
        {

            Database.Connection.ConnectionString =

                @"Data Source=LAB03-08;Initial Catalog=Alunos;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

        }

        public DbSet<Endereco> Endereco { get; set; }
    }
}