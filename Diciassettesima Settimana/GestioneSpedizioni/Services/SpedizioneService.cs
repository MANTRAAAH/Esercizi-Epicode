using GestioneSpedizioni.Models;
using Microsoft.Data.SqlClient;

namespace GestioneSpedizioni.Services
{
    public class SpedizioneService : ISpedizioneService
    {
        private readonly DatabaseManager _dbManager;
        private readonly ILogger<SpedizioneService> _logger;

        public SpedizioneService(DatabaseManager dbManager, ILogger<SpedizioneService> logger)
        {
            _dbManager = dbManager;
            _logger = logger;
        }

        public async Task<List<Spedizione>> GetAllSpedizioniAsync()
        {
            string query = "SELECT * FROM Spedizioni";
            return await Task.FromResult(_dbManager.Query<Spedizione>(query));
        }

        public async Task<Spedizione> GetSpedizioneByIdAsync(int id)
        {
            string query = "SELECT * FROM Spedizioni WHERE Id = @SpedizioneID";
            var parameters = new Dictionary<string, object> { { "@SpedizioneID", id } };
            return await Task.FromResult(_dbManager.QuerySingleOrDefault<Spedizione>(query, parameters));
        }

        public async Task<bool> CreateSpedizioneAsync(Spedizione spedizione)
        {
            string query = @"
INSERT INTO Spedizioni (NumeroSpedizione, DataSpedizione, Peso, CittaDestinataria, 
                        IndirizzoDestinatario, NominativoDestinatario, CostoSpedizione, DataConsegnaPrevista, ClienteId) 
VALUES (@NumeroSpedizione, @DataSpedizione, @Peso, @CittaDestinataria, @IndirizzoDestinatario, 
        @NominativoDestinatario, @CostoSpedizione, @DataConsegnaPrevista, @ClienteId)";

            var parameters = new Dictionary<string, object>
        {
            { "@NumeroSpedizione", spedizione.NumeroSpedizione },
            { "@DataSpedizione", spedizione.DataSpedizione },
            { "@Peso", spedizione.Peso },
            { "@CittaDestinataria", spedizione.CittaDestinataria },
            { "@IndirizzoDestinatario", spedizione.IndirizzoDestinatario },
            { "@NominativoDestinatario", spedizione.NominativoDestinatario },
            { "@CostoSpedizione", spedizione.CostoSpedizione },
            { "@DataConsegnaPrevista", spedizione.DataConsegnaPrevista },
            { "@ClienteId", spedizione.ClienteId }
        };

            try
            {
                int rowsAffected = _dbManager.ExecuteNonQuery(query, parameters);
                return await Task.FromResult(rowsAffected > 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione della spedizione.");
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateSpedizioneAsync(Spedizione spedizione)
        {
            string query = @"
UPDATE Spedizioni SET 
    NumeroSpedizione = @NumeroSpedizione, 
    DataSpedizione = @DataSpedizione, 
    Peso = @Peso, 
    CittaDestinataria = @CittaDestinataria, 
    IndirizzoDestinatario = @IndirizzoDestinatario, 
    NominativoDestinatario = @NominativoDestinatario, 
    CostoSpedizione = @CostoSpedizione, 
    DataConsegnaPrevista = @DataConsegnaPrevista
WHERE Id = @Id";

            var parameters = new Dictionary<string, object>
        {
            { "@NumeroSpedizione", spedizione.NumeroSpedizione },
            { "@DataSpedizione", spedizione.DataSpedizione },
            { "@Peso", spedizione.Peso },
            { "@CittaDestinataria", spedizione.CittaDestinataria },
            { "@IndirizzoDestinatario", spedizione.IndirizzoDestinatario },
            { "@NominativoDestinatario", spedizione.NominativoDestinatario },
            { "@CostoSpedizione", spedizione.CostoSpedizione },
            { "@DataConsegnaPrevista", spedizione.DataConsegnaPrevista },
            { "@Id", spedizione.Id }
        };

            try
            {
                int rowsAffected = _dbManager.ExecuteNonQuery(query, parameters);
                return await Task.FromResult(rowsAffected > 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante l'aggiornamento della spedizione con ID {SpedizioneId}.", spedizione.Id);
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteSpedizioneAsync(int id)
        {
            // Ottieni la stringa di connessione direttamente da _dbManager
            string connectionString = _dbManager.connectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync(); // Aprire la connessione asincronamente

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var command = connection.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandText = "SELECT COUNT(*) FROM AggiornamentiSpedizioni WHERE SpedizioneId = @SpedizioneID";
                        command.Parameters.AddWithValue("@SpedizioneID", id);

                        int count = (int)await command.ExecuteScalarAsync();

                        if (count == 0)
                        {
                            command.CommandText = "DELETE FROM Spedizioni WHERE Id = @SpedizioneID";
                            command.Parameters.Clear(); // Pulire i parametri precedenti
                            command.Parameters.AddWithValue("@SpedizioneID", id);
                            await command.ExecuteNonQueryAsync();

                            _logger.LogInformation("Spedizione con ID {SpedizioneId} eliminata con successo dalla tabella Spedizioni.", id);
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            _logger.LogWarning("Impossibile eliminare la spedizione con ID {SpedizioneId} poiché ci sono aggiornamenti pendenti.", id);
                            transaction.Rollback();
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Errore durante il tentativo di eliminare la spedizione con ID {SpedizioneId}", id);
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }




        public async Task<List<Aggiornamenti>> GetAggiornamentiBySpedizioneIdAsync(int spedizioneId)
        {
            string query = "SELECT * FROM AggiornamentiSpedizioni WHERE SpedizioneId = @SpedizioneID";
            var parameters = new Dictionary<string, object> { { "@SpedizioneID", spedizioneId } };
            return await Task.FromResult(_dbManager.Query<Aggiornamenti>(query, parameters));
        }

        public async Task<Spedizione> GetSpedizioneByTrackingRequestAsync(TrackingRequest request)
        {
            string query = @"
SELECT s.* FROM [dbo].[Spedizioni] s
INNER JOIN [dbo].[Clienti] c ON s.ClienteId = c.IDCliente
WHERE s.NumeroSpedizione = @NumeroSpedizione AND c.CodiceFiscalePartitaIVA = @CodiceFiscalePartitaIVA";


            var parameters = new Dictionary<string, object>
        {
            { "@Nome", request.NumeroSpedizione },
            { "@CodiceFiscalePartitaIVA", request.CodiceFiscalePartitaIVA ?? string.Empty }
        };

            try
            {
                return await Task.FromResult(_dbManager.QuerySingleOrDefault<Spedizione>(query, parameters));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la ricerca della spedizione.");
                return await Task.FromResult<Spedizione>(null);
            }
        }

        public async Task<List<Spedizione>> GetSpedizioniInConsegnaOggiAsync()
        {
            DateTime oggi = DateTime.Today;
            string query = "SELECT * FROM Spedizioni WHERE CAST(DataConsegnaPrevista AS DATE) = @Oggi";

            var parameters = new Dictionary<string, object>
        {
            { "@Oggi", oggi }
        };

            return await Task.FromResult(_dbManager.Query<Spedizione>(query, parameters));
        }

        public async Task<int> GetNumeroSpedizioniInAttesaConsegnaAsync()
        {
            DateTime oggi = DateTime.Today;
            string query = "SELECT COUNT(*) FROM Spedizioni WHERE CAST(DataConsegnaPrevista AS DATE) > @Oggi";

            var parameters = new Dictionary<string, object>
    {
        { "@Oggi", oggi }
    };

            try
            {
                object result = _dbManager.ExecuteScalar(query, parameters);
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    // Gestire il caso in cui ExecuteScalar restituisce null o DBNull.Value
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il conteggio delle spedizioni in attesa di consegna.");
                throw; // Puoi decidere se gestire l'eccezione qui o lasciarla propagare
            }
        }


        public async Task<List<SpedizioniPerCittaViewModel>> GetSpedizioniPerCittaDestinatariaAsync()
        {
            string query = @"
SELECT CittaDestinataria AS Citta, COUNT(*) AS NumeroSpedizioni
FROM Spedizioni
GROUP BY CittaDestinataria";

            return await Task.FromResult(_dbManager.Query<SpedizioniPerCittaViewModel>(query));
        }
    }

}
