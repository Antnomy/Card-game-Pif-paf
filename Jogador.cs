using mesa;

namespace Pif_paf
{
    class Jogador
    {
        public int Numero { get; private set; }
        public string Nome { get; set; }
        public Mao Mao { get; set; }
        public bool Auto { get; set; }
        public Jogador(int numero, Mao mao, string nome, bool auto)
        {
            Numero = numero;
            Mao = mao;
            Nome = nome;
            Auto = auto;
        }
        public void Set(Mao mao)
        {

        }

    }
}
