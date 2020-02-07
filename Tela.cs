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

        public static void ImprimeMao(Mao mao, bool visibilidade)
        {
            Linha(mao.QntCartas());
            if (mao.Visibilidade == true && visibilidade == true)
            {
                ImprimeCartas(mao);
            }
            else
            {
                Costas(mao.QntCartas());
            }
            Corpo(mao.QntCartas());
            Corpo(mao.QntCartas());
            Linha(mao.QntCartas());
            Posicoes(mao.QntCartas());
            Linha(mao.QntCartas());

        }
        public static void ImprimeMesa(JogoPifpaf jogo)
        {
            Console.Clear();
            
            Console.WriteLine(jogo.Jogadores[0].Nome + " " + 0);
            ImprimeMao(jogo.Jogadores[0].Mao, true);
            string carta = "vazio";
            qntCemiterio = jogo.Cemiterio.QntCartas();
            if (qntCemiterio > 0)
            {
                carta = jogo.Cemiterio.Cartas[qntCemiterio - 1] + "";
            }
            //Console.WriteLine("                " + qntCemiterio + "                             " + jogo.Baralho.QntCartas());
            Console.WriteLine("     Cemiterio                Monte");
            Console.WriteLine("     --------                --------");
            Console.WriteLine("    |" + carta + "   |              |        |");
            Console.WriteLine("    |        |              |   X    |");
            Console.WriteLine("    |        |              |        |");
            Console.WriteLine("    |        |              |        |");
            Console.WriteLine("     --------                --------");
            Console.WriteLine();
            Console.WriteLine("Jogador " + jogo.Jogadores[1].Numero);
            ImprimeMao(jogo.Jogadores[1].Mao, true);
           
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

        public static void Print(string txt, ConsoleColor cor)
        {

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = cor;
            Console.Write(txt);
            Console.ForegroundColor = aux;
        }
        public static void PrintSelecao(string txt)
        {
            
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(txt);
            Console.BackgroundColor = default;
        }
        public static void ImprimeCartas(Mao mao)
        {

            foreach (Carta cart in mao.GetListaCartas())
            {
                string txt = cart.Letra.ToString();
                // Grupo
                switch (cart.Grupo)
                {
                    case Grupo.Trincas:
                        Print("|", ConsoleColor.Green);
                        break;
                    case Grupo.Sequencias:
                        Print("|", ConsoleColor.Blue);
                        break;
                    default:                      
                        Console.Write("|");
                        break;
                }
                
                //se esta marcada
                if (mao.Selecao == cart)
                {
                    PrintSelecao(txt);
                }
                else
                {
                    Console.Write(txt);
                }
                //Se é 10
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
                    Print(txt, ConsoleColor.Red);
                }
                else
                {
                    Print(txt, ConsoleColor.DarkGray);
                }



            }
            Console.WriteLine("    |");


        }
    }
}
