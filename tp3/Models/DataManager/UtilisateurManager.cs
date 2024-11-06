using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tp3.Models.Data;
using tp3.Models.EntityFramework;
using tp3.Models.Repository;

namespace tp3.Models.DataManager
{
    public class UtilisateurManager : IDataRepository<Utilisateur>
    {
        readonly ApplicationDbContext? ApplicationDbContext;
        public UtilisateurManager() { }
        public UtilisateurManager(ApplicationDbContext context)
        {
            ApplicationDbContext = context;
        }
        public ActionResult<IEnumerable<Utilisateur>> GetAll()
        {
            return ApplicationDbContext.Utilisateurs.ToList();
        }
        public ActionResult<Utilisateur> GetById(int id)
        {
            return ApplicationDbContext.Utilisateurs.FirstOrDefault(u => u.UtilisateurId == id);
        }

        public ActionResult<Utilisateur> GetByString(string mail)
        {
            return ApplicationDbContext.Utilisateurs.FirstOrDefault(u => u.Mail.ToUpper() == mail.ToUpper());
        }

        public void Add(Utilisateur entity)
        {
            ApplicationDbContext.Utilisateurs.Add(entity);
            ApplicationDbContext.SaveChanges();
        }

        public void Update(Utilisateur utilisateur, Utilisateur entity)
        {
            ApplicationDbContext.Entry(utilisateur).State = EntityState.Modified;
            utilisateur.UtilisateurId = entity.UtilisateurId;
            utilisateur.Nom = entity.Nom;
            utilisateur.Prenom = entity.Prenom;
            utilisateur.Mail = entity.Mail;
            utilisateur.Rue = entity.Rue;
            utilisateur.CodePostal = entity.CodePostal;
            utilisateur.Ville = entity.Ville;
            utilisateur.Pays = entity.Pays;
            utilisateur.Latitude = entity.Latitude;
            utilisateur.Longitude = entity.Longitude;
            utilisateur.Pwd = entity.Pwd;
            utilisateur.Mobile = entity.Mobile;
            utilisateur.NotesUtilisateur = entity.NotesUtilisateur;
            ApplicationDbContext.SaveChanges();
        }

        public void Delete(Utilisateur utilisateur)
        {
            ApplicationDbContext.Utilisateurs.Remove(utilisateur);
            ApplicationDbContext.SaveChanges();
        }
    }
}
