using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.Models
{
    public class SuperHeroModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AlterEgo { get; set; }
        public string PrimaryAbility { get; set; }
        public string SecondaryAbility { get; set; }
        public string CatchPhrase { get; set; }
    }
}
