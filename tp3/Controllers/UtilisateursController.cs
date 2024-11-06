using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tp3.Models.Data;
using tp3.Models.DataManager;
using tp3.Models.EntityFramework;

namespace tp3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        // private readonly ApplicationDbContext _context;
        private readonly UtilisateurManager utilisateurManager;

        public UtilisateursController(UtilisateurManager userManager)
        {
            utilisateurManager = userManager;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
        {
            return utilisateurManager.GetAll();
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateur(int id)
        {
            // var utilisateur = await _context.Utilisateurs.FindAsync(id);
            var utilisateur = utilisateurManager.GetById(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }

        // GET: api/Utilisateurs/email/example@email.com
        [HttpGet("email/{email}")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateurByEmail(string email)
        {
            // var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Mail.ToLower() == email.ToLower());
            var utilisateur = utilisateurManager.GetByString(email);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.UtilisateurId)
            {
                return BadRequest();
            }

            // _context.Entry(utilisateur).State = EntityState.Modified;
            var userToUpdate = utilisateurManager.GetById(id);

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!UtilisateurExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();

            if (userToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                utilisateurManager.Update(userToUpdate.Value, utilisateur);
                return NoContent();
            }
        }

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);  
            //}

            //_context.Utilisateurs.Add(utilisateur);
            //await _context.SaveChangesAsync();

            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }

            utilisateurManager.Add(utilisateur);

            return CreatedAtAction("GetUtilisateur", new { id = utilisateur.UtilisateurId }, utilisateur);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            //var utilisateur = await _context.Utilisateurs.FindAsync(id);
            var utilisateur = utilisateurManager.GetById(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            //_context.Utilisateurs.Remove(utilisateur);
            //await _context.SaveChangesAsync();
            utilisateurManager.Delete(utilisateur.Value);

            return NoContent();
        }

        //private bool UtilisateurExists(int id)
        //{
        //    return _context.Utilisateurs.Any(e => e.UtilisateurId == id);
        //}
    }
}
