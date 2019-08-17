using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Impacta.MOD;

namespace Impacta.Tarefas.DAL
{
	public class Data
	{
		//conexão
		SqlConnection sqlConn;

		//comando
		SqlCommand cmd;

		bool resultado;


		//string de conexão
		string conexao = @"Data Source = (localDB)\MSSQLLOCALDB;
						   Initial Catalog = Pessoal; 
						   Integrated Security = True;
						   Pooling=False";

		private bool CriarConexao()
		{
			bool criadoConexao = false;

			if (sqlConn == null)
			{
				//para criar o objeto de conexão precisamos de dados da conexão
				//endereço do server, isntânca, usuário e senha quando necessário
				sqlConn = new SqlConnection(conexao);

				criadoConexao = true;
			}

			return criadoConexao;
		}

		private void CriarComandoTarefa(string querySql, TarefaMOD objModelTarefa)
		{
			//o SQLCommand
			cmd = new SqlCommand();

			cmd.CommandText = querySql;
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.Parameters.AddWithValue("@Nome", objModelTarefa.Nome);
			cmd.Parameters.AddWithValue("@Prioridade", objModelTarefa.Prioridade);
			cmd.Parameters.AddWithValue("@Concluida", objModelTarefa.Concluida);
			cmd.Parameters.AddWithValue("Observacoes", objModelTarefa.Observacao);

			cmd.Connection = sqlConn;
		}

		public bool CriarTarefa(TarefaMOD tarefa)
		{
			resultado = false;

			try
			{
				string query =
					@"INSERT INTO TAREFAS(Nome, Prioridade, Concluida, Observacoes)
					  VALUES(@Nome, @Prioridade, @Concluida, @Observacoes)";

				if (CriarConexao())
				{
					CriarComandoTarefa(query, tarefa);

					sqlConn.Open();

					var ret = cmd.ExecuteNonQuery();

					resultado = true;
				}
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				if (sqlConn.State == System.Data.ConnectionState.Open)
				{
					sqlConn.Close();
				}
			}
			return resultado;

		}

		public List<TarefaMOD> ListarTarefas()
		{
			resultado = false;
			List<TarefaMOD> lista = new List<TarefaMOD>();

			try
			{
				if (CriarConexao())
				{
					string sql = @"SELECT  Id 
										  ,Nome
										  ,Prioridade
										  ,Concluida
										  ,Observacoes
									FROM  Tarefas
									ORDER BY Concluida, Prioridade";

					//bloco USING fecha automaticamente a comunicação com banco de dados
					using (var conn = sqlConn)
					{
						using (var cmd = new SqlCommand(sql, conn))
						{
							conn.Open();

							using (var dr = cmd.ExecuteReader())
							{
								//
								while (dr.Read())
								{
									var tarefa = new TarefaMOD();

									tarefa.Id = Convert.ToInt32(dr["Id"]);
									tarefa.Nome = Convert.ToString(dr["Nome"].ToString());
									tarefa.Prioridade = Convert.ToInt32(dr["Prioridade"]);
									tarefa.Concluida = Convert.ToBoolean(dr["Prioridade"]);
									tarefa.Observacao = Convert.ToString(dr["Observacoes"]);


									//adiciona na lista
									lista.Add(tarefa);
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				if (sqlConn.State == System.Data.ConnectionState.Open)
				{
					sqlConn.Close();
				}

			}
			return lista;
		}

		/// <summary>
		/// Consulta tarefa por Id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public TarefaMOD ConsultarTarefa(int Id)
		{
			TarefaMOD tarefa = new TarefaMOD();

			try
			{
				if (CriarConexao())
				{
					string sql = @"SELECT  Id 
										  ,Nome
										  ,Prioridade
										  ,Concluida
										  ,Observacoes
									FROM  Tarefas
									WHERE Id = @Id";

					//bloco USING fehca automaticamente a comunicação com o BD
					using (var conn = sqlConn)
					{
						using (var cmd = new SqlCommand(sql, conn))
						{
							cmd.Parameters.AddWithValue("@Id", Id);

							//abre conexão com o BD
							conn.Open();

							var res = cmd.ExecuteReader();

							if (res.HasRows && res.Read())
							{
								tarefa = new TarefaMOD()
								{
									Id = (int)res["Id"],
									Nome = res["Nome"].ToString(),
									Prioridade = (int)res["Prioridade"],
									Concluida = (bool)res["Concluida"],
									Observacao = res["Observacoes"].ToString()
								};
							}
						}
					}

				}
				return tarefa;
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}


		/// <summary>
		/// Atualiza tarefa por Id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public bool AtualizarTarefa(int Id, TarefaMOD tarefa)
		{
			//TarefaMOD tarefa = new TarefaMOD();
			bool retorno = false;

			try
			{
				if (CriarConexao())
				{

					string sql = @"UPDATE Tarefas
									SET    Nome        = @Nome       
										  ,Prioridade  = @Prioridade 
										  ,Concluida   = @Concluida  
										  ,Observacoes = @Observacoes
									WHERE Id = @Id";

					//bloco USING fehca automaticamente a comunicação com o BD
					using (var conn = sqlConn)
					{
						using (var cmd = new SqlCommand(sql, conn))
						{
							cmd.Parameters.AddWithValue("@Id", tarefa.Id);
							cmd.Parameters.AddWithValue("@Nome", tarefa.Nome);
							cmd.Parameters.AddWithValue("@Prioridade", tarefa.Prioridade);
							cmd.Parameters.AddWithValue("@Concluida", tarefa.Concluida);
							cmd.Parameters.AddWithValue("@Observacoes", tarefa.Observacao);

							//abre conexão com o BD
							conn.Open();

							retorno = cmd.ExecuteNonQuery() > 0 ? true : false;

						}
					}
				}

			}
			catch (Exception ex)
			{

				throw ex;
			}

			return retorno;

		}

		/// <summary>
		/// Deleta tarefa por Id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public bool ExcluirTarefa(int Id)
		{

			string sql = @"DELETE Tarefas WHERE Id = @Id";

			//TarefaMOD tarefa = new TarefaMOD();
			bool retorno = false;


			//bloco USING fehca automaticamente a comunicação com o BD
			using (var conn = new SqlConnection(conexao))
			{
				using (var cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@Id", Id);
			
					//abre conexão com o BD
					conn.Open();

					retorno = Convert.ToInt32(cmd.ExecuteNonQuery()) > 0 ? true : false;

				}
			}


			return retorno;

		}



		//public Data()
		//{
		//	//criar um objeto de conexão
		//	SqlConnection sqlConexao = new SqlConnection();

		//	//atribuindo os dados de conexão do BD
		//	sqlConexao.ConnectionString = conexao;

		//	//para executar algum comando no BD precisamos de um comando SQL
		//	string sql = "Select * from Tarefas";

		//	//para que o comando seja executado precisamos
		//	//criar um objeto COMMAND do SQL Client
		//	SqlCommand cmd = new SqlCommand();

		//	//configuramos o nosso comando a ser executado no BD
		//	cmd.CommandText = sql;
		//	cmd.Connection = sqlConexao;
		//	cmd.CommandType = System.Data.CommandType.Text;

		//	//para executar o comando no BD, precisamos abrir a conexão
		//	sqlConexao.Open();

		//	//se a conecão estiver aberta, executamos o comando
		//	if(sqlConexao.State == System.Data.ConnectionState.Open)
		//	{
		//		cmd.ExecuteNonQuery();

		//		//fechamos a conexão o quanto antes ,
		//		//ou seja logo após executar o comando
		//		sqlConexao.Close();

		//	}
		//}


	}
}
