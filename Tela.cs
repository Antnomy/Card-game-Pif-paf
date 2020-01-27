using System;
using System.Collections.Generic;
using System.Text;
using mesa;

namespace Pif_paf
{
    class Tela
    {
        public static int qntCemiterio;
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
            Console.Clear();
            string carta = "  vazio  ";
            qntCemiterio = cemiterio.QntCartas();
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

        public static Carta Compra(Baralho baralho, Cemiterio cemiterio)
        {
            if(qntCemiterio == 0)
            {
                Console.Write("!Compre uma carta (Enter): ");
                Console.ReadLine();
                return baralho.RemoveTop();
            }
            else
            {
                Console.Write("!Comprar do Maço ou Cemiterio (m, c)?: ");
                char c = char.Parse(Console.ReadLine());
                if(c == 'm')
                {
                    return baralho.RemoveTop();
                }
                else
                {
                    return cemiterio.RemoveTop();
                }
            }
            
        }
    }
}
