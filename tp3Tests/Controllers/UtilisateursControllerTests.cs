using Microsoft.VisualStudio.TestTools.UnitTesting;
using tp3.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tp3.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using tp3.Models.Data;

namespace tp3Tests.Controllers.Tests
{
    [TestClass]
    public class UtilisateursControllerTests
    {
        private ApplicationDbContext _context;
        private UtilisateursController _controller;

        [TestInitialize]
        public void Initialize()
        {
            // Configuration du DbContext pour utiliser une base de données en mémoire
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);

            // Ajouter des utilisateurs factices pour les tests
            _context.Utilisateurs.AddRange(
                new Utilisateur { Id = 1, Nom = "User1", Email = "user1@example.com" },
                new Utilisateur { Id = 2, Nom = "User2", Email = "user2@example.com" }
            );
            _context.SaveChanges();

            // Initialiser le contrôleur avec le contexte
            _controller = new UtilisateursController(_context);
        }

        [TestMethod]
        public async Task GetUtilisateursTest()
        {
            // Act : Appeler la méthode GetUtilisateurs du contrôleur
            var result = await _controller.GetUtilisateurs();

            // Assert : Vérifier le type de retour
            Assert.IsInstanceOfType(result.Result, typeof(ActionResult<IEnumerable<Utilisateur>>));

            // Extraire la liste des utilisateurs du résultat de l'action
            var actionResult = result.Result as ActionResult<IEnumerable<Utilisateur>>;
            var utilisateurs = actionResult.Value.ToList();

            // Comparer avec les utilisateurs en mémoire
            var utilisateursFromDb = _context.Utilisateurs.ToList();
            Assert.AreEqual(utilisateursFromDb.Count, utilisateurs.Count);

            // Vérifier les données de chaque utilisateur
            foreach (var utilisateur in utilisateursFromDb)
            {
                Assert.IsTrue(utilisateurs.Any(u => u.Id == utilisateur.Id && u.Nom == utilisateur.Nom && u.Email == utilisateur.Email));
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
