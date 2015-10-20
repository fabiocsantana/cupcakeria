
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
    [Table("Massa")]
    public class MassaModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int pk_idMassa { get; set; }

        [Required(ErrorMessage = "Valor Unitário Obrigatório")]
        [DisplayName("Valor Unitário")]
        public double valorUnitMassa { get; set; }

        [Required(ErrorMessage = "Descrição Obrigatória")]
        [DisplayName("Nome")]
        public string descrMassa { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime dtCadastroMassa { get; set; }

        [Required(ErrorMessage = "Disponibilidade Obrigatória")]
        [DisplayName("Disponibilidade")]
        public bool dispMassa { get; set; }

    }
}