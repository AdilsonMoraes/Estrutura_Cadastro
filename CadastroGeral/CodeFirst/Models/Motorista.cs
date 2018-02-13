using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Motorista
    {
        public int MotoristaID { get; set; }
        public int FuncionarioID { get; set; }
        public int VeiculoID { get; set; }
    }
}