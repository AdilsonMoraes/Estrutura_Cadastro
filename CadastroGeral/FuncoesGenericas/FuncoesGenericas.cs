﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncoesGenericas
{

    public class Funcoes
    {
        public static int SubtrairData(DateTime pData)
        {
            DateTime dt2 = DateTime.Now;
            return (dt2 - pData).Days;
        }

        public static int TempoDeCasaEmAnos(DateTime pData)
        {
            return (SubtrairData(pData) / 365);
        }

        //Dissídio anual
        //
        public static double CalculaDissidio(int pTempoDeCasaEmAnos, double pSalarioInicial)
        {
            for (int i = 1; i <= pTempoDeCasaEmAnos; i++)
            {
                pSalarioInicial = Math.Round(pSalarioInicial + (pSalarioInicial * 0.05), 2);
            }

            return pSalarioInicial;
        }

        public static bool ValidaNumero(string pString)
        {
            double Num;
            return double.TryParse(pString, out Num); ;
        }

        public static string MenuValido(string pString)
        {
            string ErrMsg = MensagensPadrao.StringEmBranco;

            if (ValidaNumero(pString) == false)
            {
                ErrMsg = MensagensPadrao.Errodigitacao;
            }
            else
            {
                if (Convert.ToInt32(pString) > 4)
                {
                    ErrMsg = MensagensPadrao.OpcaoInvalida;

                }
            }

            return ErrMsg;
        }

    }
}
