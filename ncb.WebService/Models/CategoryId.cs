using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ncb.WebService.Models
{
    [ComplexType]
    public class CategoryId : ValueObject<CategoryId>
    {
        public CategoryId(Language language, uint alphabetVariantId)
        {
            this.Language = language;
            this.AlphabetVariantId = alphabetVariantId;
        }

        [Required]
        public Language Language { get; set; }

        [Required]
        public uint AlphabetVariantId { get; set; }

        protected override IEnumerable<object> GetValueIngredients()
        {
            yield return this.Language;
        }
    }


}
