using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ncb.WebService.Models
{
    public class Match
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }

        [MaxLength(180)]
        public string Notes { get; set; }

        [Required]
        public MatchSettings Settings { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDateTime { get; set; }
    }
}
