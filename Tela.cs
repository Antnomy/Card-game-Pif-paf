using System;
using System.Collections.Generic;
using mesa;
using Enuns;

namespace Pif_paf
{
    class Tela
    {

        public static int qntCemiterio;

        public static void WriteLineSet(int recuo)
        {
            if (Console.CursorLeft >= recuo)
            {
                Console.CursorTop++;
                Console.CursorLeft -= recuo;
            }
            else
            {
                Console.CursorLeft = 0;
                Console.CursorTop++;
            }
        }
        public static void Linha(int tamanho)
        {
            Console.Write("   ");
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
            Console.Write("  ");
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("|?  ");
            }
            Console.WriteLine("    |");
        }
        public static void Posicoes(int tamanho)
        {
            Console.Write("  |");
            for (int i = 1; i <= tamanho; i++)
            {
                Console.Write($" {i}  ");
            }
            Console.WriteLine("   |");
        }
        public static void Deck(ConsoleColor cor)
        {
            Print("+-------+", cor);
            WriteLineSet(9);
            Print("| <( )> |", cor);
            WriteLineSet(9);
            Print("| << >> |", cor);
            WriteLineSet(9);
            Print("| << >> |", cor);
            WriteLineSet(9);
            Print("| <( )> |", cor);
            WriteLineSet(9);
            Print("+-------+", cor);
            Console.WriteLine();
        }

