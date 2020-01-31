using System;
using mesa;

namespace Pif_paf
{
    class Ai
    {
        public Baralho Baralho;
        public Pilha Cemiterio;
        public Mao Mao;
        Random r = new Random();
        public Ai(Baralho baralho, Pilha cemiterio, Mao mao)
        {
            Baralho = baralho;
            Cemiterio = cemiterio;
            Mao = mao;
        }
        public bool Confirmar()
        {        
            return Convert.ToBoolean(r.Next(2));
        }
        public int SelecionaIndiceMao()
        {

            return r.Next(Mao.GetListaCartas().Count - 1);
        }
    }
}
