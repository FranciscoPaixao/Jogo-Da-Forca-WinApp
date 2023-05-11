namespace Jogo_Da_Forca
{
    public partial class JogoDaForcaTela : Form
    {
        private JogoDaForca jogoDaForca;
        public JogoDaForcaTela()
        {
            InitializeComponent();
            imagemForca.ImageLocation = "https://www.cjdinfo.com.br/images/diversao/forca/vazia.png";
            jogoDaForca = new JogoDaForca();
            jogoDaForca.SortearPalavra();
            resultadoVisor.Text = jogoDaForca.ObterResultadoFormatado();
        }
        private void btnClick(object sender, EventArgs e)
        {

            Button botaoClicado = (Button)sender;
            String textoBotao = botaoClicado.Text;
            if (jogoDaForca.ObterTentativas() == 6)
            {
                MessageBox.Show($"Você perdeu! \n A palavra era \"{jogoDaForca.ObterPalavraSorteada()}\"");
                tlp_TableLetras.Enabled = false;
                btnReiniciarJogo.Visible = true;
            }
            else
            {
                botaoClicado.Enabled = false;
                // botaoClicado.BackColor = Color.Gray;
                jogoDaForca.CompararPalavra(textoBotao);
                resultadoVisor.Text = jogoDaForca.ObterResultadoFormatado();
            }
            if (jogoDaForca.ObterResultado().Equals(jogoDaForca.ObterPalavraSorteada()))
            {
                MessageBox.Show($"Você ganhou! \n A palavra era \"{jogoDaForca.ObterPalavraSorteada()}\"");
                tlp_TableLetras.Enabled = false;
                btnReiniciarJogo.Visible = true;
            }
            imagemForca.ImageLocation = jogoDaForca.ObterImagem();
            this.ActiveControl = null;
        }

        private void ReiniciarJogoClick(object sender, EventArgs e)
        {
            jogoDaForca.SortearPalavra();
            resultadoVisor.Text = jogoDaForca.ObterResultadoFormatado();
            tlp_TableLetras.Enabled = true;
            foreach (Control control in tlp_TableLetras.Controls)
            {
                if (control is Button)
                {
                    control.Enabled = true;
                }
            }
            imagemForca.ImageLocation = jogoDaForca.ObterImagem();
            btnReiniciarJogo.Visible = false;
        }
    }
}