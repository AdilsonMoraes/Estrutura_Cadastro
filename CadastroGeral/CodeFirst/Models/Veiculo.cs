using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Veiculo
    {
        public int VeiculoID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string AnoModeloVeiculo { get; set; }
        public string FlAtivo { get; set; }
    }
}