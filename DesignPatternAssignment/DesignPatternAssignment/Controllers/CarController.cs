using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
namespace DesignPatternAssignment.Controllers
{
    public class CarController : ApiController
    {
        public IEnumerable<Car> GetValues()
        {
            using (ProductsEntities entity = new ProductsEntities())
            {
                return entity.Cars.ToList();
            }

        }
        [HttpPut]
        public void PutValues(int id, [FromBody] string operation)
        {
            using (ProductsEntities entity = new ProductsEntities())
            {
                if (operation.Equals("Book"))
                {

                    entity.Cars.Find(id).IsBooked = "true";
                    entity.SaveChanges();
                }
                else if (operation.Equals("Save"))
                {
                    entity.Cars.Find(id).IsSaved = "true";
                    entity.SaveChanges();
                }
            }

        }
        [HttpPost]
        public void InsertValues([FromBody]Car act)
        {
            using (ProductsEntities entity = new ProductsEntities())
            {
                entity.Cars.Add(act);
                entity.SaveChanges();
            }

        }
    }
}
