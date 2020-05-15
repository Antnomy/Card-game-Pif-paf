using System.Text;
using System;
using mesa;
using Enuns;
using System.Collections.Generic;

namespace Pif_paf
{
    class Program
    {      
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            
           /* List<Carta> listaTexte = new List<Carta>();
            listaTexte.Add(new Carta("A", 10, 1, Nipe.Cop, Cor.vermelha));
            listaTexte.Add(new Carta("A", 10, 1, Nipe.Our, Cor.preta));
            listaTexte.Add(new Carta("A", 10, 1, Nipe.Pau, Cor.preta));
            listaTexte.Add(new Carta("A", 10, 1, Nipe.Esp, Cor.preta));
            listaTexte.Add(new Carta("k", 10, 13, Nipe.Our, Cor.preta));
            listaTexte.Add(new Carta("Q", 10, 12, Nipe.Our, Cor.vermelha));
            listaTexte.Add(new Carta("10", 10, 10, Nipe.Our, Cor.vermelha));
            Tela.ImprimeCartas(listaTexte, false);
            Carta buscada = new Carta("J", 10, 11, Nipe.Our, Cor.preta);
            
          
            
            Console.WriteLine(listaTexte[1]);
            Tela.ImpCarta2(listaTexte[1], true, true, ConsoleColor.DarkRed);
            Console.ReadLine();*/

            
            int n = Tela.Inicio();            
            Console.Write("Seu nome: ");
            string nomeJogador = Console.ReadLine();

            JogoPifpaf jogo = new JogoPifpaf(n, nomeJogador,false);
           
