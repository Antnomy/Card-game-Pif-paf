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
        public static void WriteLineSet(int recuo, string txt)
        {
            Console.Write(txt);
            WriteLineSet(recuo);
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
        public static void Dicas()
        {
            WriteLineSet(6, "Inf:");
            Print("●", ConsoleColor.DarkYellow);
            WriteLineSet(9, " - pares");
            Print("●", ConsoleColor.DarkGreen);
            WriteLineSet(11, " - trincas");
            Print("●", ConsoleColor.DarkMagenta);
            WriteLineSet(14, " - Sequencias");
        }
        public static void Linha(int tamanho)
        {
            Console.Write("  -");
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("----");
            }
            Console.WriteLine("----");
        }
        public static int EntrarPosicao()
        {
            string p = Console.ReadLine();
            if (p == "t")
            {
                return -1;
            }
            return int.Parse(p);
        }
        public static void Posicoes(int tamanho, int posicaoSelecionada)
        {
            
            Console.Write("  |");
            for (int i = 1; i <= tamanho; i++)
            {
                if (i == posicaoSelecionada + 1)
                {
                    PrintBk($" {i} ", ConsoleColor.DarkCyan);
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
       
        public static void Verso(ConsoleColor cor)
        {
           
            WriteLineSet(9, "+-------+");
            Console.Write("|");
            Print(" <( )> ", cor);
            
            WriteLineSet(10, "||");
            Console.Write("|");
            Print(" << >> ", cor);
            
            WriteLineSet(10, "||");
            Console.Write("|");
            Print(" << >> ", cor);
          
            WriteLineSet(10, "||");
            Console.Write("|");
            Print(" <( )> ", cor);
          
            WriteLineSet(10, "||");
            Console.Write("+-------+");

        }
       
        public static void ImprimeMao(Mao mao, bool verso, bool posicoes)
        {
            Linha(mao.QntCartas());
            if (mao.Visibilidade == true && verso == true)
            {
                ImprimeCartas(mao.Cartas, true);
            }
            else
            {
                ImprimeCartas(mao.Cartas, false);
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
                Console.WriteLine("   ");
            }

            if (verso)
            {

                ImprimeCartas(mao.Cartas, true);
            }
            else
            {
                ImprimeCartas(mao.Cartas, false);
            }
           

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
                    Console.Write(" * *  ");
                    break;
                case Fase.movimentacao:
                    Console.Write("* ");
                    Print("*", ConsoleColor.Green);
                    Console.Write(" *  ");
                    break;
                case Fase.descarte:
                    Console.Write("* * ");
                    Print("*  ", ConsoleColor.Green);
                    //Console.Write("*");
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
                        if (jogadorAtual == jogadores[i])
                        {
                            Print(" <<   ", ConsoleColor.DarkCyan);
                        }
                        else
                        {
                            Console.Write("      ");
                        }                      
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
            Console.WriteLine();
        }

        public static void ImprimeMesa(JogoPifpaf jogo)
        {
            Console.Clear();
            if (jogo.Jogadores.Length > 2)
            {
                Avatares(jogo.Jogadores, jogo.JogadorAtual, jogo.fase);
            }
            else
            {
                int indice = jogo.JogadorAtual.Numero;

                Console.Write("   ");
                if (indice != 1)
                {
                    Player(indice - 1, jogo, !jogo.Visibilidade, jogo.Visibilidade);
                }
                else
                {
                    Player(jogo.JogadorAtual.Numero, jogo, !jogo.Visibilidade, jogo.Visibilidade);
                }
            }

            Console.WriteLine();
            qntCemiterio = jogo.Cemiterio.QntCartas();


            Console.WriteLine("    Cemiterio - " + qntCemiterio + "            Maço - " + jogo.Baralho.QntCartas() + $"        Turno({jogo.Turno})");

            if (qntCemiterio > 0)
            {
                Console.Write("     ");

                ImpCarta(jogo.Cemiterio.Top(), false, ConsoleColor.DarkRed);
                Console.Write("");
                Console.CursorTop -= 5;
                Console.Write("----+");
                WriteLineSet(1);
                Console.Write("|");
                WriteLineSet(1);
                Console.Write("|");
                WriteLineSet(1);
                Console.Write("|");
                WriteLineSet(1);
                Console.Write("|");
                WriteLineSet(5);               
                Console.WriteLine("----+");

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
            Verso(ConsoleColor.DarkRed);
            Console.Write("     ");
            Console.CursorTop -= 4;

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


            Print("______________________________________________", ConsoleColor.DarkGreen);
            Console.WriteLine();
            Console.WriteLine(">> FIM DE JOGO!<< ");
            Console.Write("  ");
            Print(jogo.JogadorAnterior().Nome + "BATEU!!", ConsoleColor.DarkGreen);
            Console.WriteLine(" " + jogo.JogadorAnterior().Mao.Trincas + " Trincas(s), " + jogo.JogadorAnterior().Mao.Sequencias + " Sequencia(s)");
            Console.WriteLine();
            int indiceVencedor = jogo.JogadorAnterior().Numero - 1;
            ImprimeCartas(jogo.Jogadores[indiceVencedor].Mao.Cartas, false);
            Print("_______________________________________________", ConsoleColor.DarkGreen);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Jogadores...");
            Console.WriteLine();
            for (int i = 0; i < jogo.Jogadores.Length; i++)
            {
                if (i != indiceVencedor)
                {
                    Console.WriteLine("  " + jogo.Jogadores[i].Nome);
                    ImprimeCartas(jogo.Jogadores[i].Mao.Cartas, false);
                    //Player(i, jogo, false, false);
                }
            }
        }
       

        
        public static bool Confirmar(string txt)
        {
            Console.Write("  ");
            //Print(">>", ConsoleColor.Yellow);
            Console.Write(">> " + txt);
            string t = Console.ReadLine();

            if (t != "s" && t != "n" && t != "")
            {
                throw new PifpafExeption("   Digite somente uma das opções acima...ENTER para repetir:");
            }
            if (t == "s" || t == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int Inicio()
        {
            int n = 0; ;
            bool sucesso = false;
            while (!sucesso)
            {
                try
                {
                    Console.WriteLine("   Jogo de Cartas Pifpaf ♥ ♣ ♠ ♦ ₢");
                    Console.WriteLine();
                    Console.Write("Informe o numero de jogadores max 8 (Enter): ");
                    n = int.Parse(Console.ReadLine());
                    
                    if (n < 2 || n > 8)
                    {
                        //throw new PifpafExeption("!!..Digite um numero entre 2 e 8");
                        n = 2;
                    }
                    sucesso = true;
                }
                catch (SystemException)
                {
                    Console.WriteLine();
                    Print("Digite um numero!... Enter tente novamente.", ConsoleColor.DarkRed);
                    
                    Console.ReadLine();
                    Console.Clear();
                }              
            }          
            return n;
        }
        
        public static bool SeleCompra()
        {
            if (qntCemiterio == 0)
            {
                Console.Write("  * Pressione (Enter) para comprar uma carta: ");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.Write("  * !Comprar do Maço ou Cemiterio (m, c)?: ");
                string c = Console.ReadLine();

                if (c != "m" && c != "c" && c != "")
                {
                    throw new PifpafExeption("  Digite: (m) ou (c) e de Enter.");
                }
                if (c == "m" || c == "")
                {
                    return true;
                }
                else
                {
                    return false;
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
            PrintBk(" <--     ", ConsoleColor.DarkGreen);
            Console.Write("       ");
            PrintBk("   -->   ", ConsoleColor.DarkGreen);
        }


        public static void ImprimeElemento(string elemento, Cor cor)
        {
            if (cor == Cor.vermelha)
            {
                Print(elemento, ConsoleColor.DarkRed);
            }
            else if (cor == Cor.preta)
            {
                Print(elemento, ConsoleColor.DarkGray);
            }
        }

        public static void ImprimeGrupo(Grupo grupo)
        {

            switch (grupo)
            {
                case Grupo.Trincas:
                    Print("●", ConsoleColor.DarkGreen);
                    break;
                case Grupo.Sequencias:
                    Print("●", ConsoleColor.DarkMagenta);
                    break;
                case Grupo.Pares:
                    Print("●", ConsoleColor.DarkYellow);
                    break;
                default:
                    Print("●", ConsoleColor.DarkGray);
                    break;
            }
        }
        public static void ImpCarta(Carta carta, bool verso, ConsoleColor corVerso)
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
                Console.Write("+---");
            }
            else
            {
                letra = carta.Letra;
                nipe = carta.ToStringNipe();
                letra = letra + "  ";
                //Se é 10
                if (letra == "10  ")
                {
                    letra = "10 ";
                }
                ImprimeElemento(letra, carta.Cor);
                WriteLineSet(4);
                Console.Write("|");
                ImprimeElemento(nipe, carta.Cor);
                WriteLineSet(4);
                Console.Write("|   ");
                WriteLineSet(4);
                Console.Write("|   ");
                WriteLineSet(4);
                Console.Write("+---");
               
            }
        }

        public static void ImpCarta2(Carta carta, bool tamCompleto, bool verso, ConsoleColor corVerso)
        {
            string letra;
            string nipe;
                           
            if (verso)
            {
                string[] partes = { "+-------+", " <( )> ", " << >> ", " << >> ", " <( )> ", "+-------+" };
                string[] partes2 = { "+---", " <( ", " <<", " <<", " <(", "+---" };
                string[] corpo = partes;

                if (!tamCompleto)
                {
                    corpo = partes2;
                }
                Console.Write(corpo[0]);
                WriteLineSet(9);
                

                for (int i = 1; i < 5; i++)
                {
                    Console.Write("|");
                    Print(corpo[i], corVerso);
                    Console.Write("|");
                    WriteLineSet(10);
                    
                }
                Console.Write(corpo[5]);


            }
            else
            {
                letra = carta.Letra;
                nipe = carta.ToStringNipe();
                letra = letra + "  ";
                //Se é 10
                if (letra == "10  ")
                {
                    letra = "10 ";
                }
                Console.Write("+---");
                WriteLineSet(4);
                Console.Write("|");                
                ImprimeElemento(letra, carta.Cor);
                WriteLineSet(4);
                Console.Write("|");
                ImprimeElemento(nipe, carta.Cor);
                WriteLineSet(4);
                Console.Write("|   ");
                WriteLineSet(4);
                Console.Write("|   ");
                WriteLineSet(4);
                Console.Write("+---");
                
            }
        }
        public static void ImprimeCartas(List<Carta> cartas, bool verso)
        {
            Console.Write("  ");
            foreach (Carta item in cartas)
            {
                ImpCarta(item, verso, ConsoleColor.DarkRed);
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
                WriteLineSet(5);
                Console.WriteLine("----+");
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
                WriteLineSet(5);
                Console.WriteLine("----+");
            }
        }

    }
}
