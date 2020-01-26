using System;
using System.Collections.Generic;
using System.Text;
using mesa;

namespace Pif_paf
{
    class Tela
    {
        public static void Linha(int tamanho)
        {
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("----------");
            }
            Console.WriteLine();
        }
        public static void Corpo(int tamanho)
        {
            Console.Write("|");
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("         |");
            }
            Console.WriteLine();
        }

        public static void Posicoes(int tamanho)
        {
            
            for (int i = 1; i <= tamanho; i++)
            {
                Console.Write( $"    {i}     ");
            }
            Console.WriteLine();
        }
        public static void ImprimeMesa(Baralho baralho, Cemiterio cemiterio, Mao mao)
        {
            string carta = "  vazio  ";
            int qntCemiterio = cemiterio.QntCartas();
            if(qntCemiterio > 0)
            {
                carta = cemiterio.Cartas[qntCemiterio - 1] + "";
            }

            while(carta.Length < 9)
            {
                carta += " ";
            }
            Console.WriteLine("                                               "+ qntCemiterio +"             " + baralho.QntCartas());
            Console.WriteLine("                                         ------------  ------------");
            Console.WriteLine("                                         |" + carta + " |  |          |");
            Console.WriteLine("                                         |          |  |     X    |");
            Console.WriteLine("                                         |          |  |          |");
            Console.WriteLine("                                         ------------  ------------");

            Console.WriteLine();
            Linha(mao.QntCartas());
            Console.WriteLine(mao);
            Corpo(mao.QntCartas());
            Corpo(mao.QntCartas());
            Linha(mao.QntCartas());
            Posicoes(mao.QntCartas());
            Linha(mao.QntCartas());
        }
    }
}
