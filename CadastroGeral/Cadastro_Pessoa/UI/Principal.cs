using Cadastro_Pessoa.Negocio;

using System;

namespace Cadastro_Pessoa.UI
{
    public class ProgramPessoa
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************************** Pessoa **************************");
            Console.WriteLine("[1] - Consulta, " +
                              "[2] - Inserir, " +
                              "[3] - Deletar ");
            var funcao = Console.ReadLine();

            FuncoesGenericas.FuncoesGenericas.ValidaNumero(funcao);


            //Console.WriteLine("Informe um Nome:");
            //Funcao = Console.ReadLine();

            //Pessoa pessoa = new Pessoa();
            //pessoa.Nome = "TESTE";
            //pessoa.Rg = "4666565";
            //pessoa.Cpf = "52231564687";
            //pessoa.Email = "545642@sdsds";
            //pessoa.Telefone = "5453434532";
            //pessoa.FlAtivo = "S";
            
            //int x = NegPessoa.Salvar(pessoa);
       
            //Console.WriteLine("");
            //Console.ReadKey();
        }
    }
}
