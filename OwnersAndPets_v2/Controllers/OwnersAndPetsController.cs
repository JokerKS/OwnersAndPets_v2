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
    public class OwnersAndPetsController : ApiController
    {
        private AppContext db = new AppContext();

        // GET: api/OwnersAndPets
        public OwnersList GetOwners([FromUri]int pageIndex, [FromUri]int pageSize)
        {
            var ownersAndPetsCount = db.Owners.Select(x => new OwnerWithPetCount()
            {
                OwnerId = x.OwnerId,
                Name = x.Name,
                PetsCount = x.Pets.Count()
            })
            .OrderBy(x => x.OwnerId)
            .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new OwnersList() { OwnersWithPetsCount = ownersAndPetsCount, TotalCount = db.Owners.Count()};
        }

        // Post: api/OwnersAndPets
        [HttpPost]
        public IHttpActionResult AddOwner([FromBody]string ownerName)
        {
            db.Owners.Add(new Owner() { Name = ownerName });
            db.SaveChanges();
            return Ok();
        }

        // DELETE api/OwnersAndPets/5
        [HttpDelete]
        public IHttpActionResult DeleteOwner(int id)
        {
            Owner owner = db.Owners.Where(x => x.OwnerId == id).Include(x => x.Pets).FirstOrDefault();
            if (owner == null)
            {
                return NotFound();
            }

            db.Owners.Remove(owner);
            db.SaveChanges();
            return Ok();
        }
    }
}
