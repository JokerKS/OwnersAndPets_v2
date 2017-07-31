using OwnersAndPets_v2.Entities;
using OwnersAndPets_v2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OwnersAndPets_v2.Controllers
{
    public class PetsController : ApiController
    {
        private AppContext db = new AppContext();

        // GET: api/Pets
        public PetsList GetPets([FromUri] int ownerId, [FromUri]int pageIndex, [FromUri]int pageSize)
        {
            var rez = db.Owners.Where(x => x.OwnerId == ownerId).Include(x => x.Pets)
                .Select(x => new PetsList()
                {
                    OwnerName = x.Name,
                    Pets = x.Pets.ToList(),
                    TotalCount = x.Pets.Count
                })
                .FirstOrDefault();

            rez.Pets = rez.Pets.OrderBy(z => z.PetId).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return rez;
        }

        // Post: api/Pets
        [HttpPost]
        public IHttpActionResult AddPet([FromUri] int ownerId, [FromBody]string petName)
        {
            db.Pets.Add(new Pet() { Name = petName, OwnerId = ownerId });
            db.SaveChanges();
            return Ok();
        }

        // DELETE api/Pets/5
        [HttpDelete]
        public IHttpActionResult DeletePet(int id)
        {
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return NotFound();
            }

            db.Pets.Remove(pet);
            db.SaveChanges();
            return Ok();
        }
    }
}
