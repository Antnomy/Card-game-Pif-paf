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
            Baralho b = new Baralho();

           
            Baralho baralho = new Baralho();
            baralho.AdcCarta(new Carta('A', 10, Nipe.copas, Cor.preta));
            baralho.AdcCarta(new Carta('2', 10, Nipe.copas, Cor.preta));
            baralho.AdcCarta(new Carta('3', 10, Nipe.copas, Cor.preta));
            baralho.AdcCarta(new Carta('4', 10, Nipe.copas, Cor.preta));
            baralho.AdcCarta(new Carta('5', 10, Nipe.copas, Cor.preta));
            baralho.AdcCarta(new Carta('6', 10, Nipe.copas, Cor.preta));
            
            Console.WriteLine(baralho);
            Console.WriteLine();
            baralho.Embaralhar();
            Console.WriteLine(baralho);
            Console.WriteLine();
            baralho.Embaralhar();
            Mao mao = new Mao(baralho);
            Console.WriteLine("mão");
            Console.WriteLine(mao);

            Console.WriteLine("Baralho");
            Console.WriteLine(baralho);



        }
    }
}
