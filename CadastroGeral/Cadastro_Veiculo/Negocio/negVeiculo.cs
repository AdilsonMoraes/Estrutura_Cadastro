using Cadastro_Veiculo.DataAcessObject;
using System.Collections.Generic;
using FuncoesGenericas;

namespace Cadastro_Veiculo.Negocio
{
    class negVeiculo
    {
        public static List<Veiculo> RecuperarLista()
        {
            var ret = DAO.RecuperarLista();
            return ret;
        }

        public static Veiculo RecuperarPeloModelo(string pmodelo)
        {
            Veiculo ret = null;
            ret = DAO.RecuperarPeloModelo(pmodelo.ToUpper());
            return ret;

        }

        public static bool ExcluirPeloModelo(string pmodelo)
        {
            bool retorno = DAO.ExcluirPeloModelo(pmodelo.ToUpper());
            return retorno;
        }

        public static int Salvar(Veiculo paramPessoa)
        {
            var ret = DAO.Salvar(paramPessoa);
            return ret;
        }

        public static string MontaRetorno(Veiculo paramVeiculo)
        {
            string retorno = MensagensPadrao.StringEmBranco;

            retorno =  "\n";
            retorno = retorno +  "Marca: " + paramVeiculo.Marca + "\n";
            retorno = retorno + "Modelo: " + paramVeiculo.Modelo + "\n";
            retorno = retorno + "Cor: " + paramVeiculo.Cor + "\n";
            retorno = retorno + "Placa: " + paramVeiculo.Placa + "\n";
            retorno = retorno + "AnoModeloVeiculo: " + paramVeiculo.AnoModeloVeiculo + "\n";
            return retorno;
        }

        //Sobrecarga MontaRetorno
        public static string MontaRetorno(List<Veiculo> paramVeiculo)
        {
            string retorno = MensagensPadrao.StringEmBranco;
            int contador = 0;

            foreach (var item in paramVeiculo)
            {
                contador = contador++;

                if (contador == 1)
                {
                    retorno = retorno + "\n";
                }

                retorno = retorno + "Marca: " + item.Marca + "\n";
                retorno = retorno + "Modelo: " + item.Modelo + "\n";
                retorno = retorno + "Cor: " + item.Cor + "\n";
                retorno = retorno + "Placa: " + item.Placa + "\n";
                retorno = retorno + "AnoModeloVeiculo: " + item.AnoModeloVeiculo + "\n";
                retorno = retorno + "\n" + "=====================================" + "\n";
            }
            return retorno;
        }
    }
}
