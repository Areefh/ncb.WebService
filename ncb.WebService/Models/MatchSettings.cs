using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ncb.WebService.Models
{
    [ComplexType]
    public class MatchSettings
    {
        //[Required]
        //public Language Language { get; set; }
        [Required]
        [MinLength(3)]
        public IReadOnlyList<Category> Categories { get; set; }

        [Required]
        [Range(1, ushort.MaxValue)]
        public ushort SecondsPerWord { get; set; }

        [Required]
        [Range(3, ushort.MaxValue)]
        public ushort RoundsCount { get; set; }
    }
}
