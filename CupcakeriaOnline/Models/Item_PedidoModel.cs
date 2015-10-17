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
        [Table("Item Pedido")]

        public class Item_PedidoModel
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int pk_idItemPedido { get; set; }

            [ForeignKey("fk_idCupcake")]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int fk_idCupcake { get; set; }

            [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            [DisplayName("Quantidade de Cupcake")]
            public int qtdeItem { get; set; }

            [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            [DisplayName("Valor do Cupcake")]
            public double valorItem { get; set; }
        }
}