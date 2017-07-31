using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwnersAndPets_v2.Entities
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }
    }
}