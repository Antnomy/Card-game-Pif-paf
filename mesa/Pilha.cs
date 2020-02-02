using System.Collections.Generic;
using System.Text;
using Pif_paf;

namespace mesa
{
    class Pilha
    {
        public List<Carta> Cartas { get; protected set; } = new List<Carta>();
        public void AdcCarta(Carta carta)
        {
            Cartas.Add(carta);
        }
        public void RemoveCarta(Carta carta)
        {
            Cartas.Remove(carta);
        }
        public  Carta RemoveTop() {
            if (QntCartas() == 0)
            {
                throw new PifpafExeption("Não há mais cartas para sacar!");
            }

            Carta aux = Cartas[Cartas.Count -1];
            Cartas.Remove(Cartas[Cartas.Count - 1]);
            return aux;
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
