﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmModeloDeFormularioDeCadastro : Form
    {
        public String operacao;


        public frmModeloDeFormularioDeCadastro()
        {
            InitializeComponent();
        }

        public void alteraBotoes(int opcao)
        {
            //op = operações que serão feias com os botões
            //1 = Preparar os botoes para inserir e localizar
            //2 = Preparar os botoes para inserir/alterar um registro
            //3 = Preparar a tela para excluir ou alterar

            pnDados.Enabled = false;
            btInserir.Enabled = false;
            btAlterar.Enabled = false;
            btLocalizar.Enabled = false;
            btExcluir.Enabled = false;
            btCancelar.Enabled = false;
            btSalvar.Enabled = false;

            if (opcao == 1)
            {
                btInserir.Enabled = true;
                btLocalizar.Enabled = true;

            }else if (opcao == 2)
            {
                pnDados.Enabled = true;
                btSalvar.Enabled = true;
                btCancelar.Enabled = true;

            }else if (opcao == 3)
            {
                btAlterar.Enabled = true;
                btExcluir.Enabled = true;
                btCancelar.Enabled = true;
            }
        }

        private void frmModeloDeFormularioDeCadastro_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }
    }
}
