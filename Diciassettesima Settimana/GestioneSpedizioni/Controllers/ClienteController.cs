using GestioneSpedizioni.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestioneSpedizioni.Controllers
{
    public class ClienteController : Controller
    {
        private readonly string connectionString = "DefaultConnection";
        private readonly DatabaseManager dbManager;

        public ClienteController()
        {
            dbManager = new DatabaseManager(connectionString);
        }

        // Azione per visualizzare tutti i clienti
        public ActionResult Index()
        {
            string query = "SELECT * FROM Clienti";
            List<Cliente> clienti = dbManager.Query<Cliente>(query);
            return View(clienti);
        }

        // Azione per visualizzare dettagli di un cliente specifico
        public ActionResult Details(int id)
        {
            string query = "SELECT * FROM Clienti WHERE IDCliente = @ClienteID";
            var parameters = new Dictionary<string, object> { { "@ClienteID", id } };
            Cliente cliente = dbManager.QuerySingleOrDefault<Cliente>(query, parameters);
            return View(cliente);
        }

        // Azione per mostrare il form di creazione cliente
        public ActionResult Create()
        {
            return View();
        }

        // Azione per gestire la creazione di un nuovo cliente
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            string query = @"INSERT INTO Clienti (Nome, Cognome, CodiceFiscale, PartitaIVA) 
                         VALUES (@Nome, @Cognome, @CodiceFiscale, @PartitaIVA)";

            var parameters = new Dictionary<string, object>
        {
            { "@Nome", cliente.Nome },
            { "@Cognome", cliente.Cognome },
            { "@CodiceFiscale", cliente.CodiceFiscale },
            { "@PartitaIVA", cliente.PartitaIVA }
        };

            int rowsAffected = dbManager.ExecuteNonQuery(query, parameters);

            if (rowsAffected > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Gestire il caso di errore
                return View(cliente);
            }
        }

        // Azione per mostrare il form di modifica cliente
        public ActionResult Edit(int id)
        {
            string query = "SELECT * FROM Clienti WHERE IDCliente = @ClienteID";
            var parameters = new Dictionary<string, object> { { "@ClienteID", id } };
            Cliente cliente = dbManager.QuerySingleOrDefault<Cliente>(query, parameters);
            return View(cliente);
        }

        // Azione per gestire la modifica di un cliente esistente
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            string query = @"UPDATE Clienti 
                         SET Nome = @Nome, Cognome = @Cognome, CodiceFiscale = @CodiceFiscale, PartitaIVA = @PartitaIVA 
                         WHERE IDCliente = @IDCliente";

            var parameters = new Dictionary<string, object>
        {
            { "@Nome", cliente.Nome },
            { "@Cognome", cliente.Cognome },
            { "@CodiceFiscale", cliente.CodiceFiscale },
            { "@PartitaIVA", cliente.PartitaIVA },
            { "@IDCliente", cliente.IDCliente }
        };

            int rowsAffected = dbManager.ExecuteNonQuery(query, parameters);

            if (rowsAffected > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Gestire il caso di errore
                return View(cliente);
            }
        }

        // Azione per eliminare un cliente
        public ActionResult Delete(int id)
        {
            string query = "DELETE FROM Clienti WHERE IDCliente = @ClienteID";
            var parameters = new Dictionary<string, object> { { "@ClienteID", id } };
            int rowsAffected = dbManager.ExecuteNonQuery(query, parameters);

            if (rowsAffected > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Gestire il caso di errore
                return RedirectToAction("Index");
            }
        }
    }

}
