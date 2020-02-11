
using System;
using mesa;
using utilitarios;

namespace Pif_paf
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Tela.Espera(5, true);
            JogoPifpaf jogo = new JogoPifpaf(Tela.Jogadores());
            
            while (!jogo.FimJogo)
            {
                jogo.Mao = jogo.JogadorAtual.Mao;
                if (jogo.JogadorAtual.Auto)
                {                  
                    Tela.ImprimeMesa(jogo);
                   
                    jogo.Ai.SetMao(jogo.Mao);
                    jogo.Ai.AutoPlay();
                    jogo.Mao.VerifTrincas();
                    jogo.Mao.VerifSequencias();
                    Tela.ImprimeMesa(jogo);

                    
                    Console.WriteLine("CPU terminou, " + jogo.Mao.TotalArranjos());
                    Console.ReadLine();
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
                if (jogo.JogadorAtual.Mao.TotalArranjos() == 3)
                {
                    jogo.FimJogo = true;
                    Tela.Resultado(jogo);
                }

                jogo.MudarJogador();
            }
        }
    }
}
