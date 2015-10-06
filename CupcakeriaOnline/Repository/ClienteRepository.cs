using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CupcakeriaOnline.Models;

namespace CupcakeriaOnline.Repository
{    public class ClienteRepository
    {
        //private ClienteModels.ClienteContext context = new ClienteModels.ClienteContext();

        public void Salva()
        {
            context.SaveChanges();
        }

        public void Adiciona(Cliente cliente)
        {
            context.Cliente.Add(cliente);
        }

        public void Remove(int id)
        {
            Cliente cliente = context.Cliente.Find(id);
            context.Cliente.Remove(cliente);
        }

        public Cliente Busca(int id)
        {
            return context.Cliente.Find(id);
        }
    }
}