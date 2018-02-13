using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Cadastro_Veiculo.DataAcessObject
{
    class DAO
    {
        #region CRUD

        public static List<Veiculo> RecuperarLista()
        {
            var ret = new List<Veiculo>();

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ToString();
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("SELECT * FROM Veiculo");
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new Veiculo
                        {
                            VeiculoID = (int)reader["VeiculoID"],
                            Marca = (string)reader["Marca"],
                            Modelo = (string)reader["Modelo"],
                            Cor = (string)reader["Cor"],
                            Placa = (string)reader["Placa"],
                            AnoModeloVeiculo = (string)reader["AnoModeloVeiculo"],
                            FlAtivo = (string)reader["FlAtivo"]
                        });
                    }
                }
            }
            return ret;
        }

        public static Veiculo RecuperarPeloModelo(string pmodelo)
        {
            Veiculo ret = null;

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "select * FROM Veiculo WHERE Modelo = @modelo";
                    comando.Parameters.Add("@modelo", SqlDbType.NVarChar).Value = pmodelo.ToUpper();

                    var reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        ret = new Veiculo
                        {
                            VeiculoID = (int)reader["VeiculoID"],
                            Marca = (string)reader["Marca"],
                            Modelo = (string)reader["Modelo"],
                            Cor = (string)reader["Cor"],
                            Placa = (string)reader["Placa"],
                            AnoModeloVeiculo = (string)reader["AnoModeloVeiculo"],
                            FlAtivo = (string)reader["FlAtivo"]
                        };
                    }
                }
            }

            return ret;
        }

        public static bool ExcluirPeloModelo(string pmodelo)
        {
            bool retorno = false;
            Veiculo ret = RecuperarPeloModelo(pmodelo.ToUpper());

            if (ret != null)
            {
                int id = ret.VeiculoID;

                using (var conexao = new SqlConnection())
                {
                    conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                    conexao.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexao;
                        comando.CommandText = "Delete from Veiculo where (VeiculoID = @id)";

                        comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        retorno = (comando.ExecuteNonQuery() > 0); //ExecuteNonQuery quantidade de registro afetados pelo comando
                    }
                }
            }
            return retorno;
        }

        public static int Salvar(Veiculo paramVeiculo)
        {
            var ret = 0;

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    comando.CommandText = "INSERT INTO Veiculo (Marca, Modelo, Cor, Placa, AnoModeloVeiculo, FLATIVO) " +
                        "VALUES (@Marca, @Modelo, @Cor, @Placa, @AnoModeloVeiculo, @flativo); select convert(int, scope_identity());";

                    comando.Parameters.Add("@Marca", SqlDbType.VarChar).Value = paramVeiculo.Marca;
                    comando.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = paramVeiculo.Modelo;
                    comando.Parameters.Add("@Cor", SqlDbType.VarChar).Value = paramVeiculo.Cor;
                    comando.Parameters.Add("@Placa", SqlDbType.VarChar).Value = paramVeiculo.Placa;
                    comando.Parameters.Add("@AnoModeloVeiculo", SqlDbType.VarChar).Value = paramVeiculo.AnoModeloVeiculo;
                    comando.Parameters.Add("@flativo", SqlDbType.VarChar).Value = paramVeiculo.FlAtivo;

                    ret = (int)comando.ExecuteScalar(); //ExecuteScalar retorna um object, convertido para inteiro
                }
            }
            return ret;
        }

        #endregion
    }
}
