using CupcakeriaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CupcakeriaOnline.Repository
{
    public class CoberturaRepository
    {
        private CoberturaModel.CoberturaContext context = new CoberturaModel.CoberturaContext();

        public void Salva()
        {
            context.SaveChanges();
        }

        public void Adiciona(CoberturaModel.CoberturaCupcake cobertura)
        {
            context.Coberturas.Add(cobertura);
        }

        public void Remove(int id)
        {
            CoberturaModel.CoberturaCupcake recheio = context.Coberturas.Find(id);
            context.Coberturas.Remove(recheio);
        }

        public CoberturaModel.CoberturaCupcake Busca(int id)
        {
            return context.Coberturas.Find(id);
        }
    }
}