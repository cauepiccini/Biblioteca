using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

//------------------------------------------------A L U N O--------------------------------------------------------------------------------------

        private void tsmCadastroAluno_Click(object sender, EventArgs e)
        {
            new frmCadastraAluno().Show();
        }

        private void tsmSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmConsultarAluno_Click(object sender, EventArgs e)
        {
            new frmConsultarAluno().Show();
        }

        private void tsmAtualizacaoAluno_Click(object sender, EventArgs e)
        {
            new frmAtualizaAluno().Show();
        }

        private void tsmExclusaoAluno_Click(object sender, EventArgs e)
        {
            new frmExcluirAluno().Show();
        }

//------------------------------------------------L I V R O--------------------------------------------------------------------------------------

        private void tsmCadastroLivro_Click(object sender, EventArgs e)
        {
            new frmCadastraLivro().Show();
        }

        private void tsmConsultaLivro_Click(object sender, EventArgs e)
        {
            new frmConsultarLivro().Show();
        }

        private void tsmAtualizarLivro_Click(object sender, EventArgs e)
        {
            new frmAtualizaLivro().Show();
        }

        private void tsmExcluirLivro_Click(object sender, EventArgs e)
        {
            new frmExcluirLivro().Show();
        }

//-------------------------------E M P R E S T I M O ---------------------------------------------------------------------------------------------

        private void incluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmIncluiEmprestimo().Show();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmConsutaEmprestimo().Show();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmExcluirEmprestimo().Show();
        }

        private void devloluçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDevolucao().Show();
        }

        private void lblPiccini_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Criado Por Cauê Piccini!");
        }
    }
}
