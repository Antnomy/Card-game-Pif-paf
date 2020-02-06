﻿using Enuns;
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
            Baralho = new Baralho();
            Cemiterio = new Pilha();
            Jogadores = new Jogador[numeroJogadores];
            indiceAnterior = 0;

            DefinirCartas();
            //Baralho.Embaralhar();
            Jogadores[0] = new Ai(0, new Mao(Baralho, 9), Baralho, Cemiterio);
            Jogadores[1] = new Jogador(1, new Mao(Baralho, 9));

            JogadorAtual = Jogadores[1];
            Mao = JogadorAtual.Mao;
           
        }
        public void MoverCarta(int origem, int destino)
        {
            Mao.GetListaCartas().Insert(destino - 1, Mao.Descartar(origem));
        }
        public void MudarJogador()
        {
            if (JogadorAtual.Numero == 1)
            {
                indiceAnterior = JogadorAtual.Numero; 
                JogadorAtual = Jogadores[0];
            }
            else
            {
                JogadorAtual = Jogadores[1];
                indiceAnterior = JogadorAtual.Numero;
            }
        }
        public void DefinirCartas()
        {
            Baralho.AdcCarta(new Carta("A", 10, 1, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("A", 10, 1, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("A", 10, 1, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("A", 10, 1, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("2", 10, 2, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("2", 10, 2, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("2", 10, 2, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("2", 10, 2, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("3", 10, 3, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("3", 10, 3, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("3", 10, 3, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("3", 10, 3, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("4", 10, 4, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("4", 10, 4, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("4", 10, 4, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("4", 10, 4, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("5", 10, 5, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("5", 10, 5, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("5", 10, 5, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("5", 10, 5, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("6", 10, 6, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("6", 10, 6, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("6", 10, 6, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("6", 10, 6, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("6", 10, 6, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("7", 10, 7, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("7", 10, 7, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("7", 10, 7, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("7", 10, 7, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("8", 10, 8, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("8", 10, 8, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("8", 10, 8, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("8", 10, 8, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("8", 10, 8, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("9", 10, 9, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("9", 10, 9, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("9", 10, 9, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("9", 10, 9, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("10", 10, 10, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("10", 10, 10, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("10", 10, 10, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("10", 10, 10, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("J", 10, 11, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("J", 10, 11, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("J", 10, 11, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("J", 10, 11, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("Q", 10, 12, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("Q", 10, 12, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("Q", 10, 12, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("Q", 10, 12, Nipe.Pau, Cor.preta));           
            Baralho.AdcCarta(new Carta("K", 10, 13, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("K", 10, 13, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("K", 10, 13, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("K", 10, 13, Nipe.Pau, Cor.preta));

        }

    }
}
