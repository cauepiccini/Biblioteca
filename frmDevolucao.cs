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
    public partial class frmDevolucao : Form
    {
        public frmDevolucao()
        {
            InitializeComponent();
        }

        public string pesquisa;

//-------------------------------------------------M O S T R A---------------------------------------------------------------------------------------

        public void PegaDgV()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);
            string cmd = "SELECT * FROM tb_emprestimo WHERE emp_cod = '" + pesquisa + "';";
            MySqlCommand command = new MySqlCommand(cmd, cnx);
            MySqlDataReader re;

            try
            {
                cnx.Open();
                re = command.ExecuteReader();

                while (re.Read())
                {
                    string Nome = re["emp_nomealu"].ToString();
                    txtNomeAluno.Text = Nome;

                    string Nome2 = re["emp_nomealu"].ToString();
                    lblNomeAluno.Text = Nome2;

                    string Nome3 = re["emp_nomeliv"].ToString();
                    lblNomeLivro.Text = Nome3;

                    string ID = re["emp_codalu"].ToString();
                    txtIdAluno.Text = ID;

                    string ID2 = re["emp_codliv"].ToString();
                    txtIdLivro.Text = ID2;

                    string Data1 = re["emp_data_retira"].ToString();
                    mskRetira.Text = Data1;

                    string Data2 = re["emp_data_devol"].ToString();
                    mskDevol.Text = Data2;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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

        private void txtNomeAluno_TextChanged(object sender, EventArgs e)
        {
            mostraDatagrid();
            atualizaDatagrid();
        }

        private void frmDevolucao_Load(object sender, EventArgs e)
        {
            mostraDatagrid();
            dgvConsultar.AutoGenerateColumns = false;
        }

        private void dgvConsultar_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string pesquisaEmp = dgvConsultar.SelectedCells[0].FormattedValue.ToString();
            pesquisa = pesquisaEmp;
            PegaDgV();
        }

//-------------------------------------------------A T R A S O---------------------------------------------------------------------------------------
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string pesquisa = dgvConsultar.SelectedCells[0].FormattedValue.ToString();
            Emprestimo emp = new Emprestimo();
            Emprestimo.pesquisa3 = pesquisa;
            emp.ExcluirEmprestimo();
            atualizaDatagrid();

            txtNomeAluno.Text = "";
            txtIdAluno.Text = "";
            txtIdLivro.Text = "";
            lblNomeAluno.Text = "";
            lblNomeLivro.Text = "";
            mskDevol.Text = "";
            mskRetira.Text = "";
        }
    }
}
