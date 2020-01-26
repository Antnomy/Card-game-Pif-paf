using System.Collections.Generic;
using System;
using System.Text;
namespace mesa
{
    class Pilha
    {
        protected int Count;
        public List<Carta> Cartas { get; protected set; } = new List<Carta>();

        public Pilha()
        {
            Count = 0;
        }

        public void AdcCarta(Carta carta)
        {
            Cartas.Add(carta);
        }
        public void RemoveCarta(Carta carta)
        {
            Cartas.Remove(carta);
        }

        public int QntCartas()
        {
            return Cartas.Count;
        }
        public override string ToString()
        {
            StringBuilder txt = new StringBuilder();
            foreach (Carta cart in Cartas)
            {
                txt.AppendLine(cart.ToString());
            }

            return txt.ToString();
        }
    }
}