        public static void ImprimeMao(Mao mao, bool visibilidade)
        {
            Linha(mao.QntCartas());
            if (mao.Visibilidade == true && visibilidade == true)
            {
                ImprimeCartas2(mao.Cartas, mao.Selecao);
            }
            else
            {
                Costas(mao.QntCartas());
                Costas(mao.QntCartas());
            }
            //Corpo(mao.QntCartas());
            // Corpo(mao.QntCartas());
            Linha(mao.QntCartas());
            Posicoes(mao.QntCartas());
            Linha(mao.QntCartas());

        }
        private static string ListaPlayers(Jogador[] jogadores)
        {
            string aux = "";
            string pl;

            for (int i = 1; i < jogadores.Length; i++)
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
        private static void ListaPlayers2(Jogador[] jogadores)
        {

            string pl;

            for (int i = 1; i < jogadores.Length; i++)
            {
                pl = jogadores[i].Nome;
                if (pl.Length > 8)
                {
                    pl = pl.Remove(8);
                }
                Console.Write(pl);
                Console.Write("     ");

            }

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

                for (int i = 1; i < jogadores.Length; i++)
                {
                    if (setNumero)
                    {
                        Console.Write($"|  {i + 1}  |");
                        if(jogadorAtual == jogadores[i])
                        {
                            Print(" <<   ", ConsoleColor.Green);
                        }
                        else
                        {
                            Console.Write("      ");
                        }
                        /*Console.Write("|");
                        PrintSelecao($"  {i + 1}  ", ConsoleColor.Gray);
                        Console.Write("|  ");*/
                    }
                    else
                    {
                        Console.Write(parte + "      ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("    ");
            Body(" _(_)_ ", false);
            Console.Write("    ");
            Body("|     |", true);
            Console.Write("    ");
            Body("-------", false);

            

            Console.Write("    ");
            ListaPlayers2(jogadores);

            Console.WriteLine();
            Console.Write("    ");
            for (int i = 1; i < jogadores.Length; i++)
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
            if (jogo.JogadorAtual.Numero != 1)
            {
                Player(jogo.JogadorAtual.Numero - 1, jogo, true);
            }
            else
            {
                Player(jogo.JogadorAtual.Numero, jogo, true);
            }

            /*Avatares(jogo.Jogadores, jogo.JogadorAtual, jogo.fase);*/
            Console.WriteLine();
            qntCemiterio = jogo.Cemiterio.QntCartas();


            //Console.WriteLine("    Cemiterio - " + qntCemiterio + "            Maço - " + jogo.Baralho.QntCartas() + $"     Turno({jogo.Turno})");
            
            if (qntCemiterio > 0)
            {
                Console.WriteLine("    +-------+");
                Console.Write("    ");

                ImpCarta(jogo.Cemiterio.Top(), false, false);
                Console.Write("    ");
                Console.CursorTop -= 4;

                Console.Write("    |");
                WriteLineSet(1);
                Console.Write("|");
                WriteLineSet(1);
                Console.Write("|");
                WriteLineSet(1);
                Console.Write("|");
                WriteLineSet(1);
                Console.CursorLeft = 4;
                Console.WriteLine("+-------+");
              
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            }
            Console.Write("                            ");
            Console.CursorTop -= 6;
            Deck(ConsoleColor.Blue);
            
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("   ");
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
            Console.Write("  ");
            Print(">>", ConsoleColor.Yellow);
            Console.Write(" " + txt);
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
            jogadores[0] = new Jogador(1, null, nome + "........", false);
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
                Console.Write("  Pressione (Enter) para comprar uma carta: ");
                Console.ReadLine();
                return baralho.RemoveTop();
            }
            else
            {
                Console.Write("  !Comprar do Maço ou Cemiterio (m, c)?: ");
                char c = char.Parse(Console.ReadLine());

                if (c != 'm' && c != 'c')
                {
                    throw new PifpafExeption("  Erro! Digite: (m) ou (c)");
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
        public static void ImprimeGrupo(Grupo grupo)
        {

            switch (grupo)
            {
                case Grupo.Trincas:
                    Print("*", ConsoleColor.Green);
                    break;
                case Grupo.Sequencias:
                    Print("*", ConsoleColor.Blue);
                    break;
                case Grupo.Pares:
                    Print("*", ConsoleColor.Yellow);
                    break;
                default:
                    Console.Write("*");
                    break;
            }
        }
        public static void ImpCarta(Carta carta, bool verso, bool selecionada)
        {
            string letra;
            string nipe;

            if (verso)
            {
                letra = " <(";
                nipe = " <<";
            }
            else
            {
                letra = carta.Letra.ToString();
                nipe = carta.Nipe.ToString();
                letra = letra + "  ";
                
            }
            //Se é 10
            if (letra == "10  ")
            {
                letra = "10 ";
            }

            Console.Write("|");
            if (selecionada)
            {
                PrintBk(letra, ConsoleColor.Blue);
            }
            else
            {
                ImprimeElemento(letra, carta.Cor);
            }
            WriteLineSet(4);
            Console.Write("|"); 
            ImprimeElemento(nipe, carta.Cor);
            WriteLineSet(4);

            Console.Write("|");
            Console.Write("   ");
            WriteLineSet(4);

            Console.Write("|");
            Console.Write("   ");
            WriteLineSet(4);

        }
        public static void ImprimeCartas(Mao mao)
        {
            //espaço para deslocar tela
            Console.Write("  ");

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

            //espaço para deslocar tela
            Console.Write("  ");
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
        public static void ImprimeCartas2(List<Carta> cartas, Carta cartaSelecionada)
        {
            bool selecao;
            Console.Write("  ");
            foreach (Carta item in cartas)
            {
                if (cartaSelecionada == item)
                {
                    selecao = true;
                }
                else
                {
                    selecao = false;
                }
                Console.Write("  ");
                ImprimeGrupo(item.Grupo);
                WriteLineSet(3);
                ImpCarta(item, false, selecao);
                Console.Write("    ");
                Console.CursorTop -= 5;
                
            }
            Console.CursorTop++;
            Console.Write("    |");
            WriteLineSet(1);
            Console.Write("|");
            WriteLineSet(1);
            Console.Write("|");
            WriteLineSet(1);
            Console.Write("|");
            //WriteLineSet(1);

            Console.WriteLine();
            //Console.CursorTop += 4;
        }

    }
}
