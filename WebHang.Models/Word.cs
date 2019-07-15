using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebHang.Models
{
    public enum WordDifficulties
    {
        Easy,
        Meduim,
        Hard
    }
    public class Word
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WordId { get; set; }
        [Required]
        public string WordContent { get; set; }
        [Required]
        public WordDifficulties WordDifficulty { get; set; }
        [Required]
        public int WordCategoryId { get; set; }

        [ForeignKey("Category")]
        public virtual Category Category { get; set; }
    }
}
