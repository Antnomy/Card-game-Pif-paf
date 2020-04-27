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
                Costas(mao.QntCartas());
            }
            Corpo(mao.QntCartas());
            Corpo(mao.QntCartas());
            Linha(mao.QntCartas());
            Posicoes(mao.QntCartas());
            Linha(mao.QntCartas());

        }
        private static string ListaPlayers(Jogador[] jogadores)
        {
            string aux = "    ";
            for (int i = 0; i < jogadores.Length; i++)
            {
                aux+= jogadores[i].Nome +", ";
            }
            return aux;
        }
        public static void Player(int indice, JogoPifpaf jogo, bool mostrarJogos)
        {
            
            if (jogo.JogadorAtual.Equals(jogo.Jogadores[indice]))
            {
                PrintSelecao(jogo.Jogadores[indice].Numero + "- " + jogo.Jogadores[indice].Nome, ConsoleColor.DarkCyan);
                Console.Write(" << Vez...     ");
            }
            else
            {
                Console.Write(jogo.Jogadores[indice].Numero + "- " + jogo.Jogadores[indice].Nome + "           ");
            }
            if (mostrarJogos)
            {
                Console.Write("T " + jogo.Jogadores[indice].Mao.Trincas + " - S " + jogo.Jogadores[indice].Mao.Sequencias);            
            }

            Console.WriteLine();
            ImprimeMao(jogo.Jogadores[indice].Mao, mostrarJogos);
        }
        public static void Avatar(Jogador[] jogadores)
        {
             void Body(string parte)
            {
                for (int i = 0; i < jogadores.Length; i++)
                {
                    Console.Write(parte);
                }
            }
            string[] aux = new string[4] { " _(_)_  ", "|     |  ", "-------  ", "* * * *  " };
            Body(aux[0]);
            Body(aux[1]);
            Body(aux[2]);
            Body(aux[3]);
        }
        public static void ImprimeMesa(JogoPifpaf jogo)
        {
            Console.Clear();
            if (jogo.JogadorAtual.Numero != 1)
            {
                Player(jogo.JogadorAtual.Numero - 1, jogo, false);
            }
            else
            {
                Player(jogo.JogadorAtual.Numero, jogo, false);
            }
            string carta = "vazio";
            qntCemiterio = jogo.Cemiterio.QntCartas();
            if (qntCemiterio > 0)
            {
                carta = jogo.Cemiterio.Top().Letra + " ";
            }
            Console.WriteLine("    " + qntCemiterio + "                      " + jogo.Baralho.QntCartas());
            Console.Write("    Cemiterio                Maço        Jogadores: "+ jogo.Jogadores.Length);
            Avatar(jogo.Jogadores);
            Console.WriteLine("     --------                --------" + ListaPlayers(jogo.Jogadores));

            Console.Write("   |" + carta );
            if (qntCemiterio > 0)
            {
                jogo.Cemiterio.Top().PrintNipe();
            }
            Console.WriteLine("   |              |        |");
            Console.WriteLine("   |        |              |   X    |");

            Console.WriteLine("   |        |              |        |" + "    Turno - " + jogo.Turno);
            Console.WriteLine("   |        |              |        |");
            Console.WriteLine("    --------                --------");
            Console.WriteLine();

            Player(0, jogo, true);
        }
        public static void Resultado(JogoPifpaf jogo)
        {
            Console.Clear();
            /* for (int i = 0; i < jogo.Jogadores.Length; i++)
             {
                 Console.WriteLine(jogo.Jogadores[i].Nome + " " + jogo.Jogadores[i].Mao.Trincas + " Trincas(s), " + jogo.Jogadores[i].Mao.Sequencias + " Sequencia(s)");
                 ImprimeMao(jogo.Jogadores[0].Mao, true);
                 Console.WriteLine();
             }*/

            Console.WriteLine();
            Console.WriteLine(">>> FIM DE JOGO! " + jogo.JogadorAnterior().Nome + " BATEU!!...");
            Console.WriteLine(jogo.JogadorAnterior().Mao.Trincas + " Trincas(s), " + jogo.JogadorAnterior().Mao.Sequencias + " Sequencia(s)");
            Console.WriteLine();
            ImprimeMao(jogo.JogadorAnterior().Mao, true);
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
                        Console.Write(seg + " seg");
                    }
                }
            }
        }
        public static bool Confirmar(string txt)
        {
            Console.Write(txt);
            string st = Console.ReadLine();

            if(st != "n" && st != "s" && st != "")
            {
                throw new PifpafExeption("Erro! Digite somente uma das opções acima...ENTER para continuar:");
            }
            if (st == "s")
            {
                return true;
            }
            else if(st == "")
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

            Console.Write("Informe o numero de jogadores max 8 (Enter): ");
            int n = int.Parse(Console.ReadLine());
            
            if(n < 2 || n > 8)
            {
                //throw new PifpafExeption("!!..Digite um numero entre 2 e 8");
                n = 2;
            }
            Random r = new Random();
            string nome;
            string[] bots = new string[]
            { "João", "Antônio", "Junior", "John Macllaine", "Moises", "Spirit", "Phantom", "G-virus", "T-virus", "ANJ", "SUBROSA", "Fallen", "Matheus", "Snike",
            "Yami Yugi", "Dark Magician", "Blue eyes", "GOD", "Kurosaki", "Seya", "Lucifer"};
            Jogador[] jogadores = new Jogador[n];

            
            Console.Write("Seu nome: ");
            nome = Console.ReadLine();
            jogadores[0] = new Jogador(1, null, nome, false);
            for (int i = 1; i < n; i++)
            {
                jogadores[i] = new Jogador(i + 1, null, "bot " + bots[r.Next(20)], true);
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

                if (c != 'm' && c != 'c')
                {
                    throw new PifpafExeption("Erro! Digite: (m) ou (c)");
                }

                
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
        public static void PrintSelecao(string txt, ConsoleColor cor)
        {

            Console.BackgroundColor = cor;
            Console.Write(txt);
            Console.BackgroundColor = default;
        }
        public static void DesenhaSetas()
        {
            Console.WriteLine();
            PrintSelecao(" <-- 4   ", ConsoleColor.DarkGreen);
            Console.Write("   5   ");
            PrintSelecao(" 6 -->   ", ConsoleColor.DarkGreen);
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
                    PrintSelecao(txt, ConsoleColor.White);
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
            //Console.WriteLine("    |");

            //print nipes
            /*foreach (Carta cart in mao.GetListaCartas())
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
            }*/
            Console.WriteLine("    |");
            foreach (Carta cart in mao.GetListaCartas())
            {
                Console.Write("|");
                cart.PrintNipe();
            }
            Console.WriteLine("    |");
        }
    }
}
