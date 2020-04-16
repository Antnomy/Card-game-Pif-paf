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
        public Ai Ai;
        public bool FimJogo { get; set; }
        public int Turno;
        public Jogador[] Jogadores;
        public Jogador JogadorAtual;
        public Fase fase;

        public JogoPifpaf(Jogador[] jogadores)
        {
            Baralho = new Baralho();
            Cemiterio = new Pilha();
            Ai = new Ai(Baralho, Cemiterio, null);

            Turno = 1;
            Jogadores = jogadores;
            fase = Fase.compra;
            FimJogo = false;

            DefinirCartas();
            //Baralho.Embaralhar();
            //Baralho.Embaralhar();

            for (int i = 0; i < Jogadores.Length; i++)
            {
                Jogadores[i].Mao = new Mao(Baralho, 9);
            }
            JogadorAtual = Jogadores[0];
        }
        public void DarCartas()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < Jogadores.Length; j++)
                {
                    Jogadores[j].Mao.AdcCarta(Baralho.RemoveTop());
                }
            }
        }

        public void MudarJogador()
        {
            int i = JogadorAtual.Numero;

            if (i < Jogadores.Length)
            {
                JogadorAtual = Jogadores[i];
                Mao = JogadorAtual.Mao;
                Turno++;
            }
            else
            {
                JogadorAtual = Jogadores[0];
                Mao = JogadorAtual.Mao;
                Turno++;
            }
        }
        public Jogador JogadorAnterior()
        {
            if (JogadorAtual.Numero == 1)
            {
                return Jogadores[Jogadores.Length - 1];
            }
            return Jogadores[JogadorAtual.Numero - 2];
        }
        public void VerifTodosJogos()
        {
            Mao.DesMarcar();
            Mao.RemoveGrupos();
            Mao.VerifTrincas();
            Mao.VerifSequencias();
        }
       
        public bool VerifSeBateu()
        {
            if (JogadorAnterior().Mao.TotalArranjos() == 3)
            {
                return true;
            }
            return false;
        }
        public void AdcCemiterioParaBaralho()
        {
            Baralho.Cartas.AddRange(Cemiterio.Cartas);
            Cemiterio.Cartas.Clear();
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
            Baralho.AdcCarta(new Carta("K", 10, 13, Nipe.Esp, Cor.preta));

            Baralho.AdcCarta(new Carta("Q", 10, 12, Nipe.Pau, Cor.preta));
            //cartas texte
            //Carta c1 = new Carta("2", 10, 2, Nipe.Cop, Cor.vermelha);
            Baralho.AdcCarta(new Carta("J", 10, 11, Nipe.Esp, Cor.preta));
            //Baralho.AdcCarta(new Carta("A", 10, 1, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("Q", 10, 12, Nipe.Esp, Cor.preta));

            Baralho.AdcCarta(new Carta("K", 10, 13, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("3", 10, 3, Nipe.Cop, Cor.vermelha));
            //Baralho.AdcCarta(new Carta("A", 10, 1, Nipe.Esp, Cor.preta));
            //Baralho.AdcCarta(new Carta("K", 10, 13, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("A", 10, 1, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("Q", 10, 12, Nipe.Esp, Cor.preta));

            Baralho.AdcCarta(new Carta("K", 10, 13, Nipe.Esp, Cor.preta));
            //Baralho.AdcCarta(new Carta("7", 10, 7, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("4", 10, 4, Nipe.Cop, Cor.vermelha));
            //Baralho.AdcCarta(new Carta("K", 10, 13, Nipe.Pau, Cor.preta));
            //Baralho.AdcCarta(new Carta("2", 10, 2, Nipe.Esp, Cor.preta));
            //Baralho.AdcCarta(new Carta("K", 10, 13, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("A", 10, 1, Nipe.Our, Cor.vermelha));

            //Baralho.AdcCarta(new Carta("2", 10, 2, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("3", 10, 3, Nipe.Esp, Cor.preta));





            //Baralho.AdcCarta(new Carta("2", 10, 2, Nipe.Cop, Cor.vermelha));

            //Baralho.AdcCarta(new Carta("A", 10, 1, Nipe.Cop, Cor.vermelha));


            //posi 0

            Baralho.AdcCarta(new Carta("Q", 10, 12, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("Q", 10, 12, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("K", 10, 13, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("K", 10, 13, Nipe.Esp, Cor.preta));
            Baralho.AdcCarta(new Carta("K", 10, 13, Nipe.Our, Cor.vermelha));
            Baralho.AdcCarta(new Carta("K", 10, 13, Nipe.Pau, Cor.preta));
            Baralho.AdcCarta(new Carta("3", 10, 3, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("2", 10, 2, Nipe.Cop, Cor.vermelha));
            Baralho.AdcCarta(new Carta("A", 10, 1, Nipe.Cop, Cor.vermelha));






        }

    }
}
