namespace Impacta.Tarefas.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumeroCelular : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Editora", "Url", c => c.String());
            AddColumn("dbo.Editora", "NumeroCelular", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Editora", "NumeroCelular");
            DropColumn("dbo.Editora", "Url");
        }
    }
}
