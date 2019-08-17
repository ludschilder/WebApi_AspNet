namespace Impacta.Tarefas.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCelular : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                        Cep = c.String(),
                        Municipio = c.String(),
                        Uf = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Editora", "Cnpj", c => c.String(nullable: false));
            AddColumn("dbo.Editora", "Telefone", c => c.String());
            AddColumn("dbo.Editora", "Celular", c => c.String());
            AddColumn("dbo.Editora", "Endereco_Id", c => c.Int());
            AlterColumn("dbo.Editora", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Editora", "Email", c => c.String(nullable: false));
            CreateIndex("dbo.Editora", "Endereco_Id");
            AddForeignKey("dbo.Editora", "Endereco_Id", "dbo.Endereco", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Editora", "Endereco_Id", "dbo.Endereco");
            DropIndex("dbo.Editora", new[] { "Endereco_Id" });
            AlterColumn("dbo.Editora", "Email", c => c.String());
            AlterColumn("dbo.Editora", "Nome", c => c.String());
            DropColumn("dbo.Editora", "Endereco_Id");
            DropColumn("dbo.Editora", "Celular");
            DropColumn("dbo.Editora", "Telefone");
            DropColumn("dbo.Editora", "Cnpj");
            DropTable("dbo.Endereco");
        }
    }
}