            while (!jogo.FimJogo)
            {
                //jogo.Mao = jogo.JogadorAtual.Mao;
                if (jogo.JogadorAtual.Auto)
                {
                    string msg = "   Aguarde!...";
                    jogo.Ai.Mao = jogo.JogadorAtual.Mao;
                    jogo.fase = Fase.compra;
                    Tela.ImprimeMesa(jogo);
                    Console.WriteLine(msg);

                    Tela.Espera(3, false);
                    Console.WriteLine(msg);
                    jogo.Ai.Comprar();

                    Tela.ImprimeMesa(jogo);
                    Console.WriteLine(msg);
                    Tela.Espera(4, false);

                    jogo.fase = Fase.movimentacao;
                    jogo.Ai.Mao.RemoveGrupos();
                    jogo.Ai.ArrjarSeqtIn();
                    jogo.Ai.Mao.VerifSequencias();

                    jogo.Ai.ArranjarTrincas();
                    jogo.Ai.Mao.VerifTrincas();
                    jogo.Ai.Mao.VerifPares();



                    Tela.ImprimeMesa(jogo);
                    Console.WriteLine(msg);
                    Tela.Espera(2, false);

                    jogo.fase = Fase.descarte;
                    jogo.Ai.SelecDescarte();
                    Tela.ImprimeMesa(jogo);
                    Console.WriteLine(msg);
                    Tela.Espera(3, false);

                    jogo.fase = Fase.compra;
             
                    jogo.MudarJogador();
                }
                else
                {
                    try
                    {
                        Tela.ImprimeMesa(jogo);
                        if (jogo.fase == Fase.compra)
                        {
                            Console.WriteLine("  > COMPRAR CARTA <");
                          
                            if (Tela.SeleCompra())
                            {
                                jogo.JogadorAtual.Mao.AdcCarta(jogo.Baralho.RemoveTop());
                            }
                            else
                            {
                                jogo.JogadorAtual.Mao.AdcCarta(jogo.Cemiterio.RemoveTop());
                            }
                            jogo.fase = Fase.movimentacao;

                        }

                        if (jogo.fase == Fase.movimentacao)
                        {
                            jogo.JogadorAtual.Mao.DesMarcar();

                            jogo.JogadorAtual.Mao.RemoveGrupos();
                            jogo.JogadorAtual.Mao.VerifSequencias();
                            jogo.JogadorAtual.Mao.VerifTrincas();
                            jogo.JogadorAtual.Mao.VerifPares();
                            Tela.ImprimeMesa(jogo);

                           
                            if (Tela.Confirmar("Deseja mover uma carta (s/n)? "))
                            {
                                
                                bool t = false;
                                while (!t)
                                {
                                    Tela.ImprimeMesa(jogo);
                                   Console.WriteLine("  > MOVER CARTA < ");
                                   Console.WriteLine("    * Digite (Posição) para Mover: ");
                                   Console.Write("    * Digite (  t ) para Terminar:   ");
                                   int origem = Tela.EntrarPosicao();

                                  if(origem == -1)
                                   {
                                       jogo.fase = Fase.descarte;
                                       t = true;
                                       continue;
                                   }
                                   jogo.JogadorAtual.Mao.Marcar(origem - 1);

                                   Tela.ImprimeMesa(jogo);
                                   Console.WriteLine("  > MOVER CARTA <");
                                   Console.Write("    Destino (Posição): ");
                                   int destino = Tela.EntrarPosicao();
                                   jogo.JogadorAtual.Mao.DesMarcar();

                                   jogo.JogadorAtual.Mao.MoverCarta(origem - 1, destino - 1);
                                   jogo.JogadorAtual.Mao.RemoveGrupos();
                                   jogo.JogadorAtual.Mao.VerifTrincas();
                                   jogo.JogadorAtual.Mao.VerifSequencias();
                                   jogo.JogadorAtual.Mao.VerifPares();

                                   jogo.JogadorAtual.Mao.Marcar(destino - 1);
                                   Tela.ImprimeMesa(jogo);
                                   Tela.Espera(1, false);
                                   jogo.JogadorAtual.Mao.DesMarcar();

                                   Tela.ImprimeMesa(jogo);                                                                      
                                }
                            }
                            else
                            {                             
                                jogo.fase = Fase.descarte;
                            }
                        }

                        if (jogo.fase == Fase.descarte)
                        {
                            jogo.JogadorAtual.Mao.DesMarcar();
                            Tela.ImprimeMesa(jogo);
                            Console.WriteLine("  > DESCARTAR <");
                            Console.Write("  * Digite uma (Posição): ");

                            int pos = Tela.EntrarPosicao();
                            jogo.JogadorAtual.Mao.Marcar(pos - 1);
                            Tela.ImprimeMesa(jogo);



                            if (Tela.Confirmar("Confirmar (s/n)? "))
                            {
                                jogo.Cemiterio.AdcCarta(jogo.JogadorAtual.Mao.Descartar(pos - 1));

                                jogo.JogadorAtual.Mao.RemoveGrupos();
                                jogo.JogadorAtual.Mao.VerifTrincas();
                                jogo.JogadorAtual.Mao.VerifSequencias();
                                jogo.JogadorAtual.Mao.VerifPares();

                                jogo.JogadorAtual.Mao.DesMarcar();
                                jogo.MudarJogador();
                                jogo.fase = Fase.compra;
                            }
                        }

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
                        Tela.Print("  !Digite uma das opções acima!! ENTER para continuar...", ConsoleColor.Red);
                        Console.WriteLine();
                        Console.ReadLine();                       
                    }

                }
                if (jogo.VerifSeBateu())
                {                 
                    Tela.Resultado(jogo);

                    Console.WriteLine();
                    if(Tela.Confirmar("Deseja jogar novamente (s/n)?"))
                    {
                        jogo = new JogoPifpaf(n, nomeJogador, true);
                    }
                    else
                    {
                        jogo.FimJogo = true;
                    }
                    
                }
                if (jogo.Baralho.QntCartas() == 0)
                {
                    jogo.AdcCemiterioParaBaralho();
                    Console.WriteLine("  As cartas do baralho acabaram, o cemiterio sera usado agora!. ENTER para continuar.");
                    Console.Read();
                }
            }
            return;
        }
    }
}
