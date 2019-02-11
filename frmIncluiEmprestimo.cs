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
    public partial class frmIncluiEmprestimo : Form
    {
        public frmIncluiEmprestimo()
        {
            InitializeComponent();
        }


        public string pesquisaLiv;
        public string pesquisaAlu;

//-------------------------------------------------L I V R O---------------------------------------------------------------------------------------

        public void PegaDgVLivro()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);
            string cmd = "SELECT * FROM tb_livro WHERE liv_cod = '" + pesquisaLiv + "';";
            MySqlCommand command = new MySqlCommand(cmd, cnx);
            MySqlDataReader re;

            try
            {
                cnx.Open();
                re = command.ExecuteReader();

                while (re.Read())
                {
                    string Nome = re["liv_nome"].ToString();
                    txtNomeLivro.Text = Nome;

                    string Nome2 = re["liv_nome"].ToString();
                    lblNomeLivro.Text = Nome2;

                    string ID = re["liv_cod"].ToString();
                    txtIdLivro.Text = ID;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void mostraDatagridLivro()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);

            string cmdDgv = "SELECT * FROM tb_livro;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmdDgv, cnx);

            DataTable produtos = new DataTable();
            da.Fill(produtos);

            dgvConsultar.DataSource = produtos;
        }

        public void atualizaDatagridLivro()
        {
            string pesquisaNL = txtNomeLivro.Text;
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);

            string cmdDgv = "SELECT * FROM tb_livro WHERE liv_nome like '%" + pesquisaNL + "%' ORDER BY liv_cod;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmdDgv, cnx);

            DataTable livro = new DataTable();
            da.Fill(livro);

            dgvConsultar.DataSource = livro;
        }

        public void configuraDataGridAbaixoLivro()
        {
            dgvConsultar.Columns[0].HeaderText = "ID";
            dgvConsultar.Columns[1].HeaderText = "Nome";
            dgvConsultar.Columns[2].HeaderText = "Tema";
            dgvConsultar.Columns[3].HeaderText = "Autor";
            dgvConsultar.Columns[4].HeaderText = "Editora";
            dgvConsultar.Columns[5].HeaderText = "Quanti";

            dgvConsultar.Columns["liv_cod"].Visible = true;
            dgvConsultar.Columns["liv_nome"].Visible = true;
            dgvConsultar.Columns["liv_tema"].Visible = true;
            dgvConsultar.Columns["liv_autor"].Visible = true;
            dgvConsultar.Columns["liv_editora"].Visible = true;
            dgvConsultar.Columns["liv_quanti"].Visible = true;

            dgvConsultar.Columns[0].Width = 30;
            dgvConsultar.Columns[1].Width = 145;
            dgvConsultar.Columns[2].Width = 99;
            dgvConsultar.Columns[3].Width = 84;
            dgvConsultar.Columns[4].Width = 100;
            dgvConsultar.Columns[5].Width = 75;
        }

        private void txtNomeLivro_TextChanged(object sender, EventArgs e)
        {
            mostraDatagridLivro();
            atualizaDatagridLivro();
            configuraDataGridAbaixoLivro();
        }
//--------------------------------------------------A L U N O-------------------------------------------------------------------------------------
        public void PegaDgVAluno()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);
            string cmd = "SELECT * FROM tb_aluno WHERE alu_cod = '" + pesquisaAlu + "';";
            MySqlCommand command = new MySqlCommand(cmd, cnx);
            MySqlDataReader re;

            try
            {
                cnx.Open();
                re = command.ExecuteReader();

                while (re.Read())
                {
                    string Nome = re["alu_nome"].ToString();
                    txtNomeAluno.Text = Nome;

                    string Nome2 = re["alu_nome"].ToString();
                    lblNomeAluno.Text = Nome2;

                    string ID = re["alu_cod"].ToString();
                    txtIdAluno.Text = ID;
                }   
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void mostraDatagridALuno()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);

            string cmdDgv = "SELECT * FROM tb_aluno;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmdDgv, cnx);

            DataTable produtos = new DataTable();
            da.Fill(produtos);

            dgvConsultar.DataSource = produtos;
        }

        public void atualizaDatagridAluno()
        {
            string pesquisaNA = txtNomeAluno.Text;
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);

            string cmdDgv = "SELECT * FROM tb_aluno WHERE alu_nome like '%" + pesquisaNA + "%' ORDER BY alu_cod;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmdDgv, cnx);

            DataTable produtos = new DataTable();
            da.Fill(produtos);

            dgvConsultar.DataSource = produtos;
        }

        public void configuraDataGridAbaixoAluno()
        {
            dgvConsultar.Columns[0].HeaderText = "ID";
            dgvConsultar.Columns[1].HeaderText = "Nome";
            dgvConsultar.Columns[2].HeaderText = "Turma";
            dgvConsultar.Columns[3].HeaderText = "Contato";
            dgvConsultar.Columns[4].HeaderText = "Data de Nascimento";

            dgvConsultar.Columns["alu_cod"].Visible = true;
            dgvConsultar.Columns["alu_nome"].Visible = true;
            dgvConsultar.Columns["alu_turma"].Visible = true;
            dgvConsultar.Columns["alu_contato"].Visible = true;
            dgvConsultar.Columns["alu_data_nascimento"].Visible = true;

            dgvConsultar.Columns[0].Width = 30;
            dgvConsultar.Columns[1].Width = 200;
            dgvConsultar.Columns[2].Width = 50;
            dgvConsultar.Columns[3].Width = 100;
            dgvConsultar.Columns[4].Width = 134;
        }

        private void txtNomeAluno_TextChanged(object sender, EventArgs e)
        {
            mostraDatagridALuno();
            atualizaDatagridAluno();
            configuraDataGridAbaixoAluno();
        }

//--------------------------------------------------E M P R E S T I M O-------------------------------------------------------------------------------

        private void dgvConsultar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string pesquisaAl = dgvConsultar.SelectedCells[0].FormattedValue.ToString();

            if (pesquisaAl == dgvConsultar.SelectedCells[0].FormattedValue.ToString())
            {
                pesquisaAlu = pesquisaAl;
                PegaDgVAluno();
            }

            string pesquisaLv = dgvConsultar.SelectedCells[0].FormattedValue.ToString();

            if (pesquisaLv == dgvConsultar.SelectedCells[0].FormattedValue.ToString())
            {
                pesquisaLiv = pesquisaLv;
                PegaDgVLivro();
            }
        }

//--------------------------------------------------D A T A S-----------------------------------------------------------------------------------------

        private void frmIncluiEmprestimo_Load(object sender, EventArgs e)
        {
            mskRetira.Text = "01/01/2019";
            mskDevol.Text = "08/01/2019";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Emprestimo emp = new Emprestimo();

            Emprestimo.NomeAlu = txtNomeAluno.Text;
            Emprestimo.NomeLiv = txtNomeLivro.Text;
            Emprestimo.IdAlu = txtIdAluno.Text;
            Emprestimo.IdLiv = txtIdLivro.Text;
            Emprestimo.Data_Retira = mskRetira.Text;
            Emprestimo.Data_Devol = mskDevol.Text;

            emp.IncluiEmprestimo();

            txtNomeAluno.Text = "";
            txtNomeLivro.Text = "";
            txtIdAluno.Text = "";
            txtIdLivro.Text = "";
            mskRetira.Text = "";
            mskDevol.Text = "";
            lblNomeAluno.Text = "";
            lblNomeLivro.Text = "";
        }
    }
}
