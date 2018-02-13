using System;
using Cadastro_Pessoa.UI;
using Cadastro_Veiculo.UI;
using FuncoesGenericas;

namespace Principal
{
    class Program
    {
        enum OpecaoSelecionada { AnulaZero, CadPessoa, CadFunc, CadVeiculo, CadMotorista };

        static void Main(string[] args)
        {
            Show();
        }

        static void Show ()
        {
            string readline = MensagensPadrao.StringEmBranco;
            int opcaomenu = 0;

            Console.Title = MensagensPadrao.TitlePessoa;
            while (readline == MensagensPadrao.StringEmBranco)
            {
                #region MenuOpcoes
                Console.WriteLine(MensagensPadrao.MenuPrincipal);

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
            #endregion

            if (opcaomenu == Convert.ToInt32(OpecaoSelecionada.CadVeiculo))
            {
                ProgramVeiculo.Show();
            }

            if (opcaomenu == Convert.ToInt32(OpecaoSelecionada.CadPessoa))
            {
                ProgramPessoa.Show();
            }
            else
            {
                Console.WriteLine("Função ainda não desenvolvida!");
                Console.ReadKey();
            }
            
        }
    }
}
