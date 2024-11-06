using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tp3.Models.Data;
using tp3.Models.EntityFramework;
using tp3.Models.Repository;

namespace tp3.Models.DataManager
{
    public class UtilisateurManager : IDataRepository<Utilisateur>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UtilisateurManager(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetAllAsync()
        {
            return await applicationDbContext.Utilisateurs.ToListAsync();
        }

        public async Task<ActionResult<Utilisateur>> GetByIdAsync(int id)
        {
            return await applicationDbContext.Utilisateurs.FirstOrDefaultAsync(u => u.UtilisateurId == id);
        }

        public async Task<ActionResult<Utilisateur>> GetByStringAsync(string mail)
        {
            return await applicationDbContext.Utilisateurs.FirstOrDefaultAsync(u => u.Mail.ToUpper() == mail.ToUpper());
        }

        // Méthode AddAsync pour l'ajout asynchrone
        public async Task AddAsync(Utilisateur entity)
        {
            await applicationDbContext.Utilisateurs.AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();
        }

        // Méthode UpdateAsync pour la mise à jour asynchrone
        public async Task UpdateAsync(Utilisateur utilisateur, Utilisateur entity)
        {
            applicationDbContext.Entry(utilisateur).State = EntityState.Modified;
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

            await applicationDbContext.SaveChangesAsync();
        }

        // Méthode DeleteAsync pour la suppression asynchrone
        public async Task DeleteAsync(Utilisateur utilisateur)
        {
            applicationDbContext.Utilisateurs.Remove(utilisateur);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
