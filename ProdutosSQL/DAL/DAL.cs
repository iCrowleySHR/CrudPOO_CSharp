using System;
using System.Linq;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace ProdutosSQL.DAL
{
    internal class DAL
    {
        private readonly Conexao conexao;

        public DAL(Conexao conexao)
        {
            this.conexao = conexao;
        }

        public void Inserir<T>(T entidade)
        {
            Type tipo = typeof(T);
            string nomeTabela = tipo.Name.ToLower();
            var propriedades = tipo.GetProperties()
                .Where(p => !p.Name.Equals("Id", StringComparison.OrdinalIgnoreCase)
                         && !p.Name.StartsWith("Id", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            string colunas = string.Join(", ", propriedades.Select(p => p.Name.ToLower()));
            string parametros = string.Join(", ", propriedades.Select(p => "@" + p.Name.ToLower()));
            string sql = $"INSERT INTO {nomeTabela} ({colunas}) VALUES ({parametros})";

            using (var conn = conexao.AbrirConexao())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                foreach (var prop in propriedades)
                {
                    object valor = prop.GetValue(entidade) ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@" + prop.Name.ToLower(), valor);
                }

                cmd.ExecuteNonQuery();
                conexao.FecharConexao();
            }
        }
    }
}
