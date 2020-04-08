using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ncb.WebService.Models
{
    public class Category
    {
        //[Key]
        //[Required]
        //public CategoryId Id { get; set; }

        //[Key]
        //[Required]
        //public Language Language { get; set; }

        [Key]
        [Required]
        public uint AlphabetVariantId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(180)]
        public string Description { get; set; }

        public ISet<Tag> Tags { get; set; }
    }

    public class AlphabetVariant
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }

        [Required]
        public Language Language { get; set; }

        [Required]
        public ISet<char> Chars_UTF16 { get; set; }
    }
}
