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
    public partial class frmCadastraLivro : Form
    {
        public frmCadastraLivro()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCod.Text = "";
            txtNome.Text = "";
            txtAutor.Text = "";
            txtEditora.Text = "";
            txtTema.Text = "";
            txtQuanti.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Livro liv = new Livro();

            Livro.Cod = txtCod.Text;
            Livro.Nome = txtNome.Text;
            Livro.Tema = txtTema.Text;
            Livro.Editora = txtEditora.Text;
            Livro.Autor = txtAutor.Text;
            Livro.Quanti = txtQuanti.Text;

            liv.CadastrarLivro();
            txtCod.Text = "";
            txtNome.Text = "";
            txtTema.Text = "";
            txtEditora.Text = "";
            txtAutor.Text = "";
            txtQuanti.Text = "";
        }
    }
}
