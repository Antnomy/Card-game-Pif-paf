
using System;
using mesa;
using Enuns;


namespace Pif_paf
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("   Jogo de Cartas Pifpaf");
            Console.WriteLine();
            JogoPifpaf jogo = new JogoPifpaf(Tela.Jogadores());


            while (!jogo.FimJogo)
            {
                jogo.Mao = jogo.JogadorAtual.Mao;
                if (jogo.JogadorAtual.Auto)
                {
                    jogo.Ai.Mao = jogo.Mao;
                    Tela.ImprimeMesa(jogo);


                    Tela.Espera(2, false);
                    if (jogo.Ai.SeCemiterioArmaJogo())
                    {
                        jogo.Mao.AdcCarta(jogo.Ai.Cemiterio.RemoveTop());
                    }
                    else
                    {
                        jogo.Mao.AdcCarta(jogo.Ai.Baralho.RemoveTop());
                    }
                    Tela.ImprimeMesa(jogo);
                    Tela.Espera(4, false);

                    jogo.Ai.ArrjarSeqtIn();
                    //jogo.Mao.VerifSequencias();

                    //jogo.Ai.AltAs();
                    jogo.Mao.RemoveGrupos();
                    jogo.Mao.VerifSequencias();

                    jogo.Ai.ArranjarTrincas();
                    jogo.Mao.VerifTrincas();
                    Tela.ImprimeMesa(jogo);
                    Tela.Espera(2, false);

                    jogo.Ai.SelecDescarte();
                    Tela.ImprimeMesa(jogo);
                    Tela.Espera(3, false);

                    Console.WriteLine(jogo.JogadorAtual.Nome + " jogos: " + jogo.Mao.TotalArranjos());
                    Console.ReadLine();

                    jogo.MudarJogador();

                }
                else
                {
                    try
                    {
                        Tela.ImprimeMesa(jogo);
                        if (jogo.fase == Fase.compra)
                        {
                            jogo.Mao.AdcCarta(Tela.Compra(jogo.Baralho, jogo.Cemiterio));
                            jogo.fase = Fase.movimentacao;

                        }

                        if (jogo.fase == Fase.movimentacao)
                        {

                            jogo.Mao.VerifTrincas();
                            jogo.Mao.VerifSequencias();
                            Tela.ImprimeMesa(jogo);


                            if (Tela.Confirmar("Deseja mover uma carta (s/n)? "))
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

                            }
                            else
                            {
                                jogo.fase = Fase.descarte;
                            }
                        }

                        if (jogo.fase == Fase.descarte)
                        {
                            jogo.Mao.DesMarcar();
                            Tela.ImprimeMesa(jogo);
                            Console.Write("Decarte uma carta (posição): ");

                            int pos = Tela.EntrarPosicao();
                            jogo.Mao.Marcar(pos - 1);
                            Tela.ImprimeMesa(jogo);
                            if (Tela.Confirmar("Confirmar (s/n)? "))
                            {
                                jogo.Cemiterio.AdcCarta(jogo.Mao.RemovCarta(pos - 1));

                                jogo.Mao.RemoveGrupos();
                                jogo.Mao.VerifTrincas();
                                jogo.Mao.VerifSequencias();

                                jogo.Mao.DesMarcar();
                                jogo.MudarJogador();
                                jogo.fase = Fase.compra;
                            }
                        }

                        Console.WriteLine(jogo.JogadorAtual.Nome + " jogos: " + jogo.Mao.TotalArranjos());
                        Console.ReadLine();

                    }
                    catch (PifpafExeption e)
                    {
                        Console.WriteLine();
                        Tela.Print(e.Message, ConsoleColor.Red);
                        Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine();
                        Tela.Print("Formato incorreto.!", ConsoleColor.Red);
                        Console.ReadLine();
                    }

                }


                if (jogo.VerifSeBateu())
                {
                    jogo.FimJogo = true;
                    Tela.Resultado(jogo);
                }
                if (jogo.Baralho.QntCartas() == 0)
                {
                    jogo.AdcCemiterioParaBaralho();
                    Console.WriteLine("!As cartas do baralho acabaram, o cemiterio sera adcionado sera usado ");
                    Console.Read();
                }
            }
        }
    }
}
