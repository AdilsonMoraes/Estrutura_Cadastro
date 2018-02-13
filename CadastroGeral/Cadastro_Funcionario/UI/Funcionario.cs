using Cadastro_Pessoa;
using System;

namespace Cadastro_Funcionario
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Funcionario : Pessoa
    {
        public int FuncionarioID { get; set; }
        public string Cargo { get; set; }
        public int CodNivel { get; set; }
        public string Nivel { get; set; }
        public double SalarioInicial { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataDemissao { get; set; }
        public string FlFuncAtivo { get; set; }
    }

    public abstract class Salario : Funcionario
    {
        public abstract void CalcularSalario();
        public abstract void CalcularDissidio();
        public abstract void CalcularBonus();
        public abstract void RetornaNivel();
    }
}
