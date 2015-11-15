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

        public class PedidoModel
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int pk_idPedido { get; set; }

          /*[ForeignKey("fk_idCliente")]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int fk_idCliente { get; set; }*/

            /*public int fk_idCupcake { get; set; }
            [ForeignKey("fk_idCupcake")]
            public virtual Cupcake_Pedido Cupcake{get; set;}*/


            public int? fk_idCliente { get; set; }
            [ForeignKey("fk_idCliente")]
            public virtual ClienteModel Cliente { get; set; }

            public int? fk_idEndereco { get; set; }
            [ForeignKey("fk_idEndereco")]
            public virtual EnderecoModel Endereco { get; set; }

            //[Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            [DisplayName("Status")]
            public bool? statusPedido { get; set; }

            //[Required(ErrorMessage="Valor Obrigatório")]
            [DisplayName("Valor Total")]
            public double? vlrTotalPedido { get; set; }

            /*[Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime dtRealizadoPedido { get; set; }*/

            /*[Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime dtEntregaPedido { get; set; }*/

            [DataType(DataType.DateTime)]
            [DisplayName("Data do Pedido")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
            public DateTime? dataPedido { get; set; }
    }
}