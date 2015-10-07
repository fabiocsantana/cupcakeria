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
        [Table("Endereco")]
        public class Endereco
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int pk_idEndereco { get; set; }

            [ForeignKey("pk_idCliente")]           
            public int fk_idCliente { get; set; }

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

            [Required(ErrorMessage = "Bairro obrigatório")]
            [DisplayName("Bairro")]
            public string bairroEndereco { get; set; }

            [Required(ErrorMessage = "Cidade obrigatória")]
            [DisplayName("Cidade")]
            public string cidEndereco { get; set; }
        }

}