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
    [Table("Recheio")]
    public class RecheioModel
    {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int pk_idRecheio { get; set; }

            [Required(ErrorMessage = "Descrição Obrigatória")]
            [DisplayName("Descrição")]
            public string descrRecheio { get; set; }

            [Required(ErrorMessage = "Valor Unitário Obrigatório")]
            [DisplayName("Valor Unitário")]
            //[DisplayFormat(DataFormatString = "{0:#,##0,00}", ApplyFormatInEditMode = true)]
            public double? valorUnitRecheio { get; set; }

            [DataType(DataType.DateTime)]
            [DisplayName("Data do Cadastro")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
            public DateTime? dtCadastroRecheio { get; set; }

            [Required(ErrorMessage ="Disponibilidade Obrigatória")]
            [DisplayName("Disponibilidade")]
            public bool dispRecheio { get; set; }

        }
}