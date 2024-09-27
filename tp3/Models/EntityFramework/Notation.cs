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
    public class Notation
        {
            [Key, Column("utl_id", Order = 0)]
            public int UtilisateurId { get; set; }

            [Key, Column("ser_id", Order = 1)]
            public int SerieId { get; set; }

            [Column("not_note")]
            [Range(0, 5)]
            public int Note { get; set; }

            // Propriétés de navigation vers Utilisateur et Serie
            [ForeignKey("UtilisateurId")]
            public Utilisateur UtilisateurNotant { get; set; }

            [ForeignKey("SerieId")]
            public Serie SerieNotee { get; set; }
        }

}
