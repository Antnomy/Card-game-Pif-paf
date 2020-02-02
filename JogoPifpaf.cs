using Enuns;
using Pif_paf;
using System;

namespace mesa
{
    class JogoPifpaf
    {
        public Baralho Baralho;
        public Pilha Cemiterio;
        public Mao Mao;
        public Jogador[] Jogadores;
        public Jogador JogadorAtual;
        public int indiceAnterior;
        public JogoPifpaf(int numeroJogadores)
        {
            Baralho = new Baralho(2);
            Cemiterio = new Pilha();
            Jogadores = new Jogador[numeroJogadores];
            indiceAnterior = 0;

            DefinirCartas();
            Baralho.Embaralhar();
            for (int i = 0; i < Jogadores.Length; i++)
            {
                Jogadores[i] = new Jogador(i, new Mao(Baralho, 9));
            }
            JogadorAtual = Jogadores[1];
            Mao = JogadorAtual.Mao;
           
        }
        public void MoverCarta(int origem, int destino)
        {
            Mao.GetListaCartas().Insert(destino - 1, Mao.Descartar(origem));
        }
        public void MudarJogador()
        {
            if (JogadorAtual.Numero == Jogadores.Length - 1)
            {
                indiceAnterior = JogadorAtual.Numero; 
                JogadorAtual = Jogadores[0];
            }
            else
            {
                JogadorAtual = Jogadores[JogadorAtual.Numero + 1];
                indiceAnterior = JogadorAtual.Numero;
            }
        }
        public void DefinirCartas()
        {
            Baralho.AdcCarta(new Carta("A", 10, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("A", 10, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("A", 10, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("A", 10, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("2", 10, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("2", 10, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("2", 10, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("2", 10, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("3", 10, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("3", 10, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("3", 10, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("3", 10, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("4", 10, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("4", 10, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("4", 10, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("4", 10, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("5", 10, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("5", 10, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("5", 10, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("5", 10, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("6", 10, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("6", 10, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("6", 10, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("6", 10, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("7", 10, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("7", 10, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("7", 10, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("7", 10, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("8", 10, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("8", 10, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("8", 10, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("8", 10, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("9", 10, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("9", 10, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("9", 10, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("9", 10, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("10", 10, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("10", 10, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("10", 10, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("10", 10, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("Q", 10, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("Q", 10, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("Q", 10, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("Q", 10, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("J", 10, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("J", 10, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("J", 10, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("J", 10, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("K", 10, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("K", 10, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("K", 10, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("K", 10, Nipe.Pau, Cor.preta));

        }

    }
}
