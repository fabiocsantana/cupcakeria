using CupcakeriaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CupcakeriaOnline.Repository
{
    public class PedidoRepository
    {
        private PedidoRepository. context = new PedidoRepository.();

        public void Salva()
        {
            context.SaveChanges();
        }

        public void Adiciona(PedidoModel.PedidoCupcake pedido)
        {
            context.Pedidos.Add(pedido);
        }

        public void Remove(int id)
        {
            PedidoModel.PedidoCupcake pedido = context.Pedidos.Find(id);
            context.Pedidos.Remove(pedido);
        }

        public PedidoModel.PedidoCupcake Busca(int id)
        {
            return context.Pedidos.Find(id);
        }
    }
}