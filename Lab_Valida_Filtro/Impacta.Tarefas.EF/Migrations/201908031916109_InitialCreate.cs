namespace Impacta.Tarefas.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Editora",
                c => new
                    {
                        EditoraId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.EditoraId);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        LivroId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Editora_EditoraId = c.Int(),
                    })
                .PrimaryKey(t => t.LivroId)
                .ForeignKey("dbo.Editora", t => t.Editora_EditoraId)
                .Index(t => t.Editora_EditoraId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livro", "Editora_EditoraId", "dbo.Editora");
            DropIndex("dbo.Livro", new[] { "Editora_EditoraId" });
            DropTable("dbo.Livro");
            DropTable("dbo.Editora");
        }
    }
}
