using System.Collections.Generic;
using System.Data.Entity;

namespace OwnersAndPets_v2.Entities
{
    public class AppContext : DbContext
    {
        public AppContext() : base("OwnerAndPetsDB")
        {
            Database.SetInitializer(new OwnersAndPetsDbInitializer());
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }

    /// <summary>
    /// Data initialization when the database is created
    /// </summary>
    class OwnersAndPetsDbInitializer : CreateDatabaseIfNotExists<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            //Adding owners and pets
            Owner o1 = new Owner() { Name = "Тарас Шевченко", Pets = new List<Pet>() { new Pet() { Name ="Катерина"}, new Pet() { Name = "Гайдамаки"}} };
            Owner o2 = new Owner() { Name = "Леся Українка", Pets = new List<Pet>() { new Pet() { Name = "Мавка" }, new Pet() { Name = "Русалка" }, new Pet() { Name = "Лісовик" } } };
            Owner o3 = new Owner() { Name = "Іван Франко", Pets = new List<Pet>() { new Pet() { Name = "Каменярі" }, new Pet() { Name = "Фарбований лис" }, new Pet() { Name = "Осел і лев"} } };
            //Add default clients
            context.Owners.Add(o1);
            context.Owners.Add(o2);
            context.Owners.Add(o3);
            //Write data to database
            context.SaveChanges();
        }
    }
}