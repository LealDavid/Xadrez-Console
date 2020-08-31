using tabuleiro;
namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida)
            :base(tab,cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p is Torre && p.Cor == this.Cor && p.QteMovimentos == 0;
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
            //#Jogadaespecial roque
            if (this.QteMovimentos == 0 && !this.partida.Xeque)
            {
                //#Jogadaespecial roque pequeno
                Posicao posT1 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 3);
                if (TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 2);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null)
                    {
                        mat[this.Posicao.Linha, this.Posicao.Coluna + 2] = true;
                    }
                }
                //#Jogadaespecial roque grande
                Posicao posT2 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 4);
                if (TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 3);

                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null && Tab.Peca(p3)==null)
                    {
                        mat[this.Posicao.Linha, this.Posicao.Coluna - 2] = true;
                    }
                }
            }




            return mat;
        }
    }
}
