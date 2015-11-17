using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CupcakeriaOnline.Models;

namespace CupcakeriaOnline
{
    public class VariavelGlobal
    {
       /* public VariavelGlobal()
        {
            Carrinho = new List<Cupcake_Pedido>();
        }*/
        public static List<Cupcake_Pedido> Carrinho; //{ get{return Carrinho; } set; }

        public List<Cupcake_Pedido> getCupcakes()
        {
            return Carrinho;
        }

        public void Adiciona(Cupcake_Pedido cupcake)
        {
            if (Carrinho != null)
            {
                Carrinho.Add(cupcake);
            }
            else
            {
                Cria();
                Adiciona(cupcake);
            }
        }

        public void Cria()
        {
            Carrinho = new List<Cupcake_Pedido>();
        }

        public void Limpa()
        {
            Carrinho = new List<Cupcake_Pedido>();        
        }
    }
}