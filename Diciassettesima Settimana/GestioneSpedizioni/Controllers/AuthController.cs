﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using GestioneSpedizioni.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

public class AuthController : Controller
{
    private readonly DatabaseManager _dbManager;

    public AuthController(DatabaseManager dbManager)
    {
        _dbManager = dbManager;
    }

    // GET: /Auth/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: /Auth/Register
    [HttpPost]
    public async Task<IActionResult> Register(UserRegistrationViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Verifica se l'utente esiste già
            if (UserExists(model.Username))
            {
                ModelState.AddModelError(string.Empty, "Username già in uso.");
                return View(model);
            }

            // Salva l'utente nel database con il ruolo "User" di default
            string query = @"INSERT INTO Users (Username, Password, Role) 
                             VALUES (@Username, @Password, @Role)";

            var parameters = new Dictionary<string, object>
            {
                { "@Username", model.Username },
                { "@Password", model.Password },
                { "@Role", "User" } // Ruolo di default
            };

            int rowsAffected = _dbManager.ExecuteNonQuery(query, parameters);

            if (rowsAffected > 0)
            {
                // Effettua il login automaticamente dopo la registrazione
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Role, "User")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Errore durante la registrazione.");
                return View(model);
            }
        }

        return View(model);
    }

    // GET: /Auth/Login
    public IActionResult Login()
    {
        return View();
    }

    // POST: /Auth/Login
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Verifica le credenziali dell'utente
            if (VerifyCredentials(model.Username, model.Password))
            {
                // Ottieni il ruolo dell'utente dal database
                string role = GetUserRoleFromDatabase(model.Username);

                // Creazione delle claims per l'utente autenticato
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Role, role) // Aggiungi il ruolo come claim
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Esegui il login
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Redirigi in base al ruolo
                if (role == "Dipendente")
                {
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Credenziali non valide.");
                return View(model);
            }
        }

        return View(model);
    }

    // GET: /Auth/Logout
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    // Verifica se l'utente esiste già nel database
    private bool UserExists(string username)
    {
        string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
        var parameters = new Dictionary<string, object> { { "@Username", username } };
        int count = (int)_dbManager.ExecuteScalar(query, parameters);
        return count > 0;
    }

    // Verifica le credenziali dell'utente nel database
    private bool VerifyCredentials(string username, string password)
    {
        string query = "SELECT Password FROM Users WHERE Username = @Username";
        var parameters = new Dictionary<string, object> { { "@Username", username } };
        string storedPassword = (string)_dbManager.ExecuteScalar(query, parameters);

        // Confronta la password direttamente
        return storedPassword == password;
    }

    // Metodo per recuperare il ruolo dell'utente dal database
    private string GetUserRoleFromDatabase(string username)
    {
        string query = "SELECT Role FROM Users WHERE Username = @Username";
        var parameters = new Dictionary<string, object> { { "@Username", username } };

        // Eseguire la query per ottenere il ruolo dell'utente
        object roleObj = _dbManager.ExecuteScalar(query, parameters);

        if (roleObj != null)
        {
            return roleObj.ToString();
        }

        return string.Empty; // Ritorna vuoto se il ruolo non è trovato
    }
}
