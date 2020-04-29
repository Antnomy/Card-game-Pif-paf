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
            Console.Write("  ");
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("----");
            }
            Console.WriteLine("----");
        }
        public static void Corpo(int tamanho)
        {
            Console.Write("  ");
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
            string aux = "";
            string pl;

            for (int i = 0; i < jogadores.Length; i++)
            {
                pl = jogadores[i].Nome;
                if (pl.Length > 8)
                {
                  pl = pl.Remove(8);
                }
                aux += pl + "     ";
                
            }
            return aux;
        }
        public static void Player(int indice, JogoPifpaf jogo, bool mostrarJogos)
        {

            if (jogo.JogadorAtual.Equals(jogo.Jogadores[indice]))
            {
                Console.Write(jogo.Jogadores[indice].Numero + "- ");
                Console.Write(jogo.Jogadores[indice].Nome);
                Print(" << Vez...     ", ConsoleColor.Green);
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
        public static void Fases(Fase fase)
        {
            switch (fase)
            {
                case Fase.compra:
                    Print("*", ConsoleColor.Green);
                    Console.Write(" * * *");
                    break;
                case Fase.movimentacao:
                    Console.Write("* ");
                    Print("*", ConsoleColor.Green);
                    Console.Write(" * *");
                    break;
                case Fase.descarte:
                    Console.Write("* * ");
                    Print("* ", ConsoleColor.Green);
                    Console.Write("*");
                    break;

            }
        }
        public static void Avatares(Jogador[] jogadores, Jogador jogadorAtual, Fase fase)
        {
            
            void Body(string parte, bool setNumero)
            {
                
                for (int i = 0; i < jogadores.Length; i++)
                {
                    if (setNumero)
                    {
                        Console.Write($"    |  {i + 1}  |  ");
                        /*Console.Write("|");
                        PrintSelecao($"  {i + 1}  ", ConsoleColor.Gray);
                        Console.Write("|  ");*/
                    }
                    else
                    {
                        Console.Write("    "+ parte);
                    }
                }
                Console.WriteLine();               
            }

            Console.WriteLine();
            Body(" _(_)_   ", false);
            Body("|     |", true);
            Body("-------  ", false);

            Console.WriteLine("    "+ ListaPlayers(jogadores));
            Console.Write("    ");
            //fases
            for (int i = 0; i < jogadores.Length; i++)
            {
                if (jogadorAtual.Equals(jogadores[i]))
                {                   
                    Fases(fase);              
                }
                else
                {
                    Console.Write("             ");
                }
            }
            //Body(aux[3], false);
            Console.WriteLine();
        }
        public static void ImprimeMesa(JogoPifpaf jogo)
        {
            Console.Clear();
            /*if (jogo.JogadorAtual.Numero != 1)
            {
                Player(jogo.JogadorAtual.Numero - 1, jogo, false);
            }
            else
            {
                Player(jogo.JogadorAtual.Numero, jogo, false);
            }*/

            Avatares(jogo.Jogadores, jogo.JogadorAtual, jogo.fase);
            string carta = "vazio";
            qntCemiterio = jogo.Cemiterio.QntCartas();
            if (qntCemiterio > 0)
            {
                carta = jogo.Cemiterio.Top().Letra + " ";
            }
            Console.WriteLine("    " + qntCemiterio + "                      " + jogo.Baralho.QntCartas());
            Console.WriteLine("    Cemiterio                Maço        Jogadores: " + jogo.Jogadores.Length);

            Console.WriteLine("     --------                --------    ");

            Console.Write("   |" + carta);
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

            if (st != "n" && st != "s" && st != "")
            {
                throw new PifpafExeption("Erro! Digite somente uma das opções acima...ENTER para continuar:");
            }
            if (st == "s")
            {
                return true;
            }
            else if (st == "")
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

            if (n < 2 || n > 8)
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
            jogadores[0] = new Jogador(1, null, nome+ "........", false);
            for (int i = 1; i < n; i++)
            {
                jogadores[i] = new Jogador(i + 1, null, bots[r.Next(20)] + "........", true);
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
        private static void Print(string txt, ConsoleColor foreground, ConsoleColor background)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(txt);
            Console.ForegroundColor = default;
            Console.BackgroundColor = default;
        }
        public static void PrintBk(string txt, ConsoleColor cor)
        {

            Console.BackgroundColor = cor;
            Console.Write(txt);
            Console.BackgroundColor = default;
        }
        public static void DesenhaSetas()
        {
            Console.WriteLine();
            PrintBk(" <-- 4   ", ConsoleColor.DarkGreen);
            Console.Write("   5   ");
            PrintBk(" 6 -->   ", ConsoleColor.DarkGreen);
        }


        public static void ImprimeElemento(string elemento, Cor cor)
        {
            if (cor == Cor.vermelha)
            {
                Print(elemento, ConsoleColor.Red);
            }
            else
            {
                Print(elemento, ConsoleColor.DarkGray);
            }
        }
        public static void ImprimeGrupoFrame(Grupo grupo)
        {
            
            switch (grupo)
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
        }
        public static void ImprimeCartas(Mao mao)
        {
            foreach (Carta cart in mao.GetListaCartas())
            {
                string txt = cart.Letra.ToString();
                txt = txt + "  ";
                //Se é 10
                if (txt == "10  ")
                {
                    txt = "10 ";
                }
                // Grupo
                
                ImprimeGrupoFrame(cart.Grupo);

                //se esta marcada
                if (mao.Selecao == cart)
                {
                    PrintBk(txt, ConsoleColor.DarkCyan);
                }
                else
                {
                   
                    //Console.Write(txt);
                    //Print(txt, ConsoleColor.Black, ConsoleColor.White);
                    ImprimeElemento(txt, cart.Cor);
                }


            }

            Console.WriteLine("    |");
            //print nipes
            foreach (Carta cart in mao.GetListaCartas())
            {
                string txt = cart.Nipe.ToString();

                
                ImprimeGrupoFrame(cart.Grupo);
                ImprimeElemento(txt, cart.Cor);
            }
            Console.WriteLine("    |");
            /*foreach (Carta cart in mao.GetListaCartas())
            {
                Console.Write("|");
                cart.PrintNipe();
                
            }
            Console.WriteLine("    |");*/
        }
    }
}
