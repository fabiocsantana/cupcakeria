using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CupcakeriaOnline.Models;

namespace CupcakeriaOnline.Repository
{
    public class EnderecoRepository
    {
        private EnderecoContext context = new EnderecoContext();

        public void Salva()
        {
            context.SaveChanges();
        }

        public void Adiciona(Endereco endereco)
        {
            context.Endereco.Add(endereco);
        }

        public void Remove(int id)
        {
            Endereco endereco = context.Endereco.Find(id);
            context.Endereco.Remove(endereco);
        }

        public Endereco Busca(int id)
        {
            return context.Endereco.Find(id);
        }
    }
}