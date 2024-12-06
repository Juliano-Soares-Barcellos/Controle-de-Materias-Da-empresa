using System;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void arquivoCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inserirFoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastramentoFones t = new TelaCadastramentoFones(this);
            t.Show();
            this.Hide();
        }

        private void procurarPorCodigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcurarCodigoT p = new ProcurarCodigoT();
            p.Show();
        }

        private void porMêsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltroMes f = new FiltroMes();
            f.Show();
        }

        public void inserirArquivoCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrastarArquivoCsv a = new ArrastarArquivoCsv();

            a.Show();

        }

        private void criarArquivoAntesConsertoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AindaNaoConserto nao = new AindaNaoConserto(this);
            nao.Show();
            this.Hide();
        }
        private void imobilizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imobilizados im = new Imobilizados();
            im.Show();
        }

        private void cadastrarComputadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroComputador cadastro = new CadastroComputador();
            cadastro.Show();
        }

        private void telaDeCadastramentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaDeCadastramento tela = new TelaDeCadastramento();
            tela.Show();
        }
    }
}
