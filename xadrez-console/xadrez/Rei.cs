using System.Reflection.PortableExecutable;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor)
            :base(tab,cor){}

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Nordeste
            pos.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Direita
            pos.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //sudeste
            pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //abaixo
            pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //sudoeste
            pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Esquerda
            pos.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Noroeste
            pos.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            return mat;
        }
    }
}
