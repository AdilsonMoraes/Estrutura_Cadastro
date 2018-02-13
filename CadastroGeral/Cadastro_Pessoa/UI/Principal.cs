using Cadastro_Pessoa.Negocio;
using FuncoesGenericas;
using System;

namespace Cadastro_Pessoa.UI
{
    public class ProgramPessoa
    {
        enum OpecaoSelecionada { AnulaZero, Consulta, Insere, Deleta, Sair };

        static void Main(string[] args)
        {
            Show();
        }

        public static void Show()
        {
            #region Show
            Inicio:
            string retorno = MensagensPadrao.StringEmBranco;
            string readline = MensagensPadrao.StringEmBranco;
            int opcaomenu = 0;

            Console.Title = MensagensPadrao.TitlePessoa;
            while (readline == MensagensPadrao.StringEmBranco)
            {
                Console.WriteLine("[1] - Consulta, " +
                                  "[2] - Inserir, " +
                                  "[3] - Deletar, " +
                                  "[4] - Sair");

                readline = Console.ReadLine();

                string err = Funcoes.MenuValido(readline);

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
                #region ConsultaPessoa
                readline = MensagensPadrao.StringEmBranco;
                while (readline == MensagensPadrao.StringEmBranco)
                {
                    Console.WriteLine(MensagensPadrao.FormaDeConsultarPessoa);
                    readline = Console.ReadLine();
                }

                if (readline.ToUpper() == "S")
                {
                    Console.WriteLine(MensagensPadrao.InformeNome);
                    readline = Console.ReadLine();
                    Pessoa ret = NegPessoa.RecuperarPeloNome(readline.ToUpper());

                    if (ret != null)
                    {
                        retorno = NegPessoa.MontaRetorno(ret);
                    }
                    else
                    {
                        retorno = MensagensPadrao.RegistroNaoEncontrado;
                    }

                }
                else
                {
                    var ret = NegPessoa.RecuperarLista();

                    if (ret != null)
                    {
                        retorno = NegPessoa.MontaRetorno(ret);
                    }
                    else
                    {
                        retorno = MensagensPadrao.RegistroNaoEncontrado;
                    }
                }
                #endregion
            }

            if (opcaomenu == Convert.ToInt32(OpecaoSelecionada.Insere))
            {
                #region InsertPessoa
                Pessoa pessoa = new Pessoa();

                readline = MensagensPadrao.StringEmBranco;
                while (readline == MensagensPadrao.StringEmBranco)
                {
                    Console.WriteLine(MensagensPadrao.InformeNome);
                    readline = Console.ReadLine();
                }
                pessoa.Nome = readline.ToUpper();

                readline = MensagensPadrao.StringEmBranco;
                while (readline == MensagensPadrao.StringEmBranco)
                {
                    Console.WriteLine(MensagensPadrao.InformeRg);
                    readline = Console.ReadLine();
                }
                pessoa.Rg = readline.ToUpper();


                readline = MensagensPadrao.StringEmBranco;
                while (readline == MensagensPadrao.StringEmBranco)
                {
                    Console.WriteLine(MensagensPadrao.InformeCpf);
                    readline = Console.ReadLine();
                }
                pessoa.Cpf = readline.ToUpper();

                readline = MensagensPadrao.StringEmBranco;
                while (readline == MensagensPadrao.StringEmBranco)
                {
                    Console.WriteLine(MensagensPadrao.InformeEmail);
                    readline = Console.ReadLine();
                }
                pessoa.Email = readline.ToUpper();

                readline = MensagensPadrao.StringEmBranco;
                while (readline == MensagensPadrao.StringEmBranco)
                {
                    Console.WriteLine(MensagensPadrao.InformeTelefone);
                    readline = Console.ReadLine();
                }
                pessoa.Telefone = readline.ToUpper();
                pessoa.FlAtivo = MensagensPadrao.FlAtivoS.ToUpper();

                int pessoaIdinserido = NegPessoa.Salvar(pessoa);

                if (pessoaIdinserido > 0)
                {
                    retorno = MensagensPadrao.InseridoOK;
                }
                else
                {
                    retorno = MensagensPadrao.InseridoNOK;
                }
                #endregion
            }

            if (opcaomenu == Convert.ToInt32(OpecaoSelecionada.Deleta))
            {
                #region DeletePessoa
                bool ret = false;
                readline = MensagensPadrao.StringEmBranco;
                while (readline == MensagensPadrao.StringEmBranco)
                {
                    Console.WriteLine(MensagensPadrao.InformeNome);
                    readline = Console.ReadLine();
                }

                ret = NegPessoa.ExcluirPeloNome(readline.ToUpper());

                if (ret)
                {
                    retorno = MensagensPadrao.DeleteOK;
                }
                else
                {
                    retorno = MensagensPadrao.RegistroNaoEncontrado;
                }
                #endregion
            }

            if (opcaomenu == Convert.ToInt32(OpecaoSelecionada.Sair))
            {
                #region Sair
                Environment.Exit(1);
                #endregion
            }

            Console.Write(retorno);
            Console.ReadKey();
            goto Inicio;
            #endregion
        }
    }
}
