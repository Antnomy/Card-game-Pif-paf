
using System;
using mesa;

namespace Pif_paf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("   Jogo de Cartas Pifpaf");
            Console.WriteLine();
            Jogador[] jogadores = Tela.Jogadores();

            JogoPifpaf jogo = new JogoPifpaf(jogadores);

            //variavel para modificar pergunta sobre opção de mover as cartas p/ mover novamente
            string msg = "";

            while (!jogo.FimJogo)
            {
                jogo.Mao = jogo.JogadorAtual.Mao;
                if (jogo.JogadorAtual.Auto)
                {
                    jogo.Ai.Mao = jogo.Mao;
                    jogo.fase = Fase.compra;
                    Tela.ImprimeMesa(jogo);
                    Tela.Espera(2, false);
                    jogo.Ai.Comprar();

                    Tela.ImprimeMesa(jogo);
                    Tela.Espera(4, false);

                    jogo.fase = Fase.movimentacao;
                    jogo.Mao.RemoveGrupos();
                    jogo.Ai.ArrjarSeqtIn();
                    jogo.Mao.VerifSequencias();

                    jogo.Ai.ArranjarTrincas();
                    jogo.Mao.VerifTrincas();
                    Tela.ImprimeMesa(jogo);
                    Tela.Espera(2, false);

                    jogo.fase = Fase.descarte;
                    jogo.Ai.SelecDescarte();
                    Tela.ImprimeMesa(jogo);
                    Tela.Espera(3, false);

                    jogo.fase = Fase.compra;

                    //Console.WriteLine(jogo.JogadorAtual.Nome + " trincas: " + jogo.Mao.Trincas);
                    //Console.ReadLine();

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
                            jogo.Mao.DesMarcar();

                            jogo.Mao.RemoveGrupos();                          
                            jogo.Mao.VerifSequencias();
                            jogo.Mao.VerifTrincas();
                            Tela.ImprimeMesa(jogo);

                            if(msg == "")
                            {
                                msg = "Deseja mover uma carta (n/s)?";
                            }
                           
                            if (Tela.Confirmar(msg))
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
                                msg = "Deseja mover outra carta (n/s)? ";
                            }
                            else
                            {
                                msg = "";
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
                                jogo.Cemiterio.AdcCarta(jogo.Mao.Descartar(pos - 1));

                                jogo.Mao.RemoveGrupos();
                                jogo.Mao.VerifTrincas();
                                jogo.Mao.VerifSequencias();

                                jogo.Mao.DesMarcar();
                                jogo.MudarJogador();
                                jogo.fase = Fase.compra;
                            }
                        }

                        //Console.WriteLine(jogo.JogadorAtual.Nome + " jogos: " + jogo.Mao.TotalArranjos());
                        //Console.ReadLine();

                    }
                    catch (PifpafExeption e)
                    {
                        Console.WriteLine();
                        Tela.Print(e.Message, ConsoleColor.Red);
                        Console.WriteLine();
                        Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine();
                        Tela.Print("Incorreto! Digite uma das opções acima!! ENTER para continuar...", ConsoleColor.Red);
                        Console.WriteLine();
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
                    Console.WriteLine("As cartas do baralho acabaram, o cemiterio sera adcionado sera usado!. ENTER para continuar.");
                    Console.Read();
                }
            }
        }
    }
}
