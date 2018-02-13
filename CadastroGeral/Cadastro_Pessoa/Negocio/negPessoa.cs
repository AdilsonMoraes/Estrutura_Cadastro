using Cadastro_Pessoa.DataAcessObject;
using System.Collections.Generic;
using FuncoesGenericas;

namespace Cadastro_Pessoa.Negocio
{
    public class NegPessoa
    {

        public static List<Pessoa> RecuperarLista()
        {
            var ret = DAO.RecuperarLista();
            return ret;
        }

        public static Pessoa RecuperarPeloNome(string nome)
        {
            Pessoa ret = null;
            ret = DAO.RecuperarPeloNome(nome.ToUpper());
            return ret;

        }

        public static bool ExcluirPeloNome(string Nome)
        {
            bool retorno = DAO.ExcluirPeloNome(Nome.ToUpper());
            return retorno;
        }

        public static int Salvar(Pessoa paramPessoa)
        {
            var ret = DAO.Salvar(paramPessoa);
            return ret;
        }

        public static string MontaRetorno(Pessoa paramPessoa)
        {
            string retorno = MensagensPadrao.StringEmBranco;

            retorno = "Nome: " + paramPessoa.Nome;
            retorno = retorno + " Telefone: " + paramPessoa.Telefone + "\n";
            retorno = retorno + "Rg: " + paramPessoa.Rg + "\n";
            retorno = retorno + "Cpf: " + paramPessoa.Cpf + "\n";
            retorno = retorno + "Email: " + paramPessoa.Email + "\n";
            retorno = retorno + "Telefone: " + paramPessoa.Telefone + "\n";

            return retorno;
        }

        //Sobrecarga
        public static string MontaRetorno(List<Pessoa> paramPessoa)
        {
            string retorno = MensagensPadrao.StringEmBranco;

            foreach (var item in paramPessoa)
            {
                retorno = retorno + "Nome: " + item.Nome;
                retorno = retorno + " Telefone: " + item.Telefone + "\n";
                retorno = retorno + "Rg: " + item.Rg + "\n";
                retorno = retorno + "Cpf: " + item.Cpf + "\n";
                retorno = retorno + "Email: " + item.Email + "\n";
                retorno = retorno + "Telefone: " + item.Telefone + "\n";
                retorno = retorno + "\n" + "=====================================" + "\n";
            }
            return retorno;
        }

    }
}
