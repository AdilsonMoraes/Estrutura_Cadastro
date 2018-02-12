using Cadastro_Pessoa.DataAcessObject;
using System.Collections.Generic;

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

    }
}
