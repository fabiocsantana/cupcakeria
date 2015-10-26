using CupcakeriaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CupcakeriaOnline.Repository
{
    public class RecheioRepository
    {
        private CupcakeriaContext context = new CupcakeriaContext();

        public CupcakeriaContext getContext()
        {
            return this.context;
        }

        public void Salva()
        {
            context.SaveChanges();
        }

        public void Adiciona(RecheioModel recheio)
        {
            context.Recheios.Add(recheio);
        }

        public void Remove(RecheioModel recheio)
        {
            
            context.Recheios.Remove(recheio);
        }

        public RecheioModel Busca(int id)
        {
            return context.Recheios.Find(id);
        }
    }
}