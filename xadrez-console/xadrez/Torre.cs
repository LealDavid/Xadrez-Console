using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor)
            : base(tab, cor) { }

        public override string ToString()
        {
            return "T";
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
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }
            //abaixo
            pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }
            //direita
            pos.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }
            //esquerda
            pos.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != this.Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return mat;
        }
    }
}
