using System;
using System.Collections.Generic;
using mesa;
using Enuns;

namespace Pif_paf
{
    class Tela
    {

        public static int qntCemiterio;

        public static ConsoleKey LerTecla()
        {
            ConsoleKeyInfo tecla;
            tecla = Console.ReadKey(true);
            return tecla.Key;
        }
        public static void Dicas()
        {
            Console.Write("Inf:");
            WriteLineSet(6);
            Print("&", ConsoleColor.DarkYellow);
            Console.Write(" - pares");
            WriteLineSet(9);
            Print("&", ConsoleColor.DarkGreen);
            Console.Write(" - trincas");
            WriteLineSet(11);
            Print("&", ConsoleColor.DarkMagenta);
            Console.Write(" - Sequencias");
            WriteLineSet(14);            
        }

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
            Console.Write("  +-");
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("----");
            }
            Console.WriteLine("--+");
        }
       
        
        public static void Posicoes(int tamanho, int posicaoSelecionada)
        {
            
            Console.Write("  |");
            for (int i = 1; i <= tamanho; i++)
            {
                if(i == posicaoSelecionada + 1)
                {
                    PrintBk($" {i} ", ConsoleColor.Blue);
                    Console.Write(" ");
                }
                else
                {
                    Console.Write($" {i}  ");
                }
                
            }
            Console.WriteLine("   |");
            Linha(tamanho);

        }
        public static void Deck(ConsoleColor cor)
        {
            //Print("+-------+", cor);
            Console.Write("+-------+");
            WriteLineSet(10);
            Console.Write("|");
            Print(" <( )> ", cor);
            Console.Write("||");
            WriteLineSet(10);
            Console.Write("|");
            Print(" << >> ", cor);
            Console.Write("||");
            WriteLineSet(10);
            Console.Write("|");
            Print(" << >> ", cor);
            Console.Write("||");
            WriteLineSet(10);
            Console.Write("|");
            Print(" <( )> ", cor);
            Console.Write("||");
            WriteLineSet(10);
            Console.Write("+-------+");

        }

        public static void ImprimeMao(Mao mao, bool verso, bool posicoes)
        {
            Linha(mao.QntCartas());
            if (mao.Visibilidade == true && verso == true)
            {
                ImprimeCartas(mao.Cartas, mao.Selecao, true);
            }
            else
            {
                ImprimeCartas(mao.Cartas, mao.Selecao, false);
            }

            
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
        public static void Player(int indice, JogoPifpaf jogo, bool mostrarInf, bool verso)
        {
            Mao mao = jogo.Jogadores[indice].Mao;

            if (jogo.JogadorAtual.Equals(jogo.Jogadores[indice]))
            {
                Console.Write(jogo.Jogadores[indice].Numero + "- ");
                Console.Write(jogo.Jogadores[indice].Nome);
                Print(" << Vez...     ", ConsoleColor.DarkCyan);
            }
            else
            {
                Console.Write(jogo.Jogadores[indice].Numero + "- " + jogo.Jogadores[indice].Nome + "           ");
            }

            //trincas e sequencias
            if (mostrarInf)
            {
                Console.Write("T " + jogo.Jogadores[indice].Mao.Trincas + " - S " + jogo.Jogadores[indice].Mao.Sequencias);
            }
            Console.WriteLine();
            Linha(jogo.Jogadores[indice].Mao.QntCartas());

            //grupos
            if (mostrarInf)
            {
                Console.Write("    ");
                foreach (var carta in mao.Cartas)
                {

                    ImprimeGrupo(carta.Grupo);
                    Console.Write("   ");
                }
                Console.WriteLine();
            }

            if ( verso)
            {

                ImprimeCartas(mao.Cartas, mao.Selecao, true);
            }
            else
            {
                ImprimeCartas(mao.Cartas, mao.Selecao, false);
            }
            Linha(jogo.Jogadores[indice].Mao.QntCartas());

            //posicoes
            if (mostrarInf)
            {
                int indiceSelecionado = jogo.Jogadores[indice].Mao.selec;
                Posicoes(jogo.Jogadores[indice].Mao.QntCartas(), indiceSelecionado);
            }
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
                            Print(" <<   ", ConsoleColor.DarkCyan);
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
            if (jogo.Jogadores.Length > 2)
            {
                Avatares(jogo.Jogadores, jogo.JogadorAtual, jogo.fase); 
            }
            else {
                int indice = jogo.JogadorAtual.Numero;
                if (indice != 1)
                {
                    Player(indice - 1, jogo, false, false);
                }
                else
                {
                    Player(jogo.JogadorAtual.Numero, jogo, false, false);
                }
            }
            
            Console.WriteLine();
            qntCemiterio = jogo.Cemiterio.QntCartas();


            Console.WriteLine("    Cemiterio - " + qntCemiterio + "            Maço - " + jogo.Baralho.QntCartas() + $"        Turno({jogo.Turno})");
            
            if (qntCemiterio > 0)
            {
                //Console.WriteLine();
                Console.Write("    ");

                ImpCarta(jogo.Cemiterio.Top(), false, ConsoleColor.DarkRed, false);
                Console.Write("   ");
                Console.CursorTop -= 5;
                Console.Write("-----+");
                WriteLineSet(4);
                Console.Write("   |");
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
            Console.Write("                             ");
            Console.CursorTop -= 6;
            Deck(ConsoleColor.DarkRed);
            Console.Write("     ");
            Console.CursorTop-= 4;

            Console.Write("      ");
            Dicas();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("   ");
            Player(0, jogo, true, false);

            //posicoes
           
        }
        public static void Resultado(JogoPifpaf jogo)
        {
            Console.Clear();


            Print("_______________________________________________________________________", ConsoleColor.DarkGreen);
            Console.WriteLine(">>> FIM DE JOGO! " + jogo.JogadorAnterior().Nome + " BATEU!!...");
            Console.WriteLine(jogo.JogadorAnterior().Mao.Trincas + " Trincas(s), " + jogo.JogadorAnterior().Mao.Sequencias + " Sequencia(s)");
            Console.WriteLine();
            int indiceVencedor = jogo.JogadorAnterior().Numero - 1;
            Player(indiceVencedor, jogo, false, false);
            Print("_______________________________________________________________________", ConsoleColor.DarkGreen);
            Console.WriteLine();
            Console.WriteLine("Jogadores...");
            Console.WriteLine();
            for (int i = 0; i < jogo.Jogadores.Length; i++)
            {
                if (i != indiceVencedor)
                {
                    Console.WriteLine("  " + jogo.Jogadores[i].Nome);
                    ImprimeCartas(jogo.Jogadores[i].Mao.Cartas, null, false);
                    //Player(i, jogo, false, false);
                }
            }  
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
            ConsoleKey t = LerTecla();

            if (t != ConsoleKey.Enter && t != ConsoleKey.Decimal && t != ConsoleKey.Delete)
            {
                throw new PifpafExeption("Erro! Digite somente uma das opções acima...ENTER para continuar:");
            }
            if (t == ConsoleKey.Enter)
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
                    throw new PifpafExeption("  Erro! Digite: (m) ou (c) e de Enter.");
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
                Print(elemento, ConsoleColor.DarkRed);
            }
            else if(cor == Cor.preta)
            {
                Print(elemento, ConsoleColor.DarkGray);
            }
        }
        
        public static void ImprimeGrupo(Grupo grupo)
        {

            switch (grupo)
            {
                case Grupo.Trincas:
                    Print("&", ConsoleColor.DarkGreen);
                    break;
                case Grupo.Sequencias:
                    Print("&", ConsoleColor.DarkMagenta);
                    break;
                case Grupo.Pares:
                    Print("&", ConsoleColor.DarkYellow);
                    break;
                default:
                    Console.Write("&");
                    break;
            }
        }
        public static void ImpCarta(Carta carta, bool verso, ConsoleColor corVerso, bool selecionada)
        {
            string letra;
            string nipe;

            Console.Write("+---");
            WriteLineSet(4);
            Console.Write("|");

            if (verso)
            {

                Print(" <(", corVerso);
                WriteLineSet(4);
                Console.Write("|");
                Print(" <<", corVerso);
                WriteLineSet(4);


                Console.Write("|");
                Print(" <<", corVerso);
                WriteLineSet(4);

                Console.Write("|");
                Print(" <(", corVerso);
                WriteLineSet(4);
            }
            else
            {
                letra = carta.Letra.ToString();
                nipe = carta.Nipe.ToString();
                letra = letra + "  ";

                //Se é 10
                if (letra == "10  ")
                {
                    letra = "10 ";
                }
                
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

                Console.Write("|   ");
                WriteLineSet(4);

                Console.Write("|   ");
                WriteLineSet(4);

            }
            

        }
        
        public static void ImprimeCartas(List<Carta> cartas, Carta cartaSelecionada, bool verso)
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
                ImpCarta(item, verso, ConsoleColor.DarkRed, selecao);
                Console.Write("    ");
                Console.CursorTop -= 5;               
            }
            //carta do final
            if (verso)
            {
                Console.Write("----+");
                WriteLineSet(5);
                Print(" )> ", ConsoleColor.DarkRed);
                Console.Write("|");
                WriteLineSet(5);
                Print(" >> ", ConsoleColor.DarkRed);
                Console.Write("|");
                WriteLineSet(5);
                Print(" >> ", ConsoleColor.DarkRed);
                Console.Write("|");
                WriteLineSet(5);
                Print(" )> ", ConsoleColor.DarkRed);
                Console.Write("|");
                Console.WriteLine();
            }
            else
            {
                Console.Write("----+");
                WriteLineSet(5);
                Console.Write("    |");
                WriteLineSet(1);
                Console.Write("|");
                WriteLineSet(1);
                Console.Write("|");
                WriteLineSet(1);
                Console.Write("|");
                Console.WriteLine();
            }
        }

    }
}
