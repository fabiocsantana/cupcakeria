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
    [Table("Cupcake Pedido")]
    public class Cupcake_Pedido
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int pk_idCupcake { get; set; }

        [ForeignKey("fk_idMassa")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int fk_idMassa { get; set; }

        [ForeignKey("fk_idRecheio")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int fk_idCobertura {get; set;}

      /*public int fk_idMassa { get; set; }
        [ForeignKey("fk_idMassa")]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public virtual MassaModel Massa { get; set; }

        public int fk_idRecheio { get; set; }
        [ForeignKey("fk_idRecheio")]
        //DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public virtual RecheioModel Recheio { get; set; }

        public int fk_idCobertura { get; set; }
        [ForeignKey("fk_idCobertura")]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public virtual CoberturaModel Cobertura { get; set; }*/

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayName("Valor do Cupcake")]
        public double valorCupcake {get; set;}

    }
}