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
        public static void Player(int indice, JogoPifpaf jogo)
        {
            Console.WriteLine(jogo.Jogadores[indice].Numero + "-" + jogo.Jogadores[indice].Nome);
            if (jogo.JogadorAtual.Equals(jogo.Jogadores[indice]))
            {
                Console.WriteLine(" << Playing...");
            }
        }
        public static void ImprimeMesa(JogoPifpaf jogo)
        {
            Console.Clear();

            Player(1, jogo);
            ImprimeMao(jogo.Jogadores[1].Mao, true);
            string carta = "vazio";
            qntCemiterio = jogo.Cemiterio.QntCartas();
            if (qntCemiterio > 0)
            {
                carta = jogo.Cemiterio.Cartas[qntCemiterio - 1] + "";
            }
            Console.WriteLine("    " + qntCemiterio + "                      " + jogo.Baralho.QntCartas());
            Console.WriteLine("    Cemiterio                Monte");
            Console.WriteLine("     --------                --------");
            Console.WriteLine("   |" + carta + "   |              |        |");
            Console.WriteLine("   |        |              |   X    |");
            Console.WriteLine("   |        |              |        |");
            Console.WriteLine("   |        |              |        |");
            Console.WriteLine("    --------                --------");
            Console.WriteLine();
           
            Player(0, jogo);
            ImprimeMao(jogo.Jogadores[0].Mao, true);

        }
        public static void Resultado(JogoPifpaf jogo)
        {
            Console.Clear();
            Console.WriteLine(jogo.JogadorAtual.Nome + " Bateu...");
            Console.WriteLine("Trincas + Pares: " + jogo.JogadorAtual.Mao.TotalArranjos());
            Console.ReadLine();
        }
        public static int EntrarPosicao()
        {
            return int.Parse(Console.ReadLine());
        }

        public static void Espera(int segundos, bool mostraContagem)
        {
            TimeSpan t1 = new TimeSpan(100000000);
            long cont = 0;
            int seg = 0;

            while (seg != segundos)
            {
                cont++;
                if (cont == t1.Ticks)
                {
                    seg++;
                    cont = 0;
                    if (mostraContagem)
                    {
                        Console.Clear();
                        Console.WriteLine(seg + " seg");
                    }
                }

            }
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
        public static Jogador[] Jogadores()
        {
            Console.Write("Numero de jogadores: ");
            int n = int.Parse(Console.ReadLine());

            string nome;
            Jogador[] jogadores = new Jogador[n];

            Console.WriteLine($"#{1} jogador:");
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            jogadores[0] = new Jogador(1, null, nome, false);
            for (int i = 1; i < n; i++)
            {
                jogadores[i] = new Jogador(i + 1, null, "NPC", true);
            }
            return jogadores;
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
                //txt = txt + "   ";
                // Grupo
                switch (cart.Grupo)
                {
                    case Grupo.Trincas:
                        Print("|", ConsoleColor.Green);
                        break;
                    case Grupo.Sequencias:
                        Print("|", ConsoleColor.Blue);
                        break;
                    case Grupo.Pares:
                        Print("|", ConsoleColor.Yellow);
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
