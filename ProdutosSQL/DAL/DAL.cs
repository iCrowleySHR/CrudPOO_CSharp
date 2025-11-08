using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            string nomeTabela = tipo.Name;
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

        public List<T> Ler<T>() where T : new()
        {
            List<T> lista = new List<T>();
            Type tipo = typeof(T);
            string nomeTabela = tipo.Name;

            string sql = $"SELECT * FROM {nomeTabela}";

            using (var conn = conexao.AbrirConexao())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                var propriedades = tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                while (reader.Read())
                {
                    T instancia = new T();

                    foreach (var prop in propriedades)
                    {
                        string nomeColuna = prop.Name.ToLower();

                        if (!reader.HasColumn(nomeColuna))
                            continue;

                        object valor = reader[nomeColuna];

                        if (valor != DBNull.Value)
                            prop.SetValue(instancia, Convert.ChangeType(valor, prop.PropertyType));
                    }

                    lista.Add(instancia);
                }

                conexao.FecharConexao();
            }

            return lista;
        }
    }

        internal static class MySqlDataReaderExtensions
        {
            public static bool HasColumn(this MySqlDataReader reader, string columnName)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                        return true;
                }
                return false;
            }
        }

}
