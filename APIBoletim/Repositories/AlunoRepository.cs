using APIBoletim.Context;
using APIBoletim.Domains;
using APIBoletim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Repositories
{
    public class AlunoRepository : IAluno
    {
        //Chamamos a classe de conexao do banco
        BoletimContext conexao = new BoletimContext();

        //Chamamos o objeto que poderá receber e executar os comandos do banco 
        SqlCommand cmd = new SqlCommand();

        public Aluno Cadastrar(Aluno a)
        {
            //Abrir conexao
            cmd.Connection = conexao.Conectar();
            // Preparar a query 
            cmd.CommandText =
                           "INSERT INTO Aluno (Nome, RA, Idade) " +
                           "VALUES" +
                           "(@nome, @ra, @idade)";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.Ra);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            //Comando responsável por injetar dados no banco
            cmd.ExecuteNonQuery();

            //Fechar conexao
            conexao.Desconectar();

            return a;

        }




        /// <summary>
        /// Lê todos os dados de uma tabela de alunos
        /// </summary>
        /// <returns>Retorna os alunos em lista</returns>
        public List<Aluno> LerTodos()
        {
            //Abrir conexao
            cmd.Connection = conexao.Conectar();

            // Preparar a query (consulta)
            cmd.CommandText = "SELECT * FROM Aluno";

            SqlDataReader dados = cmd.ExecuteReader();

            //Criamos a lista para guardar os alunos
            List<Aluno> alunos = new List<Aluno>();
            while (dados.Read())
            {
                alunos.Add(
                    new Aluno()
                    {
                        IdAluno = Convert.ToInt32(dados.GetValue(0)),
                        Nome    = dados.GetValue(1).ToString(),
                        Ra      = dados.GetValue(2).ToString(),
                        Idade   = Convert.ToInt32(dados.GetValue(3)),
                    }
                );
            }
            
            //Fechar conexao
            conexao.Desconectar();
            return alunos;
        }





        /// <summary>
        /// Aplica o comando do sql server UPDATE em 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public Aluno Alterar(int id, Aluno a)
        {
            //Abrir conexao
            cmd.Connection = conexao.Conectar();
            // Preparar a query 
            cmd.CommandText =
                           "UPDATE Aluno SET " +
                           "Nome = @nome," +
                           "Ra = @ra," +
                           "Idade = @idade  WHERE IdAluno = @id";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.Ra);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            cmd.Parameters.AddWithValue("@id", id);


            //Comando responsável por injetar dados no banco
            cmd.ExecuteNonQuery();

            //Fechar conexao
            conexao.Desconectar();

            return a;
        }







        /// <summary>
        /// Realiza uma busca por um id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna os dados do id solicitado</returns>
        public Aluno BuscarPorId(int id)
        {
            //Abrir conexao
            cmd.Connection = conexao.Conectar();


            // Preparar a query 
            cmd.CommandText = "SELECT * FROM Aluno WHERE IdAluno = @id";
            // Atribuímos as variaveis que vêm como argumento
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();
            Aluno a = new Aluno();

            while (dados.Read())
            {
                a.IdAluno   = Convert.ToInt32(dados.GetValue(0));
                a.Nome      = dados.GetValue(1).ToString();
                a.Ra        = dados.GetValue(2).ToString();
                a.Idade     = Convert.ToInt32(dados.GetValue(3));
            }

            //Fechar conexao
            conexao.Desconectar();
            return a;
        }




        public void Excluir(int id)
        {
            //Abrir conexao
            cmd.Connection = conexao.Conectar();

            // Preparar a query 
            cmd.CommandText = ("DELETE FROM Aluno WHERE IdAluno = @id");
            cmd.Parameters.AddWithValue("@id", id);
            
            cmd.ExecuteNonQuery();

            //Fechar conexao
            conexao.Desconectar();
        }


    }
}
//DML ---> EXECUTENONQUERY