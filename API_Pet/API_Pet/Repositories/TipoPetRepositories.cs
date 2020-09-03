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
    public class TipoPetRepositories : ITipoPet
    {
        TipoPetContext conexao = new TipoPetContext();

        SqlCommand cmd = new SqlCommand();

        public TipoPet Alterar(int id,TipoPet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE tipopet SET " +
                "Descricao = @descricao WHERE IdTipoPet = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return a;
        }

        public TipoPet BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM tipopet WHERE IdTipoPet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoPet pets = new TipoPet();

            while (dados.Read())
            {

                pets.Id = Convert.ToInt32(dados.GetValue(0));
                pets.Descricao = dados.GetValue(1).ToString();
                   
            }

            conexao.Desconectar();

            return pets;




        }

        public TipoPet Cadastrar(TipoPet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO tipopet" + "(Descricao) " +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.ExecuteNonQuery();
           

            
            conexao.Desconectar();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "Delete FROM tipopet WHERE IdTipoPet = @id ";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<TipoPet> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM tipopet";

            SqlDataReader dados = cmd.ExecuteReader();

            List<TipoPet> pets = new List<TipoPet>();

            while(dados.Read())
            {
                pets.Add(
                    new TipoPet()
                    {
                        Id = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString()
                    }
                    );
            }

            conexao.Desconectar();

            return pets;

            
        }
    }
}
