using OwnersAndPets_v2.Entities;
using System.Collections.Generic;

namespace OwnersAndPets_v2.Models
{
    public class OwnerWithPetCount
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public int PetsCount { get; set; }
    }

    public class OwnersList
    {
        public List<OwnerWithPetCount> OwnersWithPetsCount { get; set; }
        public int TotalCount { get; set; }
    }

    public class PetsList
    {
        public string OwnerName { get; set; }
        public List<Pet> Pets { get; set; }
        public int TotalCount { get; set; }
    }
}