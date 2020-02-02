using System;
using mesa;
using Enuns;

namespace Pif_paf
{
    class Tela
    {
        public static int qntCemiterio;
        public static void Linha(int tamanho)
        {
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("----");
            }
            Console.WriteLine("----");
        }
        public static void Corpo(int tamanho)
        {

            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("|   ");
            }
            Console.WriteLine("    |");
        }
        public static void Costas(int tamanho)
        {

            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("|?  ");
            }
            Console.WriteLine("    |");
        }
        public static void Posicoes(int tamanho)
        {

            for (int i = 1; i <= tamanho; i++)
            {
                Console.Write($" {i}  ");
            }
            Console.WriteLine();
        }
        public static void Desenho(Mao mao, bool visibilidade)
        {
            Linha(mao.QntCartas());
            if (mao.Visibilidade == true && visibilidade == true)
            {
                ImprimeMao(mao);
            }
            else
            {
                Costas(mao.QntCartas());
            }
            Corpo(mao.QntCartas());
            Corpo(mao.QntCartas());
            Linha(mao.QntCartas());

        }
        public static void ImprimeMesa(JogoPifpaf jogo)
        {
            Console.Clear();
            int indiceAdeversario = jogo.indiceAnterior;
            Console.WriteLine("Jogador " + indiceAdeversario);
            Desenho(jogo.Jogadores[indiceAdeversario].Mao, false);
            string carta = "vazio";
            qntCemiterio = jogo.Cemiterio.QntCartas();
            if (qntCemiterio > 0)
            {
                carta = jogo.Cemiterio.Cartas[qntCemiterio - 1] + "";
            }



            Console.WriteLine("                                            " + qntCemiterio + "          " + jogo.Baralho.QntCartas());
            Console.WriteLine("                                         ----------  ---------");
            Console.WriteLine("                                         |" + carta + "   |  |?      |");
            Console.WriteLine("                                         |        |  |       |");
            Console.WriteLine("                                         |        |  |       |");
            Console.WriteLine("                                         |        |  |       |");
            Console.WriteLine("                                         ----------  ---------");

            Console.WriteLine();
            Console.WriteLine("Jogador " + jogo.JogadorAtual.Numero);
            Desenho(jogo.JogadorAtual.Mao, true);
            Posicoes(jogo.JogadorAtual.Mao.QntCartas());
            Linha(jogo.JogadorAtual.Mao.QntCartas());
        }
        public static int EntrarPosicao()
        {
            return int.Parse(Console.ReadLine());
        }

        public static int EntrarPosicao(Ai ai)
        {
            return ai.SelecRandonIndiceMao();
        }
        public static bool Confirmar()
        {
            Console.Write("Confirmar (s/n)?");
            char ch = char.Parse(Console.ReadLine());
            if (ch == 's')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Carta Compra(Baralho baralho, Pilha cemiterio)
        {
            if (qntCemiterio == 0)
            {
                Console.Write("Pressione (Enter) para comprar uma carta: ");
                Console.ReadLine();
                return baralho.RemoveTop();
            }
            else
            {
                Console.Write("!Comprar do Maço ou Cemiterio (m, c)?: ");
                char c = char.Parse(Console.ReadLine());
                if (c == 'm')
                {
                    return baralho.RemoveTop();
                }
                else
                {
                    return cemiterio.RemoveTop();
                }
            }
        }

        public static void PrintCarta(string carta, ConsoleColor cor)
        {

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = cor;
            Console.Write(carta);
            Console.ForegroundColor = aux;
        }
        public static void PrintSelecao(string txt)
        {

            ConsoleColor aux = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(txt);
            Console.BackgroundColor = aux;
        }
        public static void ImprimeMao(Mao mao)
        {

            foreach (Carta cart in mao.GetListaCartas())
            {
                string txt = cart.Letra.ToString();
                Console.Write("|");

                if (mao.Selecao == cart)
                {
                    PrintSelecao(txt);
                }
                else
                {
                    Console.Write(txt);
                }

                if (txt == "10")
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("  ");
                }
            }
            Console.WriteLine("    |");

            //print nipes
            foreach (Carta cart in mao.GetListaCartas())
            {
                string txt = cart.Nipe.ToString();
                Console.Write("|");

                if (cart.Cor == Cor.vermelha)
                {
                    PrintCarta(txt, ConsoleColor.Red);
                }
                else
                {
                    PrintCarta(txt, ConsoleColor.DarkGray);
                }



            }
            Console.WriteLine("    |");


        }
    }
}
