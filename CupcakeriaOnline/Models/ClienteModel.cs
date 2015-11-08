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
            [DisplayName("Data de Nascimento")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime dataNascCliente { get; set; }

            [StringLength(10, MinimumLength = 10)]
            [DisplayFormat(DataFormatString = "{0:##-####-####}")]
            [DisplayName("Telefone")]
            public string telCliente { get; set; }

            [DataType(DataType.EmailAddress)]
            [Required(ErrorMessage = "Email obrigatório")]
            [DisplayName("Email")]
            [StringLength(100)]
            public string emailCliente { get; set; }

            [StringLength(200, MinimumLength = 6)]
            [DisplayName("Senha")]
            [DataType(DataType.Password)]
            public String loginUsuSenha { get; set; }

            [StringLength(200)]
            public String loginUsuSenhaCript { get; set; }
        }
}