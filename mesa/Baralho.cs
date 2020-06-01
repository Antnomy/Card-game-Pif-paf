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
            Random r = new Random();
            int indice;

           while (Cartas.Count > 0)
            {
                indice = r.Next(Cartas.Count - 1);
                aux.Add(RemoveCarta(Cartas[indice]));                       
            }
            Cartas = aux;
        }       
    }
}
