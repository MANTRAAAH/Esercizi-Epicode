using GestioneSpedizioni.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging; // Assicurati di includere questo using
using System.Data.SqlTypes;
using System.Security.Claims;
using System.Threading.Tasks; // Aggiungi questo se usi async/await

namespace GestioneSpedizioni.Controllers
{
    public class SpedizioneController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DatabaseManager _dbManager;
        private readonly ILogger<SpedizioneController> _logger; // Aggiungi questo campo

        public SpedizioneController(DatabaseManager dbManager, ILogger<SpedizioneController> logger, IConfiguration configuration)
        {
            _dbManager = dbManager;
            _logger = logger; // Assegna il logger iniettato al campo
            _configuration = configuration;
        }

        // Action to display all shipments
        [Authorize(Roles = "Dipendente")]
        public IActionResult Index()
        {
            string query = "SELECT * FROM Spedizioni";
            List<Spedizione> spedizioni = _dbManager.Query<Spedizione>(query);
            return View(spedizioni);
        }

        // Action to display details of a specific shipment
        [Authorize]
        public IActionResult Details(int id)
        {
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            if (userRole != "User" && userRole != "Dipendente")
            {
                return Forbid(); // Unauthorized role handling
            }

            string spedizioneQuery = "SELECT * FROM Spedizioni WHERE Id = @SpedizioneID";
            var spedizioneParameters = new Dictionary<string, object> { { "@SpedizioneID", id } };
            Spedizione spedizione = _dbManager.QuerySingleOrDefault<Spedizione>(spedizioneQuery, spedizioneParameters);

            if (spedizione == null)
            {
                return NotFound(); // Handling case where shipment is not found
            }

            string aggiornamentiQuery = "SELECT * FROM AggiornamentiSpedizioni WHERE SpedizioneId = @SpedizioneID ORDER BY DataOraAggiornamento DESC";
            var aggiornamentiParameters = new Dictionary<string, object> { { "@SpedizioneID", id } };
            List<Aggiornamenti> aggiornamenti = _dbManager.Query<Aggiornamenti>(aggiornamentiQuery, aggiornamentiParameters);

            var model = new Tuple<Spedizione, List<Aggiornamenti>>(spedizione, aggiornamenti);

            return View(model);
        }

