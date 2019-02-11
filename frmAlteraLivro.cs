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
    public partial class frmAlteraLivro : Form
    {
        public frmAlteraLivro()
        {
            InitializeComponent();
        }

        public string pesquisa;

        private void frmAlteraLivro_Load(object sender, EventArgs e)
        {
            PegaDgV();
        }

        public void PegaDgV()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);
            string cmd = "SELECT * FROM tb_livro WHERE liv_cod = '" + pesquisa + "';";
            MySqlCommand command = new MySqlCommand(cmd, cnx);
            MySqlDataReader re;

            try
            {
                cnx.Open();
                re = command.ExecuteReader();

                while (re.Read())
                {
                    string Nome = re["liv_nome"].ToString();
                    txtNome.Text = Nome;

                    string Tema = re["liv_tema"].ToString();
                    txtTema.Text = Tema;

                    string Autor = re["liv_autor"].ToString();
                    txtAutor.Text = Autor;

                    string ID = re["liv_cod"].ToString();
                    txtID.Text = ID;

                    string Editora = re["liv_editora"].ToString();
                    txtEditora.Text = Editora;

                    string Quanti = re["liv_Quanti"].ToString();
                    txtQuanti.Text = Quanti;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Livro.Nome = txtNome.Text;
            Livro.Tema = txtTema.Text;
            Livro.Autor = txtAutor.Text;
            Livro.Editora = txtEditora.Text;
            Livro.Quanti = txtQuanti.Text;

            Livro liv = new Livro();
            liv.AtualizaLivro();

            txtQuanti.Text = "";
            txtEditora.Text = "";
            txtAutor.Text = "";
            txtTema.Text = "";
            txtNome.Text = "";
        }


    }
}
