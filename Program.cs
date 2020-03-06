
using System;
using mesa;
using Enuns;
using utilitarios;

namespace Pif_paf
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
           
            
            JogoPifpaf jogo = new JogoPifpaf(Tela.Jogadores());
           

            while (!jogo.FimJogo)
            {
                jogo.Mao = jogo.JogadorAtual.Mao;
                if (jogo.JogadorAtual.Auto)
                {                                                      
                    jogo.Ai.Mao = jogo.Mao;
                    Tela.ImprimeMesa(jogo);

                    //jogo.Ai.AutoPlay();
                    Tempo.Timer(2, false);
                    if (jogo.Ai.SeCemiterioArmaJogo())
                    {
                        Console.WriteLine("compra do cemiterio ");
                        Console.ReadLine();
                        jogo.Mao.AdcCarta(jogo.Ai.Cemiterio.RemoveTop());
                    }
                    else
                    {
                        Console.WriteLine("compra do deck ");
                        Console.ReadLine();
                        jogo.Mao.AdcCarta(jogo.Ai.Baralho.RemoveTop());
                    }
                    Tela.ImprimeMesa(jogo);


                    Tempo.Timer(4, false);
                    jogo.Mao.RemoveGrupos();
                    jogo.Ai.ArrjarSeqSemIguias();
                    jogo.Mao.VerifSequencias();

                    jogo.Ai.ArranjarTrincas();
                    jogo.Mao.VerifTrincas();
                    Tela.ImprimeMesa(jogo);

                    Tempo.Timer(2, false);
                    jogo.Ai.SelecDescarte();
                    Tela.ImprimeMesa(jogo);
                    Tempo.Timer(3, false);


                }
                else
                {
                    try
                    {                     
                        Tela.ImprimeMesa(jogo);
                        jogo.Mao.AdcCarta(Tela.Compra(jogo.Baralho, jogo.Cemiterio));
                       jogo.Mao.VerifTrincas();
                        jogo.Mao.VerifSequencias();

                        Tela.ImprimeMesa(jogo);
                        char ch = 's';
                        string quest = "Deseja mover uma carta (s/n)? ";
                        while (ch == 's')
                        {
                            Console.Write(quest);
                            ch = char.Parse(Console.ReadLine());
                            if (ch == 's')
                            {
                                Tela.ImprimeMesa(jogo);
                                Console.Write("Origem (posiçao): ");
                                int origem = Tela.EntrarPosicao();
                                jogo.Mao.Marcar(origem - 1);
                                Tela.ImprimeMesa(jogo);
                                Console.Write("Destino (posição): ");
                                int destino = Tela.EntrarPosicao();

                                jogo.Mao.MoverCarta(origem - 1, destino - 1);
                                jogo.Mao.DesMarcar();
                                jogo.Mao.RemoveGrupos();
                                jogo.Mao.VerifTrincas();
                                jogo.Mao.VerifSequencias();
                                Tela.ImprimeMesa(jogo);
                                quest = "Mover outra carta (s/n)? ";
                            }
                        }

                        Tela.ImprimeMesa(jogo);
                        Console.Write("Decarte uma carta (posição): ");

                        int pos = Tela.EntrarPosicao();
                        jogo.Mao.Marcar(pos - 1);
                        Tela.ImprimeMesa(jogo);
                        if (Tela.Confirmar())
                        {
                            jogo.Cemiterio.AdcCarta(jogo.Mao.Descartar(pos - 1));
                            jogo.Mao.DesMarcar();
                            jogo.Mao.RemoveGrupos();
                            jogo.Mao.VerifTrincas();
                            jogo.Mao.VerifSequencias();
                           
                        }
                        

                    }
                    catch (PifpafExeption e)
                    {
                        Console.WriteLine("Erro!... " + e.Message);
                        Console.ReadLine();
                    }                   
                   
                }
                jogo.VerifTodosJogos();
                Console.WriteLine(jogo.JogadorAtual.Nome + " jogos: " + jogo.Mao.TotalArranjos());
                Console.ReadLine();

                /*if (jogo.JogadorAtual.Mao.TotalArranjos() == 3)
                {
                    jogo.FimJogo = true;
                    Tela.Resultado(jogo);
                }*/
               
                jogo.MudarJogador();
            }
        }
    }
}
