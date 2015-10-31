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
        private CupcakeriaContext context = new CupcakeriaContext();

        public void Salva()
        {
            context.SaveChanges();
        }

        public void Adiciona(PedidoModel itempedido)
        {
            context.Pedidos.Add(itempedido);
        }

        public void Remove(int id)
        {
            PedidoModel itempedido = context.Pedidos.Find(id);
            context.Pedidos.Remove(itempedido);
        }

        public PedidoModel Busca(int id)
        {
            return context.Pedidos.Find(id);
        }

        public PedidoModel buscaData(int dataPedido)
        {
            return context.Pedidos.Find(dataPedido);
        }
         
    } 
}