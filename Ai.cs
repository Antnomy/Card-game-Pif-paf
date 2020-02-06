using System;
using mesa;

namespace Pif_paf
{
    class Ai : Jogador
    {
        public Baralho Baralho;
        public Pilha Cemiterio;
        Random r = new Random();
       
        public Ai(int numero, Mao mao, Baralho baralho, Pilha cemiterio) :base(numero, mao)
        {
            Baralho = baralho;
            Cemiterio = cemiterio;
            Mao = mao;
            Nome = "CPU";
        }
        public void Jogar()
        {
            Mao.AdcCarta(Baralho.RemoveTop());          
            Mao.GetListaCartas().Insert(SelecRandonIndiceMao(), Mao.Descartar(SelecRandonIndiceMao()));
            Cemiterio.AdcCarta(Mao.Descartar(SelecRandonIndiceMao()));
        }
        public bool Confirmar()
        {        
            return Convert.ToBoolean(r.Next(2));
        }
        public int SelecRandonIndiceMao()
        {
            return r.Next(Mao.GetListaCartas().Count - 1);
        }
    }
}
