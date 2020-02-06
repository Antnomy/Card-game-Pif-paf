using mesa;

namespace Pif_paf
{
    class Jogador
    {
        public int Numero { get; private set; }
        public string Nome { get; set; }
        public Mao Mao { get; set; }

        public Jogador(int numero, Mao mao)
        {
            Numero = numero;
            Mao = mao;
           
        }
    }
}
