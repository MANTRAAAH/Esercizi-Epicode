using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GestioneSpedizioni.Models
{
    public class DatabaseManager
    {
        private readonly string connectionString;

        public DatabaseManager(string connectionString)
        {
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public IDbTransaction BeginTransaction()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection.BeginTransaction();
        }

        public T QuerySingleOrDefault<T>(string query, Dictionary<string, object> parameters = null) where T : new()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        T result = default(T);

                        if (reader.Read())
                        {
                            result = PopulateFromReader<T>(reader);
                        }

                        return result;
                    }
                }
            }
        }

        public List<T> Query<T>(string query, Dictionary<string, object> parameters = null) where T : new()
        {
            List<T> results = new List<T>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(PopulateFromReader<T>(reader));
                        }
                    }
                }
            }

            return results;
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters, IDbTransaction transaction = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (transaction != null)
                    {
                        command.Transaction = (SqlTransaction)transaction;
                    }
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    return command.ExecuteNonQuery();
                }
            }
        }
        public async Task<Spedizione?> GetSpedizioneByIdAsync(int id)
        {
            Spedizione? spedizione = null;

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM Spedizioni WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            spedizione = new Spedizione
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                NumeroSpedizione = reader.IsDBNull(reader.GetOrdinal("NumeroSpedizione")) ? null : reader.GetString(reader.GetOrdinal("NumeroSpedizione")),
                                DataSpedizione = reader.GetDateTime(reader.GetOrdinal("DataSpedizione")),
                                Peso = reader.GetDecimal(reader.GetOrdinal("Peso")),
                                CittaDestinataria = reader.IsDBNull(reader.GetOrdinal("CittaDestinataria")) ? null : reader.GetString(reader.GetOrdinal("CittaDestinataria")),
                                IndirizzoDestinatario = reader.IsDBNull(reader.GetOrdinal("IndirizzoDestinatario")) ? null : reader.GetString(reader.GetOrdinal("IndirizzoDestinatario")),
                                NominativoDestinatario = reader.IsDBNull(reader.GetOrdinal("NominativoDestinatario")) ? null : reader.GetString(reader.GetOrdinal("NominativoDestinatario")),
                                CostoSpedizione = reader.GetDecimal(reader.GetOrdinal("CostoSpedizione")),
                                DataConsegnaPrevista = reader.GetDateTime(reader.GetOrdinal("DataConsegnaPrevista"))
                            };
                        }
                    }
                }
            }

            return spedizione;
        }
        public SqlCommand CreateCommand(string query, Dictionary<string, object> parameters)
        {
            // Crea una nuova connessione al database
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(query, connection);

            // Aggiunge i parametri al comando
            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value ?? DBNull.Value);
            }

            return command;
        }

        public async Task<List<Aggiornamenti>> GetAggiornamentiBySpedizioneIdAsync(int spedizioneId)
        {
            var aggiornamenti = new List<Aggiornamenti>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM AggiornamentiSpedizioni WHERE SpedizioneId = @SpedizioneId ORDER BY DataOraAggiornamento DESC", connection))
                {
                    command.Parameters.AddWithValue("@SpedizioneId", spedizioneId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var aggiornamento = new Aggiornamenti
                            {
                                Stato = reader.GetString(reader.GetOrdinal("Stato")),
                                Luogo = reader.IsDBNull(reader.GetOrdinal("Luogo")) ? null : reader.GetString(reader.GetOrdinal("Luogo")),
                                Descrizione = reader.IsDBNull(reader.GetOrdinal("Descrizione")) ? null : reader.GetString(reader.GetOrdinal("Descrizione")),
                                DataOraAggiornamento = reader.GetDateTime(reader.GetOrdinal("DataOraAggiornamento")),
                                SpedizioneId = reader.GetInt32(reader.GetOrdinal("SpedizioneId"))
                            };

                            aggiornamenti.Add(aggiornamento);
                        }
                    }
                }
            }

            return aggiornamenti;
        }
        public void AggiungiAggiornamento(Aggiornamenti aggiornamento)
        {
            // Implementazione del metodo per inserire un nuovo aggiornamento nel database
            // Questo è solo un esempio e dovrai adattarlo al tuo specifico database e modello di dati
            string query = @"
INSERT INTO AggiornamentiSpedizioni (SpedizioneId, DataOraAggiornamento, Stato, Luogo, Descrizione) 
VALUES (@SpedizioneId, @DataOraAggiornamento, @Stato, @Luogo, @Descrizione)";

            var parameters = new Dictionary<string, object>
        {
            { "@SpedizioneId", aggiornamento.SpedizioneId },
            { "@DataOraAggiornamento", aggiornamento.DataOraAggiornamento },
            { "@Stato", aggiornamento.Stato },
            { "@Luogo", aggiornamento.Luogo },
            { "@Descrizione", aggiornamento.Descrizione }
        };

            // Assumi che ExecuteNonQuery sia un metodo esistente per eseguire comandi SQL non di query
            ExecuteNonQuery(query, parameters);
        }


        public object ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    return command.ExecuteScalar();
                }
            }
        }

        private T PopulateFromReader<T>(SqlDataReader reader) where T : new()
        {
            var obj = new T();
            var properties = typeof(T).GetProperties();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);
                var prop = properties.FirstOrDefault(p => p.Name.Equals(columnName, StringComparison.InvariantCultureIgnoreCase));

                if (prop != null && !reader.IsDBNull(i))
                {
                    prop.SetValue(obj, reader.GetValue(i));
                }
            }

            return obj;
        }
    }

}
