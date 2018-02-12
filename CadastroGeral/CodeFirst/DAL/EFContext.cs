using CodeFirst.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace CodeFirst.DAL
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Cadastro_Geral") { }

        //Romove a convenção para nao ficar pluralizando as tabelas na criação
        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Motorista> Motorista { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
    }
}