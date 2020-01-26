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
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("|          ");
            }
            Console.WriteLine();
        }
        public static void ImprimeMesa(Baralho baralho, Cemiterio cemiterio, Mao mao)
        {
            Console.WriteLine("      ------------  ------------");
            Console.WriteLine("      |    " + cemiterio.QntCartas() + "     |  |    " + baralho.QntCartas() + "     |");
            Console.WriteLine("      |Cemiterio |  |   Maço   |");
            Console.WriteLine("      |          |  |          |");
            Console.WriteLine("      ------------  ------------");

            Console.WriteLine();
            Linha(mao.QntCartas());
            Console.WriteLine(mao);
            Corpo(mao.QntCartas());
            Corpo(mao.QntCartas());
            Linha(mao.QntCartas());
        }
    }
}
