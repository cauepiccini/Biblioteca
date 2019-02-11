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
    public partial class frmAlteraAluno : Form
    {
        public frmAlteraAluno()
        {
            InitializeComponent();
        }

        public string pesquisa;

        private void frmAlteraAluno_Load(object sender, EventArgs e)
        {
            PegaDgV();
        }

        public void PegaDgV()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);
            string cmd = "SELECT * FROM tb_aluno WHERE alu_cod = '" + pesquisa + "';";
            MySqlCommand command = new MySqlCommand(cmd,cnx);
            MySqlDataReader re;

            try
            {
                cnx.Open();
                re = command.ExecuteReader();

                while (re.Read())
                {
                    string Nome = re["alu_nome"].ToString();
                    txtNome.Text = Nome;

                    string Turma = re["alu_turma"].ToString();
                    txtTurma.Text = Turma;

                    string ID = re["alu_cod"].ToString();
                    txtID.Text = ID;

                    string Contato = re["alu_contato"].ToString();
                    mskContato.Text = Contato;

                    string Data_Nascimento = re["alu_data_nascimento"].ToString();
                    mskData_Nascimento.Text = Data_Nascimento;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Aluno.Nome = txtNome.Text;
            Aluno.Turma = txtTurma.Text;
            Aluno.Contato = mskContato.Text;
            Aluno.Data_Nascimento = mskData_Nascimento.Text;

            Aluno al = new Aluno();
            al.AtualizaAluno();

            txtNome.Text = "";
            txtTurma.Text = "";
            txtID.Text = "";
            mskData_Nascimento.Text = "";
            mskContato.Text = "";
        }
    }
}
