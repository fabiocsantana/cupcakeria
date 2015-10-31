using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CupcakeriaOnline.Models;


namespace CupcakeriaOnline.Repository
{
    public class Item_PedidoRepository
    {
        private CupcakeriaContext context = new CupcakeriaContext();

        public void Salva()
        {
            context.SaveChanges();
        }

        public void Adiciona(Item_PedidoModel itempedido)
        {
            context.Item_Pedidos.Add(itempedido);
        }

        public void Remove(int id)
        {
            Item_PedidoModel itempedido = context.Item_Pedidos.Find(id);
            context.Item_Pedidos.Remove(itempedido);
        }

        public Item_PedidoModel Busca(int id)
        {
            return context.Item_Pedidos.Find(id);
        }

        public Item_PedidoModel buscaData(int dataItemPedido)
        {
            return context.Item_Pedidos.Find(dataItemPedido);
        }
    }
}