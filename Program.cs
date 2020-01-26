using System.Collections.Generic;
using System;
using mesa;
using Enuns;

namespace Pif_paf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Baralho baralho = new Baralho();
                baralho.AdcCarta(new Carta('A', 10, Nipe.Copas, Cor.preta));
                baralho.AdcCarta(new Carta('2', 10, Nipe.Espadas, Cor.preta));
                baralho.AdcCarta(new Carta('3', 10, Nipe.Paus, Cor.preta));
                baralho.AdcCarta(new Carta('4', 10, Nipe.Ouros, Cor.preta));
                baralho.AdcCarta(new Carta('5', 10, Nipe.Copas, Cor.preta));
                baralho.AdcCarta(new Carta('6', 10, Nipe.Copas, Cor.preta));
                baralho.AdcCarta(new Carta('A', 10, Nipe.Copas, Cor.preta));
                baralho.AdcCarta(new Carta('K', 10, Nipe.Espadas, Cor.preta));
                baralho.AdcCarta(new Carta('3', 10, Nipe.Paus, Cor.preta));
                baralho.AdcCarta(new Carta('1', 10, Nipe.Ouros, Cor.preta));
                baralho.AdcCarta(new Carta('5', 10, Nipe.Copas, Cor.preta));
                baralho.AdcCarta(new Carta('J', 10, Nipe.Copas, Cor.preta));
                Cemiterio cemiterio = new Cemiterio();
                Mao mao = new Mao(baralho, 5);
                int posicao;
                int fase = 1;

                while (true)
                {
                    Console.Clear();
                    Tela.ImprimeMesa(baralho, cemiterio, mao);                  
                    if(fase == 1)
                    {
                        Console.Write("Compre carta (Enter): ");
                        Console.ReadLine();
                        mao.CompraCarta(baralho);
                        fase = 2;
                    }
                    else
                    {
                        Console.Write("Descarte (posicao): ");
                        posicao = int.Parse(Console.ReadLine());
                        cemiterio.AdcCarta(mao.Descartar(posicao));
                        fase = 1;
                    }                    
                }
            }
            catch(PifpafExeption e)
            {
                Console.WriteLine("O.o " + e.Message);
            }


        }
    }
}
