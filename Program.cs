
using System;
using mesa;
using Enuns;

namespace Pif_paf
{
    class Program
    {
        static void Main(string[] args)
        {
            
            JogoPifpaf jogo = new JogoPifpaf(2);
            Tela.ImprimeMesa(jogo);

            while (true)
            {
                try
                {
                    Tela.ImprimeMesa(jogo);

                    jogo.Mao.AdcCarta(Tela.Compra(jogo.Baralho, jogo.Cemiterio));
                    Tela.ImprimeMesa(jogo);

                    Console.Write("Decarte uma carta (posição): ");
                    int pos = Tela.EntrarPosicao();
                    jogo.Mao.Marcar(pos);
                    Tela.ImprimeMesa(jogo);
                    if (Tela.Confirmar())
                    {
                        jogo.Cemiterio.AdcCarta(jogo.Mao.Descartar(pos));
                        jogo.Mao.DesMarcar();

                    }
                    Tela.ImprimeMesa(jogo);
                    char ch = 's';

                    while (ch == 's')
                    {
                        Console.Write("Mover uma carta (s/n)? ");
                        ch = char.Parse(Console.ReadLine());
                        if (ch == 's')
                        {
                            Console.Write("Origem (posiçao): ");
                            int origem = Tela.EntrarPosicao();
                            jogo.Mao.Marcar(origem);
                            Tela.ImprimeMesa(jogo);

                            Console.Write("Destino (posição): ");
                            int destino = Tela.EntrarPosicao(); 

                            jogo.MoverCarta(origem, destino);
                            jogo.Mao.DesMarcar();

                            Tela.ImprimeMesa(jogo);
                        }
                    }
                    jogo.MudarJogador();
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
