using tabuleiro;
namespace xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida)
           : base(tab, cor) 
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p.Cor != this.Cor;
        }

        private bool Livre(Posicao pos)
        {
            return Tab.Peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            if (this.Cor == Cor.Branca)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos ==0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //#Jogadaespecial en passant
                if (this.Posicao.Linha == 3)
                {
                    Posicao aEsquerda = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(aEsquerda) && ExisteInimigo(aEsquerda) && Tab.Peca(aEsquerda) == partida.VulneravelEnPassant)
                    {
                        mat[aEsquerda.Linha - 1, aEsquerda.Coluna] = true;
                    }
                    Posicao aDireita = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(aDireita) && ExisteInimigo(aDireita) && Tab.Peca(aDireita) == partida.VulneravelEnPassant)
                    {
                        mat[aDireita.Linha -1, aDireita.Coluna] = true;
                    }
                }
            }
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //#Jogadaespecial en passant
                if (this.Posicao.Linha == 4)
                {
                    Posicao aEsquerda = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(aEsquerda) && ExisteInimigo(aEsquerda) && Tab.Peca(aEsquerda) == partida.VulneravelEnPassant)
                    {
                        mat[aEsquerda.Linha + 1, aEsquerda.Coluna] = true;
                    }
                    Posicao aDireita = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(aDireita) && ExisteInimigo(aDireita) && Tab.Peca(aDireita) == partida.VulneravelEnPassant)
                    {
                        mat[aDireita.Linha + 1, aDireita.Coluna] = true;
                    }
                }
            }
            return mat;
        }
    }
}
