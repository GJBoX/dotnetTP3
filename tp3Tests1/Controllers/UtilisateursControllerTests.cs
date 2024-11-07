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
using tp3.Models.Repository;
using tp3.Models.DataManager;
using Humanizer;
using Moq;

namespace tp3.Controllers.Tests
{
    [TestClass()]
    public class UtilisateurControllerTests
    {
        //private readonly ApplicationDbContext _context;
        //private readonly UtilisateursController _controller;
        private UtilisateursController controller;
        private ApplicationDbContext context;
        private IDataRepository<Utilisateur> dataRepository;

        public UtilisateurControllerTests()
        {
            // Configuration de la base de données en mémoire
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: "TestDatabase")
                            .Options;

            context = new ApplicationDbContext(options);

            dataRepository = new UtilisateurManager(context);
            controller = new UtilisateursController(dataRepository);
            // Initialisation du contrôleur avec le contexte
            // _controller = new UtilisateursController(_context);
        }

        // Exemple de test pour le POST
        [Fact]
        public void Postutilisateur_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange : Créer un utilisateur fictif à ajouter
            //Random rnd = new Random();
            //int chiffre = rnd.Next(1,1000000000);

            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            var userController = new UtilisateursController(mockRepository.Object);

            Utilisateur user = new Utilisateur
            {
                Nom = "POISSON",
                Prenom = "Pascal",
                Mobile = "1",
                Mail = "poisson@gmail.com",
                Pwd = "Toto12!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };

            // Act : Effectuer l'appel à l'action Post
            var actionResult = userController.PostUtilisateur(user).Result;

            // Assert 
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Utilisateur>), "Pas un ActionResult<Utilisateur>");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result.Value, typeof(Utilisateur), "Pas un Utilisateur");
            user.UtilisateurId = ((Utilisateur)result.Value).UtilisateurId;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(user, (Utilisateur)result.Value, "Utilisateurs pas identiques");
        }
    }
}