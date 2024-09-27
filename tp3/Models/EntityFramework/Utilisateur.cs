using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tp3.Models.EntityFramework
{
    [Table("t_e_utilisateur_utl")]
    public class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("utl_nom", TypeName = "varchar(50)")]
        public string? Nom { get; set; }

        [Column("utl_prenom", TypeName = "varchar(50)")]
        public string? Prenom { get; set; }

        [Column("utl_mobile", TypeName = "char(10)")]
        public string? Mobile { get; set; }

        [Required]
        [Column("utl_mail", TypeName = "varchar(100)")]
        public string Mail { get; set; }

        [Required]
        [Column("utl_pwd", TypeName = "varchar(64)")]
        public string Pwd { get; set; }

        [Column("utl_rue", TypeName = "varchar(200)")]
        public string? Rue { get; set; }

        [Column("utl_cp", TypeName = "char(5)")]
        public string? CodePostal { get; set; }

        [Column("utl_ville", TypeName = "varchar(50)")]
        public string? Ville { get; set; }

        [Column("utl_pays", TypeName = "varchar(50)")]
        public string? Pays { get; set; } = "France";

        [Column("utl_latitude", TypeName = "real")]
        public float? Latitude { get; set; }

        [Column("utl_longitude", TypeName = "real")]
        public float? Longitude { get; set; }

        [Required]
        [Column("utl_datecreation", TypeName = "date")]
        public DateTime DateCreation { get; set; } = DateTime.Now;

        // Propriété de navigation vers Notation
        public ICollection<Notation> NotesUtilisateur { get; set; }
    }
}
