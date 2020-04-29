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
       public void SetValor(int valor)
        {
            Valor = Valor;
        }
        public bool Livre()
        {
            if (Grupo == Grupo.Nenhum || Grupo == Grupo.Pares)
            {
                return true;
            }
            return false;
        }
        private void Print(ConsoleColor foreground, ConsoleColor background)
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(Nipe);
            Console.ForegroundColor = aux;
            Console.BackgroundColor = default;
        }
        public void PrintNipe()
        {
            if (Cor == Cor.vermelha)
            {
                Print(ConsoleColor.Red, ConsoleColor.White);
            }
            else
            {
                Print(ConsoleColor.Black, ConsoleColor.White);
            }
        }
        public override string ToString()
        {
            return Letra + " " + Nipe;
        }
    }
}
