using System;
using tabuleiro;
using tabuleiro.Exceptions;
using Xadrez;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.Write("\nOrigem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosition();

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).MovimentosPosiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.Write("\nDestino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosition();

                    partida.ExecutaMovimento(origem, destino);
                }
            }
            catch (TabuleiroException te)
            {
                Console.WriteLine(te.Message);
            }
        }
    }
}