        // Action to handle the creation of a new shipment
        [Authorize(Roles = "Dipendente")]
        [HttpPost]
        public ActionResult Create(Spedizione spedizione)
        {
            // Validate and format dates
            if (!IsValidDate(spedizione.DataSpedizione) || !IsValidDate(spedizione.DataConsegnaPrevista))
            {
                ModelState.AddModelError("", "Dates must be valid and in dd/MM/yyyy format.");
                return View(spedizione);
            }

            string query = @"
INSERT INTO Spedizioni (NumeroSpedizione, DataSpedizione, Peso, CittaDestinataria, 
IndirizzoDestinatario, NominativoDestinatario, CostoSpedizione, DataConsegnaPrevista, ClienteId) 
VALUES (@NumeroSpedizione, @DataSpedizione, @Peso, @CittaDestinataria, @IndirizzoDestinatario, 
@NominativoDestinatario, @CostoSpedizione, @DataConsegnaPrevista, @ClienteId)";

            var parameters = new Dictionary<string, object>
    {
        { "@NumeroSpedizione", spedizione.NumeroSpedizione },
        { "@DataSpedizione", spedizione.DataSpedizione }, // Ensure this is a valid DateTime object
        { "@Peso", spedizione.Peso },
        { "@CittaDestinataria", spedizione.CittaDestinataria },
        { "@IndirizzoDestinatario", spedizione.IndirizzoDestinatario },
        { "@NominativoDestinatario", spedizione.NominativoDestinatario },
        { "@CostoSpedizione", spedizione.CostoSpedizione },
        { "@DataConsegnaPrevista", spedizione.DataConsegnaPrevista }, // Ensure this is a valid DateTime object
        { "@ClienteId", spedizione.ClienteId }
    };

            int rowsAffected = _dbManager.ExecuteNonQuery(query, parameters); // Ometti il parametro della transazione


            if (rowsAffected > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Error handling case
                return View(spedizione);
            }
        }
        [Authorize(Roles = "Dipendente")]
        public IActionResult Create()
        {
            // Crea un'istanza del modello Spedizione
            var model = new GestioneSpedizioni.Models.Spedizione();
            // Passa il modello alla view
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Dipendente")]
        public ActionResult Edit(SpedizioneEditViewModel spedizioneViewModel)
        {
            _logger.LogInformation("Inizio del processo di modifica per la spedizione con ID {SpedizioneId}", spedizioneViewModel.Id);

            if (ModelState.IsValid)
            {
                // Mappa SpedizioneEditViewModel a Spedizione
                var spedizione = new Spedizione
                {
                    Id = spedizioneViewModel.Id,
                    NumeroSpedizione = spedizioneViewModel.NumeroSpedizione,
                    DataSpedizione = spedizioneViewModel.DataSpedizione,
                    Peso = (decimal)spedizioneViewModel.Peso, // Assicurati che il casting sia appropriato
                    CittaDestinataria = spedizioneViewModel.CittaDestinataria,
                    IndirizzoDestinatario = spedizioneViewModel.IndirizzoDestinatario,
                    NominativoDestinatario = spedizioneViewModel.NominativoDestinatario,
                    CostoSpedizione = spedizioneViewModel.CostoSpedizione,
                    DataConsegnaPrevista = spedizioneViewModel.DataConsegnaPrevista,
                    // Mappa altre proprietà necessarie
                };

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
                    if (rowsAffected > 0)
                    {
                        _logger.LogInformation("La spedizione con ID {SpedizioneId} è stata aggiornata con successo.", spedizione.Id);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogWarning("Nessuna riga è stata modificata durante l'aggiornamento della spedizione con ID {SpedizioneId}.", spedizione.Id);
                        ModelState.AddModelError("", "Unable to update the shipment.");
                        return View(spedizioneViewModel); // Passa il ViewModel alla view in caso di errore
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Errore durante l'aggiornamento della spedizione con ID {SpedizioneId}.", spedizione.Id);
                    ModelState.AddModelError("", "An error occurred while updating the shipment.");
                    return View(spedizioneViewModel); // Passa il ViewModel alla view in caso di errore
                }
            }
            else
            {
                _logger.LogWarning("ModelState non valido per la spedizione con ID {SpedizioneId}. Dettagli degli errori:", spedizioneViewModel.Id);
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        _logger.LogWarning("{Field}: {ErrorMessage}", state.Key, error.ErrorMessage);
                    }
                }
                return View(spedizioneViewModel); // Passa il ViewModel alla view in caso di ModelState non valido
            }
        }

        [Authorize(Roles = "Dipendente")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Spedizione? spedizione = null; // Problema 2: dichiara spedizione come nullable
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); // Problema 1: ottiene la stringa di connessione
            string query = "SELECT * FROM Spedizioni WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    await connection.OpenAsync(); // Problema 4: usa await per mantenere l'asincronia
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            spedizione = new Spedizione
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                NumeroSpedizione = reader.GetString(reader.GetOrdinal("NumeroSpedizione")),
                                DataSpedizione = reader.GetDateTime(reader.GetOrdinal("DataSpedizione")),
                                Peso = reader.GetDecimal(reader.GetOrdinal("Peso")),
                                CittaDestinataria = reader.GetString(reader.GetOrdinal("CittaDestinataria")),
                                IndirizzoDestinatario = reader.GetString(reader.GetOrdinal("IndirizzoDestinatario")),
                                NominativoDestinatario = reader.GetString(reader.GetOrdinal("NominativoDestinatario")),
                                CostoSpedizione = reader.GetDecimal(reader.GetOrdinal("CostoSpedizione")),
                                DataConsegnaPrevista = reader.GetDateTime(reader.GetOrdinal("DataConsegnaPrevista")),
                                ClienteId = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                            };
                        }
                    }
                }
                catch (Exception ex) // Problema 3: usa la variabile ex
                {
                    _logger.LogError(ex, "Errore durante il recupero della spedizione con ID {SpedizioneId}", id); // Log dell'errore
                    return View("Error");
                }
            }

            if (spedizione == null)
            {
                return NotFound();
            }

            return View(spedizione);
        }


        // Method to normalize date to yyyy-MM-dd format
        private DateTime NormalizeDate(DateTime date)
        {
            // Ensure only date part is used
            return date.Date;
        }

        // Method to validate date format
        private bool IsValidDate(DateTime date)
        {
            // Assicurarsi che la data sia valida, nel formato corretto e non sia DateTime.MinValue
            return date > SqlDateTime.MinValue.Value && date <= SqlDateTime.MaxValue.Value;
        }

        [Authorize(Roles = "Dipendente")]
        public ActionResult Delete(int id)
        {
            _logger.LogInformation("Inizio del processo di cancellazione per la spedizione con ID {SpedizioneId}", id);

            // Ottiene la stringa di connessione dal campo _configuration
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Apri una connessione al database utilizzando la stringa di connessione ottenuta
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open(); // Assicurati che la connessione sia aperta prima di iniziare la transazione

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var command = connection.CreateCommand();
                        command.Transaction = transaction; // Associa la transazione al comando
                        command.CommandText = "SELECT COUNT(*) FROM AggiornamentiSpedizioni WHERE SpedizioneId = @SpedizioneID";
                        command.Parameters.AddWithValue("@SpedizioneID", id);

                        int count = (int)command.ExecuteScalar();

                        if (count == 0)
                        {
                            // Se non ci sono aggiornamenti pendenti, procedi con la cancellazione della spedizione
                            command.CommandText = "DELETE FROM Spedizioni WHERE Id = @SpedizioneID";
                            command.ExecuteNonQuery(); // Esegue la query di cancellazione
                            _logger.LogInformation("Spedizione con ID {SpedizioneId} eliminata con successo dalla tabella Spedizioni.", id);
                        }
                        else
                        {
                            // Gestisci il caso in cui ci sono aggiornamenti pendenti
                            _logger.LogWarning("Impossibile eliminare la spedizione con ID {SpedizioneId} poiché ci sono aggiornamenti pendenti.", id);
                            // Potresti voler annullare l'operazione o gestire gli aggiornamenti prima di procedere
                        }

                        // Completa la transazione
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Annulla la transazione in caso di errore
                        _logger.LogError(ex, "Si è verificato un errore imprevisto durante il tentativo di eliminare la spedizione con ID {SpedizioneId}", id);
                        // Gestione dell'errore...
                    }
                }
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Tracking()
        {
            return View();
        }

        [Authorize]
        public IActionResult Tracking(TrackingRequest request)
        {
            Spedizione spedizione = null;

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            string query = @"
SELECT s.* FROM [dbo].[Spedizioni] s
INNER JOIN [dbo].[Clienti] c ON s.ClienteId = c.IDCliente
WHERE s.NumeroSpedizione = @NumeroSpedizione AND c.CodiceFiscalePartitaIVA = @CodiceFiscalePartitaIVA";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NumeroSpedizione", request.NumeroSpedizione);
                command.Parameters.AddWithValue("@CodiceFiscalePartitaIVA", request.CodiceFiscalePartitaIVA ?? string.Empty);


                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Assumi che la tua classe Spedizione abbia queste proprietà e assegnale
                            spedizione = new Spedizione
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                // Assegna altre proprietà necessarie
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log dell'errore
                    _logger.LogError(ex, "Errore durante la ricerca della spedizione.");
                    ViewBag.ErrorMessage = "Si è verificato un errore durante la ricerca della spedizione.";
                    return View();
                }
            }

            if (spedizione == null)
            {
                ViewBag.ErrorMessage = "Spedizione non trovata.";
                return View();
            }

            // Reindirizza a una vista con i dettagli della spedizione o passa i dati direttamente
            return RedirectToAction("Details", new { id = spedizione.Id });
        }
        // Metodo per ottenere le spedizioni in consegna oggi
        public IActionResult SpedizioniInConsegnaOggi()
        {
            DateTime oggi = DateTime.Today;
            string query = @"
SELECT COUNT(*)
FROM Spedizioni
WHERE CAST(DataConsegnaPrevista AS DATE) = @Oggi";

            var parameters = new Dictionary<string, object>
    {
        { "@Oggi", oggi }
    };

            int count = (int)_dbManager.ExecuteScalar(query, parameters);

            if (count > 0)
            {
                // Se ci sono spedizioni in consegna oggi, si può fare una seconda query per ottenere i dettagli
                query = @"
SELECT *
FROM Spedizioni
WHERE CAST(DataConsegnaPrevista AS DATE) = @Oggi";

                List<Spedizione> spedizioniInConsegnaOggi = _dbManager.Query<Spedizione>(query, parameters);
                return View(spedizioniInConsegnaOggi);
            }
            else
            {
                // Se non ci sono spedizioni in consegna oggi, tornare una vista vuota o gestire di conseguenza
                return View(new List<Spedizione>()); // o qualsiasi altra gestione come Redirect, Error View, etc.
            }
        }


        // Metodo per ottenere il numero totale delle spedizioni in attesa di consegna
        public IActionResult NumeroSpedizioniInAttesaConsegna()
        {
            string query = @"
SELECT COUNT(*)
FROM Spedizioni
WHERE CAST(DataConsegnaPrevista AS DATE) > @Oggi";

            var parameters = new Dictionary<string, object>
    {
        { "@Oggi", DateTime.Today }
    };

            object result = _dbManager.ExecuteScalar(query, parameters);
            int numeroSpedizioniInAttesa = Convert.ToInt32(result);

            return Content(numeroSpedizioniInAttesa.ToString());
        }



        // Metodo per ottenere il numero totale delle spedizioni raggruppate per città destinataria
        public IActionResult SpedizioniPerCittaDestinataria()
        {
            string query = @"
SELECT CittaDestinataria AS Citta, COUNT(*) AS NumeroSpedizioni
FROM Spedizioni
GROUP BY CittaDestinataria";

            List<SpedizioniPerCittaViewModel> spedizioniPerCitta = _dbManager.Query<SpedizioniPerCittaViewModel>(query);
            return View(spedizioniPerCitta);
        }







    }

}

