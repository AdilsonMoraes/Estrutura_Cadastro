using Cadastro_Veiculo.Negocio;
using FuncoesGenericas;
using System;

namespace Cadastro_Veiculo.UI
{
    public class ProgramVeiculo
    {
        enum OpecaoSelecionada { AnulaZero, Consulta, Insere, Deleta, Sair };

        public static void Main(string[] args)
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

            Console.Title = MensagensPadrao.TitleVeiculo;
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
                #region ConsultaVeiculo
                readline = MensagensPadrao.StringEmBranco;
                while (readline == MensagensPadrao.StringEmBranco)
                {
                    Console.WriteLine(MensagensPadrao.FormaDeConsultaVeiculo);
                    readline = Console.ReadLine();
                }

                if (readline.ToUpper() == "S")
                {
                    Console.WriteLine(MensagensPadrao.InformeModelo);
                    readline = Console.ReadLine();
                    Veiculo ret = negVeiculo.RecuperarPeloModelo(readline.ToUpper());

                    if (ret != null)
                    {
                        retorno = negVeiculo.MontaRetorno(ret);
                    }
                    else
                    {
                        retorno = MensagensPadrao.RegistroNaoEncontrado;
                    }

                }
                else
                {
                    var ret = negVeiculo.RecuperarLista();

                    if (ret != null)
                    {
                        retorno = negVeiculo.MontaRetorno(ret);
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
                #region InsertVeiculo
                Veiculo objveiculo = new Veiculo();

                readline = MensagensPadrao.StringEmBranco;
                while (readline == MensagensPadrao.StringEmBranco)
                {
                    Console.WriteLine(MensagensPadrao.InformeMarca);
                    readline = Console.ReadLine();
                }
                objveiculo.Marca = readline.ToUpper();

                readline = MensagensPadrao.StringEmBranco;
                while (readline == MensagensPadrao.StringEmBranco)
                {
                    Console.WriteLine(MensagensPadrao.InformeModelo);
                    readline = Console.ReadLine();
                }
                objveiculo.Modelo = readline.ToUpper();


                readline = MensagensPadrao.StringEmBranco;
                while (readline == MensagensPadrao.StringEmBranco)
                {
                    Console.WriteLine(MensagensPadrao.InformeCor);
                    readline = Console.ReadLine();
                }
                objveiculo.Cor = readline.ToUpper();

                readline = MensagensPadrao.StringEmBranco;
                while (readline == MensagensPadrao.StringEmBranco)
                {
                    Console.WriteLine(MensagensPadrao.InformePlaca);
                    readline = Console.ReadLine();
                }
                objveiculo.Placa = readline.ToUpper();

                readline = MensagensPadrao.StringEmBranco;
                while (readline == MensagensPadrao.StringEmBranco)
                {
                    Console.WriteLine(MensagensPadrao.InformeAnoModeloVeiculo);
                    readline = Console.ReadLine();
                }
                objveiculo.AnoModeloVeiculo = readline.ToUpper();
                objveiculo.FlAtivo = MensagensPadrao.FlAtivoS.ToUpper();

                int veiculoIdinserido = negVeiculo.Salvar(objveiculo);

                if (veiculoIdinserido > 0)
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
                #region DeleteVeiculo
                bool ret = false;
                readline = MensagensPadrao.StringEmBranco;
                while (readline == MensagensPadrao.StringEmBranco)
                {
                    Console.WriteLine(MensagensPadrao.InformeModelo);
                    readline = Console.ReadLine();
                }

                ret = negVeiculo.ExcluirPeloModelo(readline.ToUpper());

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
