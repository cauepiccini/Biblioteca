using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Biblioteca
{
    class Livro
    {
        public static string Cod, Nome, Tema, Autor, Editora, Quanti, pesquisa1;

        public void CadastrarLivro()
        {
            try
            {
                if (!Nome.Equals("") && !Tema.Equals("") && !Autor.Equals("") && !Editora.Equals(""))
                {
                    string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
                    MySqlConnection cnx = new MySqlConnection(conex);
                    string cmd = "INSERT INTO  tb_livro(liv_cod, liv_nome, liv_tema, liv_autor, liv_editora, liv_quanti) VALUES('" + Cod + "','" + Nome + "','" + Tema + "','" + Autor + "','" + Editora + "','" + Quanti + "');";
                    MySqlCommand cadastra = new MySqlCommand(cmd, cnx);

                    cnx.Open();
                    cadastra.ExecuteNonQuery();
                    MessageBox.Show("Livro cadastrado com sucesso");
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

        public void VerLivro()
        {
            try
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
                MySqlConnection cnx = new MySqlConnection(conex);

                string cmd = "SELECT * FROM tb_livro WHERE liv_nome = '" + Nome + "'";

                MySqlDataAdapter sda = new MySqlDataAdapter(cmd, cnx);


                DataTable Tabela = new DataTable();
                sda.Fill(Tabela);

                if (Tabela.Rows.Count == 1)
                {
                    Nome = Tabela.Rows[0][1].ToString();
                    Tema = Tabela.Rows[0][2].ToString();
                    Autor = Tabela.Rows[0][3].ToString();
                    Editora = Tabela.Rows[0][4].ToString();
                    Quanti = Tabela.Rows[0][5].ToString();
                }
                else
                {
                    MessageBox.Show("Livro não encontrado!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
        }

        public void AtualizaLivro()
        {
            try
            {
                    string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
                    MySqlConnection cnx = new MySqlConnection(conex);
                    string cmd = "UPDATE tb_livro SET liv_nome = '" + Nome + "',liv_tema ='" + Tema + "',liv_autor ='" + Autor + "', liv_editora ='" + Editora + "', liv_quanti ='" + Quanti + "' WHERE liv_cod = '" + pesquisa1 + "';";
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

        public void ExcluirLivro()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = bd_biblioteca";
            MySqlConnection cnx = new MySqlConnection(conex);
            string cmd_del = "DELETE FROM tb_livro WHERE liv_cod = '" + pesquisa1 + "';";
            MySqlCommand cmd = new MySqlCommand(cmd_del);

            cmd.Connection = cnx;
            cnx.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            MessageBox.Show("Deletado com sucesso");
        }

    }
}
