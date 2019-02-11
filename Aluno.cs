using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Biblioteca
{
    class Aluno
    {
        public static string Nome, Turma, Contato, Data_Nascimento, pesquisa2;

        public void CadastrarAluno()
        {
            try
            {
                if (!Nome.Equals("") && !Turma.Equals("") && !Contato.Equals("") && !Data_Nascimento.Equals(""))
                {
                    string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
                    MySqlConnection cnx = new MySqlConnection(conex);
                    string cmd = "INSERT INTO  tb_aluno(alu_nome, alu_turma, alu_contato, alu_data_nascimento) VALUES('" + Nome + "','" + Turma + "','" + Contato + "','" + Data_Nascimento + "');";
                    MySqlCommand cadastra = new MySqlCommand(cmd, cnx);

                    cnx.Open();
                    cadastra.ExecuteNonQuery();
                    MessageBox.Show("Aluno cadastrado com sucesso");
                    cnx.Close();
                }
                else
                {
                    MessageBox.Show("Nao deixe nenhum campo em branco ou somente com espacos!!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
        }

        public void VerAluno()
        {
            try
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
                MySqlConnection cnx = new MySqlConnection(conex);

                string cmd = "SELECT * FROM tb_aluno WHERE alu_nome = '" + Nome + "'";

                MySqlDataAdapter sda = new MySqlDataAdapter(cmd, cnx);


                DataTable Tabela = new DataTable();
                sda.Fill(Tabela);

                if (Tabela.Rows.Count == 1)
                {
                    Nome = Tabela.Rows[0][1].ToString();
                    Turma = Tabela.Rows[0][2].ToString();
                    Contato = Tabela.Rows[0][3].ToString();
                    Data_Nascimento = Tabela.Rows[0][4].ToString();
                }
                else
                {
                    MessageBox.Show("Aluno não encontrado!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
        }

        public void AtualizaAluno()
        {
            try
            {
                    string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
                    MySqlConnection cnx = new MySqlConnection(conex);
                    string cmd = "UPDATE tb_aluno SET alu_nome = '" + Nome + "',alu_turma ='" + Turma + "', alu_contato ='" + Contato + "', alu_data_nascimento ='" + Data_Nascimento + "' WHERE alu_cod = '" + pesquisa2 + "';";
                    MySqlCommand altera = new MySqlCommand(cmd, cnx);
                    
                    
                    cnx.Open();
                    altera.ExecuteNonQuery();
                    MessageBox.Show("Dados alterados com sucesso");
                    cnx.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
        }

        public void ExcluirAluno()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);
            string cmd_del = "DELETE FROM tb_aluno WHERE alu_cod = '" + pesquisa2 + "';";
            MySqlCommand cmd = new MySqlCommand(cmd_del);

            cmd.Connection = cnx;
            cnx.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            MessageBox.Show("Deletado com sucesso");
        }
    }
}
