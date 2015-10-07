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
    public class CoberturaModel
    {
        [Table("Cobertura")]
        public class CoberturaCupcake
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int pk_idCobertura { get; set; }

            [Required(ErrorMessage = "Valor Unitário Obrigatório")]
            [DisplayName("Valor Unitário")]
            public double valorUnitCobertura { get; set; }

            [Required(ErrorMessage = "Descrição Obrigatória")]
            [DisplayName("Descrição")]
            public string descrCobertura { get; set; }

            [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime dtCadastroCobertura { get; set; }

            [Required(ErrorMessage = "Disponibilidade Obrigatória")]
            [DisplayName("Disponibilidade")]
            public bool dispCobertura { get; set; }

            

        }
        
    }
}