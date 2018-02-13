namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimaryDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        FuncionarioID = c.Int(nullable: false, identity: true),
                        PessoaID = c.Int(nullable: false),
                        Cargo = c.String(),
                        Nivel = c.String(),
                        SalarioInicial = c.Double(nullable: false),
                        DataAdmissao = c.DateTime(nullable: false),
                        DataDemissao = c.DateTime(nullable: false),
                        FlAtivo = c.String(),
                    })
                .PrimaryKey(t => t.FuncionarioID);
            
            CreateTable(
                "dbo.Motorista",
                c => new
                    {
                        MotoristaID = c.Int(nullable: false, identity: true),
                        FuncionarioID = c.Int(nullable: false),
                        VeiculoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MotoristaID);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        PessoaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Rg = c.String(),
                        Cpf = c.String(),
                        Email = c.String(),
                        Telefone = c.String(),
                        FlAtivo = c.String(),
                    })
                .PrimaryKey(t => t.PessoaID);
            
            CreateTable(
                "dbo.Veiculo",
                c => new
                    {
                        VeiculoID = c.Int(nullable: false, identity: true),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Cor = c.String(),
                        Placa = c.String(),
                        AnoModeloVeiculo = c.String(),
                        FlAtivo = c.String(),
                    })
                .PrimaryKey(t => t.VeiculoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Veiculo");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Motorista");
            DropTable("dbo.Funcionario");
        }
    }
}
