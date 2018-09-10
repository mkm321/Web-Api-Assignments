using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DesignPatternAssignment.Controllers
{
    public class AirController : ApiController
    {
        [HttpGet]
        public IEnumerable<Air> GetValues()
        {
            using (ProductsEntities entity = new ProductsEntities())
            {
                return entity.Airs.ToList();
            }

        }
        [HttpPut]
        public void PutValues(int id, [FromBody] string operation)
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
