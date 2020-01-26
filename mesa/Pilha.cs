using System.Collections.Generic;
using System;
using System.Text;
namespace mesa
{
    abstract class Pilha
    {
        protected int Count;
        public List<Carta> Cartas { get; protected set; } = new List<Carta>();
        public void AdcCarta(Carta carta)
        {
            Cartas.Add(carta);
        }
        public void RemoveCarta(Carta carta)
        {
            Cartas.Remove(carta);
        }
        public abstract Carta RemoveTop();
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
