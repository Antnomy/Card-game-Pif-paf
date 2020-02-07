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
       
        public override string ToString()
        {
            return Letra + " " + Nipe;
        }
    }
}
