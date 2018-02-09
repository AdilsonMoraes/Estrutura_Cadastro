using CodeFirst.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace CodeFirst.DAL
{
    public class EFContext : DbContext
    {
        public EFContext() : base("") { }

        //Romove a convenção para nao ficar pluralizando as tabelas na criação
        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }


        //Quero que seja criado um banco com o nome de Cadastro_Geral
        
        /*Quero que as tabelas sejam criadas no padrão abaixo.
        Cad_Pessoas, Cad_Funcionario, Cad_Motorista, Cad_Veiculo*/
        
    }
}