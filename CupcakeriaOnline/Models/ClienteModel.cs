using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Web.Mvc;

namespace CupcakeriaOnline.Models
{
        [Table("Cliente")]
    public class ClienteModel
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int pk_idCliente { get; set; }

            [Required(ErrorMessage = "Nome obrigatório")]
            [DisplayName("Nome")]
            public string nomeCliente { get; set; }

            [Required(ErrorMessage = "Data de nascimento obrigatória")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
            [DisplayName("Data de Nascimento")]
            public DateTime dataNascCliente { get; set; }

            [Required(ErrorMessage = "Telefone obrigatório")]
            [StringLength(10)]
            [DisplayFormat(DataFormatString = "{0:##-####-####}")]
            [DisplayName("Telefone")]
            public string telCliente { get; set; }

            [DataType(DataType.EmailAddress)]
            [Required(ErrorMessage = "Email obrigatório")]
            [DisplayName("Email")]
            public string emailCliente { get; set; }
        }
        public class ClienteContext : DbContext
        {
            public ClienteContext()
                : base("name=ClienteContext")
            {

                Database.Connection.ConnectionString =

                    @"Data Source=LAB03-08;Initial Catalog=Alunos;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            }

            public DbSet<ClienteModel> Cliente { get; set; }
        }
}