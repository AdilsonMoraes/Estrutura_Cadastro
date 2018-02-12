using Cadastro_Pessoa.Negocio;
using System;

namespace Cadastro_Pessoa.UI
{
    public class ProgramPessoa
    {
        enum OpecaoSelecionada { AnulaZero, Consulta, Insere, Deleta };

        static void Main(string[] args)
        {
            string readline = "";
            int opcaomenu = 0;
            string retorno = "";

            Console.WriteLine("************************** Pessoa **************************");


            while (readline == "")
            {
                Console.WriteLine("[1] - Consulta, " +
                                  "[2] - Inserir, " +
                                  "[3] - Deletar ");
                readline = Console.ReadLine();

                string err = FuncoesGenericas.FuncoesGenericas.MenuValido(readline);

                if (err != "")
                {
                    Console.WriteLine(err);
                    readline = "";
                }
                else
                {
                    opcaomenu = Convert.ToInt32(readline);
                }
            }

            if (opcaomenu == Convert.ToInt32(OpecaoSelecionada.Consulta))
            {
                Console.WriteLine("Deseja Consultar Pelo Nome ? [S] [N]");
                readline = Console.ReadLine();

                if (readline.ToUpper() == "S")
                {
                    Console.WriteLine("Digite o Nome do Cidadão: ");
                    readline = Console.ReadLine();
                    Pessoa ret = NegPessoa.RecuperarPeloNome(readline.ToUpper());

                    if (ret != null)
                    {
                        retorno = "Nome: " + ret.Nome + " Telefone: " + ret.Telefone;
                    }
                    else
                    {
                        retorno = "Sem Registro !";
                    }

                }
                else
                {
                    var ret = NegPessoa.RecuperarLista();

                    if (ret != null)
                    {
                        foreach (var item in ret)
                        {
                            retorno = retorno + "Nome: " + item.Nome + " Telefone: " + item.Telefone + "\n" + "\n";
                        }
                    }
                    else
                    {
                        retorno = "Sem Registro !";
                    }


                }

            }

            if (opcaomenu == Convert.ToInt32(OpecaoSelecionada.Insere))
            {

                //Pessoa pessoa = new Pessoa();
                //pessoa.Nome = "TESTE";
                //pessoa.Rg = "4666565";
                //pessoa.Cpf = "52231564687";
                //pessoa.Email = "545642@sdsds";
                //pessoa.Telefone = "5453434532";
                //pessoa.FlAtivo = "S";

                //int x = NegPessoa.Salvar(pessoa);
            }

            if (opcaomenu == Convert.ToInt32(OpecaoSelecionada.Deleta))
            {

            }

            Console.Write(retorno);
            Console.ReadKey();


        }
    }
}
