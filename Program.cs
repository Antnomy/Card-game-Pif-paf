
using System;
using mesa;


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
                if (jogo.JogadorAtual is Ai)
                {
                    Console.WriteLine("Ai player");
                    Tela.ImprimeMesa(jogo);
                    
                    Ai cpu = jogo.JogadorAtual as Ai;
                    cpu.Jogar();
                    Tela.ImprimeMesa(jogo);
                    jogo.MudarJogador();

                    Console.WriteLine("Continuar");
                    Console.ReadLine();
                }
                else
                {


                    try
                    {

                        Tela.ImprimeMesa(jogo);

                        jogo.Mao.AdcCarta(Tela.Compra(jogo.Baralho, jogo.Cemiterio));
                        Tela.ImprimeMesa(jogo);


                        char ch = 's';

                        while (ch == 's')
                        {
                            Console.Write("Mover uma carta (s/n)? ");
                            ch = char.Parse(Console.ReadLine());
                            if (ch == 's')
                            {
                                Tela.ImprimeMesa(jogo);
                                Console.Write("Origem (posiçao): ");
                                int origem = Tela.EntrarPosicao();
                                jogo.Mao.Marcar(origem);
                                Tela.ImprimeMesa(jogo);

                                Console.Write("Destino (posição): ");
                                int destino = Tela.EntrarPosicao();

                                jogo.MoverCarta(origem - 1, destino - 1);
                                jogo.Mao.DesMarcar();

                                Tela.ImprimeMesa(jogo);
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

                        }
                        
                        
                    }
                    catch (PifpafExeption e)
                    {
                        Console.WriteLine("Erro!... " + e.Message);
                        Console.ReadLine();
                    }
                    Console.WriteLine("Qnt trincas: " + jogo.Mao.VerifTrincas());
                    Console.ReadLine();
                    jogo.MudarJogador();
                }
                
            }
        }
    }
}
