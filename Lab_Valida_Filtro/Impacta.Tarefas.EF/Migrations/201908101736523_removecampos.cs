namespace Impacta.Tarefas.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecampos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Endereco", "Cep", c => c.String(nullable: false));
            DropColumn("dbo.Editora", "Celular");
            DropColumn("dbo.Editora", "Url");
            DropColumn("dbo.Editora", "NumeroCelular");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Editora", "NumeroCelular", c => c.String());
            AddColumn("dbo.Editora", "Url", c => c.String());
            AddColumn("dbo.Editora", "Celular", c => c.String());
            AlterColumn("dbo.Endereco", "Cep", c => c.String());
        }
    }
}
