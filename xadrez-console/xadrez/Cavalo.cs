using tabuleiro;
namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "C";
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
                        
            pos.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 2);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(this.Posicao.Linha - 2, this.Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(this.Posicao.Linha - 2, this.Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 2);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 2);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(this.Posicao.Linha + 2, this.Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(this.Posicao.Linha + 2, this.Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 2);
            if (Tab.PosicaoValida(pos) && this.PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            return mat;
        }
    }
}
