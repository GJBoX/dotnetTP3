using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tp3.Models.EntityFramework
{
    [Table("t_j_notation_not")]
    [PrimaryKey(nameof(UtilisateurId), nameof(SerieId))]

    public class Notation
    {
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("ser_id")]
        public int SerieId { get; set; }

        [Column("not_note")]
        [Range(0, 5, ErrorMessage = "Value for {0} must be between {1} and {2}."), Required]
        public required int Note { get; set; }

        [ForeignKey(nameof(UtilisateurId))]
        [InverseProperty(nameof(Utilisateur.NotesUtilisateur))]
        public virtual Utilisateur UtilisateurNotant { get; set; } = null!;

        [ForeignKey(nameof(SerieId))]
        [InverseProperty(nameof(Serie.NotesSerie))]
        public virtual Serie SerieNotee { get; set; } = null!;
    }
}
