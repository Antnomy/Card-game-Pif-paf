using System;
using System.Collections.Generic;
using Pif_paf;

namespace mesa
{
    class Baralho : Pilha
    {      
        public Baralho() 
        {
          
        }
        public void Embaralhar()
        {
            List<Carta> aux = new List<Carta>();
            foreach (Carta item in Cartas)
            {
                if (aux.Count > 0)
                {
                    Random r = new Random();
                    int indice = r.Next(aux.Count - 1);
                    aux.Insert(indice, item);
                }
                else
                {
                    aux.Add(item);
                }
            }
            Cartas.Clear();
            Cartas = aux;
        }
    }
}
