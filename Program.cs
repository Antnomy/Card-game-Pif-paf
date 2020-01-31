
using System;
using mesa;
using Enuns;

namespace Pif_paf
{
    class Program
    {
        static void Main(string[] args)
        {
            JogoPifpaf jogo = new JogoPifpaf();
            Tela.ImprimeMesa(jogo.Baralho, jogo.Cemiterio, jogo.Mao);

            while (true)
            {
                try
                {
                    Tela.ImprimeMesa(jogo.Baralho, jogo.Cemiterio, jogo.Mao);

                    jogo.Mao.AdcCarta(Tela.Compra(jogo.Baralho, jogo.Cemiterio));
                    Tela.ImprimeMesa(jogo.Baralho, jogo.Cemiterio, jogo.Mao);

                    Console.Write("Decarte uma carta (posição): ");
                    int pos = int.Parse(Console.ReadLine());
                    jogo.Cemiterio.AdcCarta(jogo.Mao.Descartar(pos));

                    Tela.ImprimeMesa(jogo.Baralho, jogo.Cemiterio, jogo.Mao);
                    char ch = 's';

                    while (ch == 's')
                    {
                        Console.WriteLine("Mover uma carta (s/n)? ");
                        ch = char.Parse(Console.ReadLine());
                        if (ch == 's')
                        {
                            Console.Write("Origem: ");
                            int origem = int.Parse(Console.ReadLine());
                            jogo.Mao.Marcar(origem);
                            Tela.ImprimeMesa(jogo.Baralho, jogo.Cemiterio, jogo.Mao);

                            Console.Write("Destino: ");
                            int destino = int.Parse(Console.ReadLine());

                            jogo.MoverCarta(origem, destino);
                            jogo.Mao.DesMarcar();

                            Tela.ImprimeMesa(jogo.Baralho, jogo.Cemiterio, jogo.Mao);
                        }
                    }
                }
                catch (PifpafExeption e)
                {
                    Console.WriteLine("Erro!... " + e.Message);
                    Console.ReadLine();
                }
            }



        }
    }
}
