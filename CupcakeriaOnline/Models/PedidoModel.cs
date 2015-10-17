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
        [Table("Pedido")]
        public class PedidoCupcake
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int pk_idPedido { get; set; }

            [ForeignKey("fk_idCliente")]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int fk_idCliente { get; set; }

            [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            [DisplayName("Status")]
            public bool statusPedido { get; set; }

            [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            [DisplayName("Valor Total")]
            public double vlrTotalPedido { get; set; }

            [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime dtRealizadoPedido { get; set; }

            [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime dtEntregaPedido { get; set; }
    }
}