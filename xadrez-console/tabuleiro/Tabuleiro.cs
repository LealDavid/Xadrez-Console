namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            this.pecas = new Peca[linhas, colunas];
        }

        public Peca Peca(int linha, int coluna)
        {
            return this.pecas[linha, coluna];
        }

        public Peca Peca(Posicao pos)
        {
            return this.pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca(Posicao pos)
        {
            this.ValidarPosicao(pos);
            return this.Peca(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (this.ExistePeca(pos))
            {
                throw new TabuleiroException("Ja existe uma peca nessa posicao!");
            }
            this.pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!this.PosicaoValida(pos))
            {
                throw new TabuleiroException("Posicao invalida!");
            }
        }

    }
}

