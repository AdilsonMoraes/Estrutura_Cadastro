using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }
        public string Cargo { get; set; }
        public string Nivel { get; set; }
        public double SalarioInicial { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataDemissao { get; set; }
        public bool FlAtivo { get; set; }
    }
}