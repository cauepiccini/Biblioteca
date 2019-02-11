using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Biblioteca
{
    public partial class frmExcluirEmprestimo : Form
    {
        public frmExcluirEmprestimo()
        {
            InitializeComponent();
        }

        public void mostraDatagrid()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);

            string cmdDgv = "SELECT * FROM tb_emprestimo;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmdDgv, cnx);

            DataTable produtos = new DataTable();
            da.Fill(produtos);

            dgvConsultar.DataSource = produtos;
        }

        public void atualizaDatagrid()
        {
            string pesquisa = txtNomeAluno.Text;
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);

            string cmdDgv = "SELECT * FROM tb_emprestimo WHERE emp_nomealu like '%" + pesquisa + "%' ORDER BY emp_cod;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmdDgv, cnx);

            DataTable livro = new DataTable();
            da.Fill(livro);

            dgvConsultar.DataSource = livro;
        }

        private void frmExcluirEmprestimo_Load(object sender, EventArgs e)
        {
            mostraDatagrid();
            dgvConsultar.AutoGenerateColumns = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string pesquisa = dgvConsultar.SelectedCells[0].FormattedValue.ToString();
            Emprestimo emp = new Emprestimo();
            Emprestimo.pesquisa3 = pesquisa;
            emp.ExcluirEmprestimo();
            atualizaDatagrid();

            txtNomeAluno.Text = "";
        }

        private void txtNomeAluno_TextChanged(object sender, EventArgs e)
        {
            mostraDatagrid();
            atualizaDatagrid();
        }
    }
}
