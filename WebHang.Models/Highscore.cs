using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebHang.Models
{
    class Highscore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HighscoreId { get; set; }
        [Required]
        public int HighscorePlayerId { get; set; }
        public int? HighscoreEasy { get; set; }
        public int? HighscoreMedium { get; set; }
        public int? HighscoreHard { get; set; }
        public int? HighscoreTotal { get; set; }

        [ForeignKey("Player")]
        public virtual Player Player { get; set; }
    }
}
