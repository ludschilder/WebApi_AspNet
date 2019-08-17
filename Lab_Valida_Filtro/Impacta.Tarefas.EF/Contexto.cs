using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//vamos adicionar o entity framework
using System.Data.Entity;
using Impacta.MOD;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Impacta.Tarefas.EF

{
	public class RealBooksContexto: DbContext
	{
		//public RealBooksContexto() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=RealBooks;Integrated Security=True;Pooling=False")
		public RealBooksContexto():base("name=RealBooksContext")
		{

		}

		//Para trabalhar com EF, você precisa de uma classe
		//para representar o seu BD que é nossa classe CONTEXTO
		//que dever herdar de DbCOntext
		//Todas as tabelas que vocÊ desejar trabalhar no Banco de Dados
		//devem ser mapeadas aqui no DBSt<>
		public DbSet<Editora> Editoras { get; set; }
		public DbSet<Livro> Livros { get; set; }


		//Por padrão do EF as entidades geradas no banco de dados 
		//utilizam o plural do InglÊs: Ex.: Livros -> Livroes


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
