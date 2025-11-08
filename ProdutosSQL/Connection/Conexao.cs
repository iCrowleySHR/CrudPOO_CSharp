using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ProdutosSQL
{
    internal class Conexao
    {
        private readonly string connectionString = "Server=localhost;Database=controle_produtos;Uid=root;Pwd=;";

        private MySqlConnection connection;

        public Conexao()
        {
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection AbrirConexao()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
