using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Biblioteca
{
    class Emprestimo
    {
        public static string NomeAlu, NomeLiv, IdAlu, IdLiv, Data_Retira, Data_Devol, pesquisa3;

        public void IncluiEmprestimo()
        {
            try
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
                MySqlConnection cnx = new MySqlConnection(conex);
                string cmd = "INSERT INTO tb_emprestimo(emp_nomealu, emp_nomeliv, emp_data_retira, emp_data_devol, emp_codalu, emp_codliv) VALUES('" + NomeAlu + "','" + NomeLiv + "','" + Data_Retira + "','" + Data_Devol + "','" + IdAlu + "','" + IdLiv + "');";
                MySqlCommand inclui = new MySqlCommand(cmd,cnx);


                cnx.Open();
                inclui.ExecuteNonQuery();
                MessageBox.Show("Emprestimo Realizado!");
                cnx.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
        }

        public void VerEmprestimo()
        {
            try
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
                MySqlConnection cnx = new MySqlConnection(conex);
                string cmd = "SELECT * FROM tb_emprestimo WHERE emp_nomealu = '" + NomeAlu + "'";

                MySqlDataAdapter sda = new MySqlDataAdapter(cmd, cnx);


                DataTable Tabela = new DataTable();
                sda.Fill(Tabela);

                if (Tabela.Rows.Count == 1)
                {
                    NomeAlu = Tabela.Rows[0][1].ToString();
                    NomeLiv = Tabela.Rows[0][1].ToString();
                    Data_Retira = Tabela.Rows[0][2].ToString();
                    Data_Devol = Tabela.Rows[0][3].ToString();
                }
                else
                {
                    MessageBox.Show("Empréstimo não encontrado!");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("" + e);
            }
        }

        public void AtualizaEmprestimo()
        {
            try
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
                MySqlConnection cnx = new MySqlConnection(conex);
                string cmd = "UPDATE tb_emprestimo SET emp_nomealu='" + NomeAlu + "', emp_nomeliv='" + NomeLiv + "', emp_data_retira='" + Data_Retira + "', emp_data_devol='" + Data_Devol + "';";
                MySqlCommand altera = new MySqlCommand(cmd);


                cnx.Open();
                altera.ExecuteNonQuery();
                MessageBox.Show("Dados alterados com sucesso");
                cnx.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("" + e);
            }
        }

        public void ExcluirEmprestimo()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);
            string cmd_del = "DELETE FROM tb_emprestimo WHERE emp_cod = '" + pesquisa3 + "';";
            MySqlCommand cmd = new MySqlCommand(cmd_del);

            cmd.Connection = cnx;
            cnx.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            MessageBox.Show("Deletado com sucesso");
        }
    }
}
