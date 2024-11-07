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
using tp3.Models.Repository;

namespace tp3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        // private readonly ApplicationDbContext _context;
        //private readonly UtilisateurManager utilisateurManager;
        private readonly IDataRepository<Utilisateur> dataRepository;

        public UtilisateursController(IDataRepository<Utilisateur> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateur(int id)
        {
            // var utilisateur = await _context.Utilisateurs.FindAsync(id);
            var utilisateur = await dataRepository.GetByIdAsync(id);

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
            var utilisateur = await dataRepository.GetByStringAsync(email);

            if (utilisateur == null)
            {
                return NotFound();
            }
            return utilisateur;
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        //{
        //    if (id != utilisateur.UtilisateurId)
        //    {
        //        return BadRequest();
        //    }

        //    // _context.Entry(utilisateur).State = EntityState.Modified;
        //    var userTo Update = await dataRepository.GetByIdAsync(id);

        //    //try
        //    //{
        //    //    await _context.SaveChangesAsync();
        //    //}
        //    //catch (DbUpdateConcurrencyException)
        //    //{
        //    //    if (!UtilisateurExists(id))
        //    //    {
        //    //        return NotFound();
        //    //    }
        //    //    else
        //    //    {
        //    //        throw;
        //    //    }
        //    //}

        //    //return NoContent();

        //    if (userToUpdate == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        await dataRepository.Update(userToUpdate.Value, utilisateur);
        //        return NoContent();
        //    }
        //}

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

            await dataRepository.AddAsync(utilisateur);

            return CreatedAtAction("GetUtilisateur", new { id = utilisateur.UtilisateurId }, utilisateur);
        }

        // DELETE: api/Utilisateurs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUtilisateur(int id)
        //{
        //    //var utilisateur = await _context.Utilisateurs.FindAsync(id);
        //    var utilisateur = dataRepository.GetById(id);

        //    if (utilisateur == null)
        //    {
        //        return NotFound();
        //    }

        //    //_context.Utilisateurs.Remove(utilisateur);
        //    //await _context.SaveChangesAsync();
        //    dataRepository.Delete(utilisateur.Value);

        //    return NoContent();
        //}

        //private bool UtilisateurExists(int id)
        //{
        //    return _context.Utilisateurs.Any(e => e.UtilisateurId == id);
        //}
    }
}
