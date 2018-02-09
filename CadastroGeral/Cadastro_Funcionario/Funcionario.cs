﻿using Cadastro_Pessoa;
using System;

namespace Cadastro_Funcionario
{
    public class Funcionario : Pessoa
    {
        public int FuncionarioID { get; set; }
        public string Cargo { get; set; }
        public string Nivel { get; set; }
        public double SalarioInicial { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataDemissao { get; set; }
        public bool FlAtivo { get; set; }
    }

    public abstract class Salario : Funcionario
    {
        public abstract void CalcularSalario();
        public abstract void CalcularDissidio();
        public abstract void CalcularBonus();
        public abstract void RetornaNivel();
    }
}
