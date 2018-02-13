using Cadastro_Funcionario;

namespace Cadastro_Motorista
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Motorista : Funcionario
    {
        public int MotoristaID { get; set; }
        public int FuncionarioID { get; set; }
        public int VeiculoID { get; set; }
    }
}
