using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicativoComMultiplasJanelas
{
    public partial class FormNovaCompra : Form
    {

        private BindingList<Fornecedor> Fornecedores { get; set; }
        private Fornecedor Fornecedor { get { return Fornecedores.FirstOrDefault(f => f.Id == (int)comboBoxFornecedor.SelectedValue); } }
        public int IdFornecedor { get { return (int)comboBoxFornecedor.SelectedValue; } }

        private BindingList<Produto> Produtos { get; set; }
        private Produto Produto { get { return Produtos.FirstOrDefault(p => p.Id == (int)comboBoxProduto.SelectedValue); } }
        public int IdProduto { get { return (int)comboBoxProduto.SelectedValue; } }

        public decimal Quantidade { get { return numericUpDownQuantidade.Value; } }
        public decimal Desconto { get { return numericUpDownDesconto.Value; } }

        private decimal PrecoUnitario { get { return Produto.PrecoCompra; } }
        private decimal ValorTotal { get { return PrecoUnitario * Quantidade; } }
        private decimal ValorComDesconto { get { return ValorTotal * (1 - (Desconto / 100)); } }



        public FormNovaCompra(BindingList<Fornecedor> fornecedores, BindingList<Produto> produtos)
        {
            InitializeComponent();
            Fornecedores = fornecedores;
            comboBoxFornecedor.ValueMember = "Id";
            comboBoxFornecedor.DisplayMember = "NomeEmpresa";
            comboBoxFornecedor.DataSource = Fornecedores;
            comboBoxFornecedor.SelectedIndex = 0;

            Produtos = produtos;
            comboBoxFornecedor.ValueMember = "Id";
            comboBoxFornecedor.DisplayMember = "Nome";
            comboBoxFornecedor.DataSource = Produtos;
            comboBoxFornecedor.SelectedIndex = 0;




        }

        private void Ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
        private void AtualizarValores()
        {
            if (Produto != null)
            {
                textBoxPreçoUnitario.Text = PrecoUnitario.ToString("C", CultureInfo.CurrentCulture);
                textBoxValorTotal.Text = ValorTotal.ToString("C", CultureInfo.CurrentCulture);
                textBoxTotalComDesconto.Text = ValorComDesconto.ToString("C", CultureInfo.CurrentCulture);


            }
        }
    }
}
