using CodeFirst.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace CodeFirst.DAL
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Cadastro_Funcionario") { }

        //Romove a convenção para nao ficar pluralizando as tabelas na criação
        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pessoa> Cad_Pessoas { get; set; }
        public DbSet<Funcionario> Cad_Funcionario { get; set; }
        public DbSet<Funcionario> Cad_Motorista { get; set; }
        public DbSet<Funcionario> Cad_Veiculo { get; set; }

    }
}