using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.Models
{
    [MetadataType(typeof(SuperHeroModel))]
    public class SuperHeroModel
    {
        
        
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Names are required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Alter ego is required")]
        public string AlterEgo { get; set; }

        [Required(ErrorMessage = "Ability is required")]
        public string PrimaryAbility { get; set; }

        [Required(ErrorMessage = "Ability is required")]
        public string SecondaryAbility { get; set; }

        [Required(ErrorMessage = "Catch phrase is required")]
        public string CatchPhrase { get; set; }
    }
}
