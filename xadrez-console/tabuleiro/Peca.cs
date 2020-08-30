namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.Posicao = null;
            this.Cor = cor;
            this.Tab = tab;
            this.QteMovimentos = 0;
        }

        public void IncrementarQteMovimentos()
        {
            this.QteMovimentos++;
        }

        public bool ExistemMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < this.Tab.Linhas; i++)
            {
                for (int j = 0; j < this.Tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return this.MovimentosPossiveis()[pos.Linha,pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
