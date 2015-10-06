using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CupcakeriaOnline.Repository
{
    public class EnderecoRepository
    {
        private EnderecoModels.EnderecoContext context = new EnderecoModels.EnderecoContext();

        public void Salva()
        {
            context.SaveChanges();
        }

        public void Adiciona(EnderecoModels.Endereco endereco)
        {
            context.Endereco.Add(endereco);
        }

        public void Remove(int id)
        {
            EnderecoModels.Endereco endereco = context.Endereco.Find(id);
            context.Endereco.Remove(endereco);
        }

        public EnderecoModels.Endereco Busca(int id)
        {
            return context.Endereco.Find(id);
        }
    }
}