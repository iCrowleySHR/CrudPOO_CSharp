using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
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
                .Where(p => !p.Name.StartsWith("Id", StringComparison.OrdinalIgnoreCase))
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
            }
        }

        public List<T> Ler<T>() where T : new()
        {
            List<T> lista = new List<T>();
            Type tipo = typeof(T);
            string nomeTabela = tipo.Name.ToLower();

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
            }

            return lista;
        }

        public void Editar<T>(T entidade)
        {
            Type tipo = typeof(T);
            string nomeTabela = tipo.Name.ToLower();

            var propriedades = tipo.GetProperties()
                .Where(p => !p.Name.StartsWith("Id", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            var propId = tipo.GetProperties().FirstOrDefault(p => p.Name.StartsWith("Id", StringComparison.OrdinalIgnoreCase));

            if (propId == null)
                throw new Exception("A entidade precisa ter uma propriedade de ID.");

            string setClause = string.Join(", ", propriedades.Select(p => $"{p.Name.ToLower()} = @{p.Name.ToLower()}"));
            string sql = $"UPDATE {nomeTabela} SET {setClause} WHERE {propId.Name.ToLower()} = @{propId.Name.ToLower()}";

            using (var conn = conexao.AbrirConexao())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                foreach (var prop in propriedades)
                {
                    object valor = prop.GetValue(entidade) ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@" + prop.Name.ToLower(), valor);
                }

                object valorId = propId.GetValue(entidade);
                cmd.Parameters.AddWithValue("@" + propId.Name.ToLower(), valorId);

                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir<T>(int id)
        {
            Type tipo = typeof(T);
            string nomeTabela = tipo.Name.ToLower();

            var propId = tipo.GetProperties().FirstOrDefault(p => p.Name.StartsWith("Id", StringComparison.OrdinalIgnoreCase));
            if (propId == null)
                throw new Exception("A entidade precisa ter uma propriedade de ID.");

            string sql = $"DELETE FROM {nomeTabela} WHERE {propId.Name.ToLower()} = @id";

            using (var conn = conexao.AbrirConexao())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
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
