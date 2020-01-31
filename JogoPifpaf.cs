using System;
using Enuns;

namespace mesa
{
    class JogoPifpaf
    {
        public Baralho Baralho;
        public Pilha Cemiterio;
        public Mao Mao;
        int JogadorAtual;
        public JogoPifpaf()
        {
            Baralho = new Baralho(52);
            Cemiterio = new Pilha();  
            
            DefinirCartas();
            Baralho.Embaralhar();
            Mao = new Mao(Baralho, 9);
        }
        public void MoverCarta(int origem, int destino)
        {
            Mao.GetListaCartas().Insert(destino - 1, Mao.Descartar(origem));
        }
        public void DefinirCartas()
        {
            Baralho.AdcCarta(new Carta("A", 10, Nipe.Copas, Cor.preta));
            Baralho.AdcCarta(new Carta("A", 10, Nipe.Espadas, Cor.preta));
            Baralho.AdcCarta(new Carta("A", 10, Nipe.Ouros, Cor.preta));
            Baralho.AdcCarta(new Carta("A", 10, Nipe.Paus, Cor.preta));
            Baralho.AdcCarta(new Carta("2", 10, Nipe.Copas, Cor.preta));
            Baralho.AdcCarta(new Carta("2", 10, Nipe.Espadas, Cor.preta));
            Baralho.AdcCarta(new Carta("2", 10, Nipe.Ouros, Cor.preta));
            Baralho.AdcCarta(new Carta("2", 10, Nipe.Paus, Cor.preta));
            Baralho.AdcCarta(new Carta("3", 10, Nipe.Copas, Cor.preta));
            Baralho.AdcCarta(new Carta("3", 10, Nipe.Espadas, Cor.preta));
            Baralho.AdcCarta(new Carta("3", 10, Nipe.Ouros, Cor.preta));
            Baralho.AdcCarta(new Carta("3", 10, Nipe.Paus, Cor.preta));
            Baralho.AdcCarta(new Carta("4", 10, Nipe.Copas, Cor.preta));
            Baralho.AdcCarta(new Carta("4", 10, Nipe.Espadas, Cor.preta));
            Baralho.AdcCarta(new Carta("4", 10, Nipe.Ouros, Cor.preta));
            Baralho.AdcCarta(new Carta("4", 10, Nipe.Paus, Cor.preta));
            Baralho.AdcCarta(new Carta("5", 10, Nipe.Copas, Cor.preta));
            Baralho.AdcCarta(new Carta("5", 10, Nipe.Espadas, Cor.preta));
            Baralho.AdcCarta(new Carta("5", 10, Nipe.Ouros, Cor.preta));
            Baralho.AdcCarta(new Carta("5", 10, Nipe.Paus, Cor.preta));
            Baralho.AdcCarta(new Carta("6", 10, Nipe.Copas, Cor.preta));
            Baralho.AdcCarta(new Carta("6", 10, Nipe.Espadas, Cor.preta));
            Baralho.AdcCarta(new Carta("6", 10, Nipe.Ouros, Cor.preta));
            Baralho.AdcCarta(new Carta("6", 10, Nipe.Paus, Cor.preta));
            Baralho.AdcCarta(new Carta("7", 10, Nipe.Copas, Cor.preta));
            Baralho.AdcCarta(new Carta("7", 10, Nipe.Espadas, Cor.preta));
            Baralho.AdcCarta(new Carta("7", 10, Nipe.Ouros, Cor.preta));
            Baralho.AdcCarta(new Carta("7", 10, Nipe.Paus, Cor.preta));
            Baralho.AdcCarta(new Carta("8", 10, Nipe.Copas, Cor.preta));
            Baralho.AdcCarta(new Carta("8", 10, Nipe.Espadas, Cor.preta));
            Baralho.AdcCarta(new Carta("8", 10, Nipe.Ouros, Cor.preta));
            Baralho.AdcCarta(new Carta("8", 10, Nipe.Paus, Cor.preta));
            Baralho.AdcCarta(new Carta("9", 10, Nipe.Copas, Cor.preta));
            Baralho.AdcCarta(new Carta("9", 10, Nipe.Espadas, Cor.preta));
            Baralho.AdcCarta(new Carta("9", 10, Nipe.Ouros, Cor.preta));
            Baralho.AdcCarta(new Carta("9", 10, Nipe.Paus, Cor.preta));
            Baralho.AdcCarta(new Carta("10", 10, Nipe.Copas, Cor.preta));
            Baralho.AdcCarta(new Carta("10", 10, Nipe.Espadas, Cor.preta));
            Baralho.AdcCarta(new Carta("10", 10, Nipe.Ouros, Cor.preta));
            Baralho.AdcCarta(new Carta("10", 10, Nipe.Paus, Cor.preta));
            Baralho.AdcCarta(new Carta("Q", 10, Nipe.Copas, Cor.preta));
            Baralho.AdcCarta(new Carta("Q", 10, Nipe.Espadas, Cor.preta));
            Baralho.AdcCarta(new Carta("Q", 10, Nipe.Ouros, Cor.preta));
            Baralho.AdcCarta(new Carta("Q", 10, Nipe.Paus, Cor.preta));
            Baralho.AdcCarta(new Carta("J", 10, Nipe.Copas, Cor.preta));
            Baralho.AdcCarta(new Carta("J", 10, Nipe.Espadas, Cor.preta));
            Baralho.AdcCarta(new Carta("J", 10, Nipe.Ouros, Cor.preta));
            Baralho.AdcCarta(new Carta("J", 10, Nipe.Paus, Cor.preta));
            Baralho.AdcCarta(new Carta("K", 10, Nipe.Copas, Cor.preta));
            Baralho.AdcCarta(new Carta("K", 10, Nipe.Espadas, Cor.preta));
            Baralho.AdcCarta(new Carta("K", 10, Nipe.Ouros, Cor.preta));
            Baralho.AdcCarta(new Carta("K", 10, Nipe.Paus, Cor.preta));

        }

    }
}
