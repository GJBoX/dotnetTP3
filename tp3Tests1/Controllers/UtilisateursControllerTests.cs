using Microsoft.VisualStudio.TestTools.UnitTesting;
using tp3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tp3.Models.Data;
using tp3.Models.EntityFramework;
using Xunit;

namespace tp3.Controllers.Tests
{
    [TestClass()]
    public class UtilisateurControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly UtilisateursController _controller;

        public UtilisateurControllerTests()
        {
            // Configuration de la base de données en mémoire
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: "TestDatabase")
                            .Options;

            _context = new ApplicationDbContext(options);

            // Initialisation du contrôleur avec le contexte
            _controller = new UtilisateursController(_context);
        }

        // Exemple de test pour le POST
        [Fact]
        public async Task PostUtilisateur_ValidUtilisateur_ReturnsCreatedAtActionResult()
        {
            // Arrange : Créer un utilisateur fictif à ajouter
            var utilisateur = new Utilisateur
            {
                Nom = "DURAND",
                Prenom = "Marc",
                Mail = "marc.durand@example.com",
                Pwd = "Passwor1!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy",
                Pays = "France",
                Latitude = 45.1234f,
                Longitude = 6.2345f
            };

            // Act : Effectuer l'appel à l'action Post
            var result = await _controller.PostUtilisateur(utilisateur);

        }
    }
}