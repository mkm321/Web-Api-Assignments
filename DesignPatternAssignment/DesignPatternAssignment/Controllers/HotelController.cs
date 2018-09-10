using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DesignPatternAssignment.Controllers
{
    public class HotelController : ApiController
    {
        [HttpGet]
        public IEnumerable<Hotel> GetValues()
        {
            using (ProductsEntities entity = new ProductsEntities())
            {
                return entity.Hotels.ToList();
            }

        }
        [HttpPut]
        public void PutValues(int id, [FromBody] string operation)
        {
            using (ProductsEntities entity = new ProductsEntities())
            {
                if (operation.Equals("Book"))
                {

                    entity.Hotels.Find(id).IsBooked = "true";
                    entity.SaveChanges();
                }
                else if (operation.Equals("Save"))
                {
                    entity.Hotels.Find(id).IsSaved = "true";
                    entity.SaveChanges();
                }
            }

        }
        [HttpPost]
        public void InsertValues([FromBody]Hotel act)
        {
            using (ProductsEntities entity = new ProductsEntities())
            {
                entity.Hotels.Add(act);
                entity.SaveChanges();
            }

        }
    }
}
