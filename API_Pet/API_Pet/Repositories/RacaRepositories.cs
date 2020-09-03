using API_Pet.Context;
using API_Pet.Domains;
using API_Pet.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pet.Repositories
{
    public class RacaRepositories : IRaca
    {
        TipoPetContext conexao = new TipoPetContext();

        SqlCommand cmd = new SqlCommand();

        public Raca Alterar(int id, Raca a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE raca SET " +
                "Descricao = @descricao, " +
                "IdTipoPet = @idFK" +
                " WHERE IdTipoPet = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);
            cmd.Parameters.AddWithValue("@idFK", a.IdFK);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return a;
        }

        public Raca BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM raca WHERE IdTipoPet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca racas = new Raca();

            while(dados.Read())
            {
                racas.Id = Convert.ToInt32(dados.GetValue(0));
                racas.Descricao = dados.GetValue(1).ToString();
                racas.IdFK = Convert.ToInt32(dados.GetValue(2));
            }

            conexao.Desconectar();

            return racas;
            
        }

        public Raca Cadastrar(Raca a, int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO raca" + "(Descricao, IdTipoPet) " +
                "VALUES" +
                "(@descricao, @IdFK)";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);
            cmd.Parameters.AddWithValue("@idFK", a.IdFK);

            cmd.ExecuteNonQuery();



            conexao.Desconectar();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "Delete FROM raca WHERE IdRaca = @id ";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<Raca> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM raca";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Raca> racas = new List<Raca>();

            while (dados.Read())
            {
                racas.Add(
                    new Raca()
                    {
                        Id = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                        IdFK = Convert.ToInt32(dados.GetValue(2))
                    }
                    );
            }

            conexao.Desconectar();

            return racas;
        }
    }
}
