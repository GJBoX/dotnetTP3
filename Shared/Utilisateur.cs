using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.Models
{
    public class Utilisateur
    {
        // Propriétés correspondant à l'entité Utilisateur, pour les garder toutes

        [JsonPropertyName("id_utilisateur")]  // Nom de la propriété dans le JSON
        public int UtilisateurId { get; set; }

        [Required]  // Validation de la présence de cette propriété
        [StringLength(100, ErrorMessage = "Le nom ne peut dépasser 100 caractères.")]
        [JsonPropertyName("nom")]  // Nom de la propriété dans le JSON
        public string Nom { get; set; }

        [Required]  // Validation de la présence de cette propriété
        [StringLength(100, ErrorMessage = "Le prénom ne peut dépasser 100 caractères.")]
        [JsonPropertyName("prenom")]  // Nom de la propriété dans le JSON
        public string Prenom { get; set; }

        [Required]  // Validation de la présence de cette propriété
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        [StringLength(100, ErrorMessage = "L'email ne peut dépasser 100 caractères.")]
        [JsonPropertyName("email")]  // Nom de la propriété dans le JSON
        public string Email { get; set; }

        // Vous pouvez avoir d'autres propriétés dans votre entité, les voici :
        [JsonPropertyName("date_naissance")]
        public DateTime? DateNaissance { get; set; }  // Exemple de propriété DateTime

        [JsonPropertyName("adresse")]
        [StringLength(200)]
        public string? Adresse { get; set; }  // Exemple de propriété de type chaîne

        [JsonPropertyName("telephone")]
        [StringLength(20)]
        public string? Telephone { get; set; }  // Exemple de propriété de type chaîne

        [JsonPropertyName("role")]
        public string Role { get; set; }  // Par exemple, le rôle de l'utilisateur dans l'application

        // Ajouter des propriétés supplémentaires si elles existent dans votre entité
        [JsonPropertyName("actif")]
        public bool Actif { get; set; }  // Par exemple, un champ pour savoir si l'utilisateur est actif

        // Constructeur pour initialiser l'objet
        public UtilisateurDTO() { }

        // Si vous souhaitez initialiser à partir d'une entité Utilisateur :
        public UtilisateurDTO(int utilisateurId, string nom, string prenom, string email, DateTime? dateNaissance, string? adresse, string? telephone, string role, bool actif)
        {
            UtilisateurId = utilisateurId;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            DateNaissance = dateNaissance;
            Adresse = adresse;
            Telephone = telephone;
            Role = role;
            Actif = actif;
        }
    }
}
