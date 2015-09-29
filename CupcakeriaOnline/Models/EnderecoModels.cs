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
        public class EnderecoCliente
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int EnderecoId { get; set; }
            
            public int ClienteId { get; set; }

            [Required(ErrorMessage = "CEP obrigatório")]
            [StringLength(8)]
            [DisplayFormat(DataFormatString = "{0:#####-###}")]
            [DisplayName("CEP")]
            public string EnderecoCep { get; set; }

            [Required(ErrorMessage = "Logradouro obrigatório")]
            [DisplayName("Logradouro")]
            public string EnderecoLogr { get; set; }

            [DisplayName("Nº")]
            public double EnderecoNum { get; set; }

            [DisplayName("Complemento")]
            public string EnderecoCompl { get; set; }

            [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime EnderecoDtCad { get; set; }
        }
    }
}