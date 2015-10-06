using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CupcakeriaOnline.Repository
{    public class ClienteRepository
    {
        private ClienteModels.ClienteContext context = new ClienteModels.ClienteContext();

        public void Salva()
        {
            context.SaveChanges();
        }

        public void Adiciona(ClienteModels.Cliente cliente)
        {
            context.Cliente.Add(cliente);
        }

        public void Remove(int id)
        {
            ClienteModels.Cliente cliente = context.Cliente.Find(id);
            context.Cliente.Remove(cliente);
        }

        public ClienteModels.Cliente Busca(int id)
        {
            return context.Cliente.Find(id);
        }
    }
}