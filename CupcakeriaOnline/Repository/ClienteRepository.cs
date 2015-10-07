using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CupcakeriaOnline.Models;
using System.Data.Entity;

namespace CupcakeriaOnline.Repository
{    public class ClienteRepository
    {
    private ClienteContext context = new ClienteContext();

        public void Salva()
        {
            context.SaveChanges();
        }

        public void Adiciona(ClienteModel cliente)
        {
            context.Cliente.Add(cliente);
        }

        public void Remove(int id)
        {
            ClienteModel cliente = context.Cliente.Find(id);
            context.Cliente.Remove(cliente);
        }

        public ClienteModel Busca(int id)
        {
            return context.Cliente.Find(id);
        }
    }
}