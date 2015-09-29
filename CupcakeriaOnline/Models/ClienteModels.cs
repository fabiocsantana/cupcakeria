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
    public class ClienteModels
    {
        [Table("Cliente")]
        public class PerfilCliente
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int ClienteId { get; set; }

            [Required(ErrorMessage = "Nome obrigatório")]
            [DisplayName("Nome")]
            public string ClienteNome { get; set; }

            [Required(ErrorMessage = "Data de nascimento obrigatória")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
            [DisplayName("Data de Nascimento")]
            public DateTime ClienteDtNasc { get; set; }

            [Required(ErrorMessage = "Telefone obrigatório")]
            [StringLength(10)]
            [DisplayFormat(DataFormatString = "{0:##-####-####}")]
            [DisplayName("Telefone")]
            public string ClienteTel { get; set; }

            [DataType(DataType.EmailAddress)]
            [Required(ErrorMessage = "Email obrigatório")]
            [DisplayName ("Email")]
            public string ClienteEmail { get; set; }
        }
    }
}