﻿using ProjetoDeControleDeMateriaisMandadoParaConserto.Dao;
using System;
using System.Windows.Forms;

namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Forms
{
    public partial class TelaDeCadastramento : Form
    {
        private ListarConsertoTelaCadastramento HistoricoDeConserto;
        private InseriComputadorParaConserto InserirComputadorConserto;
        private RetiraDoConserto RetiraDoConserto;
        private readonly string TextoPatrimonio = "Digite o Patrimonio";
        private readonly string TextoDescricao = "Digite a Descricao do problema";
        private readonly string TextoDescricao2 = "Digite a Descricao do que foi feito";
        private readonly string TextoSistema = "Selecione o sistema operacional";
        private readonly string TextoModelo = "Selecione ou digite o modelo";
        private readonly string message = "Deseja prosseguir? Digite 's' para sim ou 'n' para não:";
        private readonly string caption = "Confirmação";

        public TelaDeCadastramento()
        {
            InitializeComponent();
            HistoricoDeConserto = new ListarConsertoTelaCadastramento(Tabela, TextBox1, ComboSistemaHistorico, CheckLimpar, CheckGravar, CheckSSD);
            ConfigurarComponentes();
            comboboxpreenchidaModelo(comboModelo);
            HistoricoDeConserto.carregarTabela();
        }

        private void ConfigurarComponentes()
        {
            ConfigurarTextoInicial(TextBox1, TextoPatrimonio);
            ConfigurarTextoInicial(textPatrimonio, TextoPatrimonio);
            ConfigurarTextoInicial(Tnome, TextoPatrimonio);
            ConfigurarTextoInicial(TextDescricao, TextoDescricao);
            ConfigurarTextoInicial(maskedTextBox1, TextoDescricao2);
            ConfigurarTextoInicial(comboBox1, TextoSistema);
            ConfigurarTextoInicial(comboSistema, TextoSistema);
            ConfigurarTextoInicial(ComboSistemaHistorico, TextoSistema);
            ConfigurarTextoInicial(comboModelo, TextoModelo);
            TextBox1.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { ProcurarPatrimonio(); } };
            ComboSistemaHistorico.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { ProcurarPorSistema(); } };
        }

        private void ConfigurarTextoInicial(Control controle, string textoInicial)
        {
            if (controle is MaskedTextBox textBox)
            {
                textBox.Text = textoInicial;
                textBox.Enter += (s, e) => LimparTextoInicial(textBox, textoInicial);
                textBox.Leave += (s, e) => RestaurarTextoInicial(textBox, textoInicial);
            }
            else if (controle is ComboBox comboBox)
            {
                comboBox.Text = textoInicial;
                comboBox.Enter += (s, e) => LimparTextoInicial(comboBox, textoInicial);
                comboBox.Leave += (s, e) => RestaurarTextoInicial(comboBox, textoInicial);
            }
        }

        private void LimparTextoInicial(Control controle, string textoInicial)
        {
            if (controle.Text == textoInicial)
            {
                controle.Text = "";
            }
        }

        private void RestaurarTextoInicial(Control controle, string textoInicial)
        {
            if (string.IsNullOrWhiteSpace(controle.Text))
            {
                controle.Text = textoInicial;
                if (controle is MaskedTextBox textBox) textBox.Mask = null;
            }
        }

        public void comboboxpreenchidaModelo(ComboBox combo)
        {
            ComputadorDao _computadorDao = new ComputadorDao();
            combo.Items.Clear();
            foreach (String item in _computadorDao.carregarCombobox())
            {
                combo.Items.Add(item);
            }
        }
        public Boolean validaEntradaDadosText(string texto, MaskedTextBox textBox)
        {
            if (textBox != null)
            {
                if (textBox.Text.Equals(texto) || textBox.Text.Equals(""))
                {
                    return false;
                }
            }
            return true;
        }
        public Boolean validaEntradaDadosComboBox(string texto, ComboBox combo)
        {
            if (combo != null)
            {
                // Verifica se o combo está vazio ou se ainda tem o texto padrão
                if (string.IsNullOrEmpty(combo.Text) || combo.Text.Equals(texto))
                {
                    return false;
                }
            }
            return true;
        }

        public Boolean ValidaSeNaoTemTextEmBrancoTelaHistóricoDoConserto()
        {
            if (validaEntradaDadosText(TextoPatrimonio, TextBox1))
                return true;
            throw new Exception("Digite o Patrimonio ");
        }
        public Boolean ValidaSeNaoTemTextEmBrancoTelaHistóricoDoConsertoCombo()
        {
            if (validaEntradaDadosComboBox(TextoSistema, ComboSistemaHistorico))
                return true;
            throw new Exception("escolha o Sistema Operacional");
        }

        public Boolean ValidaSeNaoTemTextEmBrancoTelaCadastroConserto()
        {
            if (validaEntradaDadosText(TextoPatrimonio, textPatrimonio)
                | validaEntradaDadosText(TextoDescricao, TextDescricao))
                return true;
            throw new Exception("Patrimonio e descricao obrigatórios");
        }
        public Boolean ValidaSeNaoTemTextEmBrancoTelaRetiraDoConserto()
        {
            if (validaEntradaDadosText(TextoPatrimonio, Tnome)
                | validaEntradaDadosText(TextoDescricao2, maskedTextBox1))
                return true;
            throw new Exception("Patrimonio e Descricao obrigatórios");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                ValidaSeNaoTemTextEmBrancoTelaCadastroConserto();
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    InserirComputadorConserto = new InseriComputadorParaConserto(textPatrimonio, TextDescricao, comboModelo, comboBox1);
                }
                else
                {
                    MessageBox.Show("Operação cancelada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ConfigurarComponentes();
        }
        private void Benter_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaSeNaoTemTextEmBrancoTelaRetiraDoConserto();
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    RetiraDoConserto = new RetiraDoConserto(Tnome, maskedTextBox1, comboSistema, CheckBox);
                }
                else
                {
                    MessageBox.Show("Operacao cancelada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ConfigurarComponentes();
        }

        private void ProcurarPatrimonio()
        {
            try
            {
                ValidaSeNaoTemTextEmBrancoTelaHistóricoDoConserto();
                HistoricoDeConserto.procurarPatrimonio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ProcurarPorSistema()
        {
            try
            {
                ValidaSeNaoTemTextEmBrancoTelaHistóricoDoConsertoCombo();
                HistoricoDeConserto.ProcurarPeloSistema(ComboSistemaHistorico.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckGravar_CheckedChanged(object sender, EventArgs e)
        {
            HistoricoDeConserto.check();
        }

        private void CheckLimpar_CheckedChanged(object sender, EventArgs e)
        {
            HistoricoDeConserto.check3();
        }

        private void CheckSSD_CheckedChanged(object sender, EventArgs e)
        {
            HistoricoDeConserto.check2();
        }

        private void TextDescricao_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
