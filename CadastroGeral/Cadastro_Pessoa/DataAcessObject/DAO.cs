using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Cadastro_Pessoa.DataAcessObject
{
    public class DAO
    {
        #region CRUD

        public static List<Pessoa> RecuperarLista()
        {
            var ret = new List<Pessoa>();

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ToString();
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("SELECT * FROM PESSOA");
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new Pessoa
                        {
                            PessoaID = (int)reader["PessoaID"],
                            Nome = (string)reader["Nome"],
                            Rg = (string)reader["Rg"],
                            Cpf = (string)reader["CPF"],
                            Email = (string)reader["EMAIL"],
                            Telefone = (string)reader["TELEFONE"],
                            FlAtivo = (string)reader["FlAtivo"]
                        });
                    }
                }
            }
            return ret;
        }

        public static Pessoa RecuperarPeloNome(string nome)
        {
            Pessoa ret = null;

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "select * FROM PESSOA WHERE NOME = @nome";
                    comando.Parameters.Add("@nome", SqlDbType.NVarChar).Value =  nome.ToUpper();

                    var reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        ret = new Pessoa
                        {
                            PessoaID = (int)reader["PessoaID"],
                            Nome = (string)reader["Nome"],
                            Rg = (string)reader["Rg"],
                            Cpf = (string)reader["CPF"],
                            Email = (string)reader["EMAIL"],
                            Telefone = (string)reader["TELEFONE"],
                            FlAtivo = (string)reader["FlAtivo"]

                        };
                    }
                }
            }

            return ret;
        }

        public static bool ExcluirPeloNome(string Nome)
        {
            bool retorno = false;
            Pessoa ret = RecuperarPeloNome(Nome.ToUpper());

            if (ret != null)
            {
                int id = ret.PessoaID;

                using (var conexao = new SqlConnection())
                {
                    conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                    conexao.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexao;
                        comando.CommandText = "Delete from Pessoa where (PessoaID = @id)";

                        comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        retorno = (comando.ExecuteNonQuery() > 0); //ExecuteNonQuery quantidade de registro afetados pelo comando
                    }
                }
            }
            return retorno;
        }

        public static int Salvar(Pessoa paramPessoa)
        {
            var ret = 0;

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    comando.CommandText = "INSERT INTO Pessoa (NOME, RG, CPF, EMAIL, TELEFONE, FlPessoaAtivo) " +
                        "VALUES (@nome, @rg, @cpf, @email, @telefone, @flativo); select convert(int, scope_identity());";

                    comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = paramPessoa.Nome;
                    comando.Parameters.Add("@rg", SqlDbType.VarChar).Value = paramPessoa.Rg;
                    comando.Parameters.Add("@cpf", SqlDbType.VarChar).Value = paramPessoa.Cpf;
                    comando.Parameters.Add("@email", SqlDbType.VarChar).Value = paramPessoa.Email;
                    comando.Parameters.Add("@telefone", SqlDbType.VarChar).Value = paramPessoa.Telefone;
                    comando.Parameters.Add("@FlAtivo", SqlDbType.VarChar).Value = paramPessoa.FlAtivo;

                    ret = (int)comando.ExecuteScalar(); //ExecuteScalar retorna um object, convertido para inteiro
                }
            }
            return ret;
        }

        #endregion
    }
}
