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
    public partial class frmConsultarAluno : Form
    {
        public frmConsultarAluno()
        {
            InitializeComponent();
        }

        public void mostraDatagrid()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);

            string cmdDgv = "SELECT * FROM tb_aluno;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmdDgv, cnx);

            DataTable produtos = new DataTable();
            da.Fill(produtos);

            dgvConsultar.DataSource = produtos;
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
            mostraDatagrid();
            atualizaDatagrid();
        }

        private void frmConsultarAluno_Load(object sender, EventArgs e)
        {
            mostraDatagrid();
            dgvConsultar.AutoGenerateColumns = false;
        }

    }
}
