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
    public partial class frmExcluirLivro : Form
    {
        public frmExcluirLivro()
        {
            InitializeComponent();
        }

        public void mostraDatagrid()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);

            string cmdDgv = "SELECT * FROM tb_livro;";

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

            string cmdDgv = "SELECT * FROM tb_livro WHERE liv_nome like '%" + pesquisa + "%' ORDER BY liv_cod;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmdDgv, cnx);

            DataTable livro = new DataTable();
            da.Fill(livro);

            dgvConsultar.DataSource = livro;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string pesquisa = dgvConsultar.SelectedCells[0].FormattedValue.ToString();
            Livro liv = new Livro();
            Livro.pesquisa1 = pesquisa;
            liv.ExcluirLivro();
            atualizaDatagrid();
        }

        private void frmExcluirLivro_Load(object sender, EventArgs e)
        {
            dgvConsultar.AutoGenerateColumns = false;
            mostraDatagrid();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            mostraDatagrid();
            atualizaDatagrid();
        }
    }
}
