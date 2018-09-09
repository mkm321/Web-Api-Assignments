using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        /*public IEnumerable<Car> GetValue(string operation)
        {

            using (ProductsEntities entity = new ProductsEntities())
            {
                if (operation.Equals("Book"))
                {
                    var query = from value in entity.Cars
                                where value.IsBooked == "true"
                                select value;
                    return query.ToList();
                }
                else
                {
                    var query = from value in entity.Cars
                                where value.IsSaved == "true"
                                select value;
                    return query.ToList();
                }
            }

        }*/
        [HttpPut]
        public void PutValues([FromBody]int id, [FromBody] string operation)
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
