using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OwnersAndPets_v2.Entities
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public IList<Pet> Pets { get; set; }
    }
}