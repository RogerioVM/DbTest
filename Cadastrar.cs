using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BdSozinho
{
    class Cadastrar
    {
        SqlCommand comando = new SqlCommand();
        Conexao conexao = new Conexao();
        public string mensagem;

        public Cadastrar(string nome, string telefone)
        {
            comando.CommandText = "INSERT INTO teste (nome,telefone) VALUES (@nome,@telefone)";
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@telefone", telefone);

            try
            {
                comando.Connection = conexao.conectar();

                comando.ExecuteNonQuery();

                conexao.desconectar();

                mensagem = "Cadastrado com sucesso!";
            }
            catch (SqlException)
            {
                mensagem = "Não foi possível conecatr-se";
            }
        }
    }
}
