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
    public partial class frmAtualizaAluno : Form
    {
        public frmAtualizaAluno()
        {
            InitializeComponent();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string pesquisa = dgvConsultar.SelectedCells[0].FormattedValue.ToString();
            frmAlteraAluno alt = new frmAlteraAluno();

            this.Hide();
            alt.pesquisa = pesquisa;
            Aluno.pesquisa2 = pesquisa;
            alt.ShowDialog();
        }

        public void mostraDatagrid()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);

            string cmdDgv = "SELECT * FROM tb_aluno;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmdDgv, cnx);

            DataTable aluno = new DataTable();
            da.Fill(aluno);

            dgvConsultar.DataSource = aluno;
        }

        public void atualizaDatagrid()
        {
            string pesquisa = txtNome.Text;
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);

            string cmdDgv = "SELECT * FROM tb_aluno WHERE alu_nome like '%" + pesquisa + "%' ORDER BY alu_cod;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmdDgv, cnx);

            DataTable produtos = new DataTable();
            da.Fill(produtos);

            dgvConsultar.DataSource = produtos;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            atualizaDatagrid();
        }

        private void frmAtualizaAluno_Load(object sender, EventArgs e)
        {
            dgvConsultar.AutoGenerateColumns = false;
            mostraDatagrid();
        }
    }
}
