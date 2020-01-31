using Enuns;
namespace mesa
{
    class Carta
    {
        public string Letra { get; private set; }      
        public int Valor { get; private set; }
        public Nipe Nipe { get; private set; }
        public Cor Cor { get; set; }

        public Carta(string letra, int valor, Nipe nipe, Cor cor)
        {
            Letra = letra;
            Valor = valor;
            Nipe = nipe;
            Cor = cor;
        }
        public override string ToString()
        {
            return Letra + " " + Nipe;
        }
    }
}
