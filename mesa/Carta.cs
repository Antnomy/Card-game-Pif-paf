using System;
using Enuns;
namespace mesa
{
    class Carta
    {
        public string Letra { get; private set; }      
        public int Valor { get; private set; }
        public int Ordem { get; private set; }
        public Nipe Nipe { get; private set; }
        public Cor Cor { get; private set; }
        public Grupo Grupo { get; set; }
        public Carta(string letra, int valor, int ordem, Nipe nipe, Cor cor)
        {
            Letra = letra;
            Valor = valor;
            Ordem = ordem;
            Nipe = nipe;
            Cor = cor;
            Grupo = Grupo.Nenhum;
            
        }
      
        public bool Livre()
        {
            if (Grupo == Grupo.Nenhum || Grupo == Grupo.Pares)
            {
                return true;
            }
            return false;
        }       
        public string ToStringNipe()
        {       
            switch (Nipe)
            {
                case Nipe.Cop:
                    return "♥  ";
                    
                case Nipe.Our:
                    return "♦  ";
                   
                case Nipe.Esp:
                    return "♠  ";
                    
                case Nipe.Pau:
                    return "♣  ";
                default:
                    return " ? ";
            }
        }
        public override string ToString()
        {
            return Letra + " " + Nipe;
        }
    }
}
