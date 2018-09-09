using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DesignPatternAssignment.Controllers
{
    public class AirController : ApiController
    {
        public IEnumerable<Air> GetValues()
        {
            using (ProductsEntities entity = new ProductsEntities())
            {
                return entity.Airs.ToList();
            }

        }
        /*public IEnumerable<Air> GetValue(string operation)
        {

            using (ProductsEntities entity = new ProductsEntities())
            {
                if (operation.Equals("Book"))
                {
                    var query = from value in entity.Airs
                                where value.IsBooked == "true"
                                select value;
                    return query.ToList();
                }
                else
                {
                    var query = from value in entity.Airs
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

                    entity.Airs.Find(id).IsBooked = "true";
                    entity.SaveChanges();
                }
                else if (operation.Equals("Save"))
                {
                    entity.Airs.Find(id).IsSaved = "true";
                    entity.SaveChanges();
                }
            }

        }
        [HttpPost]
        public void InsertValues([FromBody]Air act)
        {
            using (ProductsEntities entity = new ProductsEntities())
            {
                entity.Airs.Add(act);
                entity.SaveChanges();
            }

        }
    }
}
