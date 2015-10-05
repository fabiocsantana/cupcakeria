using CupcakeriaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CupcakeriaOnline.Repository
{
    public class RecheioRepository
    {
        private RecheioModel.RecheioContext context = new RecheioModel.RecheioContext();

        public void Salva()
        {
            context.SaveChanges();
        }

        public void Adiciona(RecheioModel.RecheioCupcake recheio)
        {
            context.Recheios.Add(recheio);
        }

        public void Remove(int id)
        {
            RecheioModel.RecheioCupcake recheio = context.Recheios.Find(id);
            context.Recheios.Remove(recheio);
        }

        public RecheioModel.RecheioCupcake Busca(int id)
        {
            return context.Recheios.Find(id);
        }
    }
}