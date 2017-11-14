using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelo;
using DAL;
using BLL;

namespace GUI
{
    public partial class frmCadastroCategoria : GUI.frmModeloDeFormularioDeCadastro
    {
        public frmCadastroCategoria()
        {
            InitializeComponent();
        }
        public void LimparTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }

        private void frmCadastroCategoria_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            //limpar a tela
            this.LimparTela();
            this.alteraBotoes(1);
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura dos dados
                ModeloCategoria modelo = new ModeloCategoria();
                modelo.cat_nome = txtNome.Text;

                //obj para gravar os dados no banco
                DALConexao conexao = new DALConexao(DadosDeConexao.StringDeConexao);
                BLLCategoria business = new BLLCategoria(conexao);

                if (this.operacao == "inserir")
                {
                    //cadastrar uma categoria
                    business.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado! Código : " + modelo.cat_cod.ToString());
                }
                else
                {
                    //alterar uma categoria
                    modelo.cat_cod = Convert.ToInt32(txtCodigo.Text);
                    business.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado!");
                }
                this.LimparTela();
                this.alteraBotoes(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            this.alteraBotoes(2);
;        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);
                if (result.ToString() == "Yes")
                {
                    DALConexao conexao = new DALConexao(DadosDeConexao.StringDeConexao);
                    BLLCategoria bLLCategoria = new BLLCategoria(conexao);
                    bLLCategoria.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.LimparTela();
                    this.alteraBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Impossivel excluir o registro. \n O registro está sendo utilizado em outro local");
                    this.alteraBotoes(3);
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaCategoria frmConsultaCategoria = new frmConsultaCategoria();
            frmConsultaCategoria.ShowDialog();
            if (frmConsultaCategoria.codigo != 0)
            {
                DALConexao conexao = new DALConexao(DadosDeConexao.StringDeConexao);
                BLLCategoria bLLCategoria = new BLLCategoria(conexao);
                ModeloCategoria modelo = bLLCategoria.CarregaMOdeloCategoria(frmConsultaCategoria.codigo);
                txtCodigo.Text = modelo.cat_cod.ToString();
                txtNome.Text = modelo.cat_nome;
                alteraBotoes(3);
            }
            else
            {
                this.LimparTela();
                this.alteraBotoes(1);
            }
            frmConsultaCategoria.Dispose();
        }
    }
}
