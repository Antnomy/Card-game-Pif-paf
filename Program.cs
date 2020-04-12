
using System;
using mesa;
using Enuns;


namespace Pif_paf
{
    class Program
    {
        static void Main(string[] args)
        {
            JogoPifpaf jogo = new JogoPifpaf(Tela.Jogadores());

            /*Baralho Baralho = new Baralho();
            Pilha Cemiterio = new Pilha();
            Mao Mao = new Mao();
            Ai ai = new Ai(Baralho, Cemiterio, Mao);
            Carta c1 = new Carta("2", 10, 2, Nipe.Cop, Cor.vermelha);
            Carta c2 = new Carta("3", 10, 2, Nipe.Cop, Cor.vermelha);
            

            c1.Grupo = Grupo.Trincas;
            c2.Grupo = Grupo.Pares;

            Console.WriteLine(ai.Livre(c1, c2));
            Console.ReadLine();*/

            while (!jogo.FimJogo)
            {
                jogo.Mao = jogo.JogadorAtual.Mao;
                if (jogo.JogadorAtual.Auto)
                {
                    jogo.Ai.Mao = jogo.Mao;
                    Tela.ImprimeMesa(jogo);

                    //jogo.Ai.AutoPlay();
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
                    jogo.Mao.RemoveGrupos();
                    jogo.Mao.VerifSequencias();

                    jogo.Ai.As();
                    jogo.Mao.VerifSequencias();

                    //jogo.Ai.ArranjarTrincas();
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
                        if (jogo.Mao.QntCartas() == 9)
                        {
                            jogo.Mao.AdcCarta(Tela.Compra(jogo.Baralho, jogo.Cemiterio));
                        }
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
                            jogo.Cemiterio.AdcCarta(jogo.Mao.RemovCarta(pos - 1));
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
                    catch (FormatException e)
                    {
                        Console.WriteLine("Erro!... " + e.Message);
                        Console.ReadLine();
                    }
                    Console.WriteLine(jogo.JogadorAtual.Nome + " jogos: " + jogo.Mao.TotalArranjos());
                    Console.ReadLine();
                    jogo.MudarJogador();
                    Console.WriteLine(jogo.JogadorAtual.Nome + " jogos: " + jogo.Mao.TotalArranjos());
                    Console.ReadLine();
                }


                if (jogo.VerifSeBateu())
                {
                    jogo.FimJogo = true;
                    Tela.Resultado(jogo);
                }



            }
        }
    }
}
