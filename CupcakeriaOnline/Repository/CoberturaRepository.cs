using CupcakeriaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CupcakeriaOnline.Repository
{
    public class CoberturaRepository
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

        public void Adiciona(CoberturaModel cobertura)
        {
            context.Coberturas.Add(cobertura);
        }

        public void Remove(int id)
        {
            CoberturaModel cobertura = context.Coberturas.Find(id);
            context.Coberturas.Remove(cobertura);
        }

        public CoberturaModel Busca(int id)
        {
            return context.Coberturas.Find(id);
        }

        public List<CoberturaModel> Listar()
        {

            return context.Coberturas.ToList();
        }
    }
}