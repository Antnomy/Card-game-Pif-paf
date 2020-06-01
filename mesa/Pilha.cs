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
        public Carta RemoveCarta(Carta carta)
        {
            Carta aux = carta;
            Cartas.Remove(carta);
            return aux;
        }

        public Carta RemoveTop()
        {
            if (QntCartas() == 0)
            {
                throw new PifpafExeption("   Não há mais cartas para sacar!");
            }
            return RemoveCarta(Top());
        }
        public Carta Top()
        {
            return Cartas[Cartas.Count - 1];
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
