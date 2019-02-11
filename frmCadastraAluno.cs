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
    public partial class frmCadastraAluno : Form
    {
        public frmCadastraAluno()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtTurma.Text = "";
            mskContato.Text = "";
            mskData_Nascimento.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Aluno al = new Aluno();

            Aluno.Nome = txtNome.Text;
            Aluno.Turma = txtTurma.Text;
            Aluno.Contato = mskContato.Text;
            Aluno.Data_Nascimento = mskData_Nascimento.Text;

            al.CadastrarAluno();
            txtNome.Text = "";
            txtTurma.Text = "";
            mskContato.Text = "";
            mskData_Nascimento.Text = "";
        }
    }
}
