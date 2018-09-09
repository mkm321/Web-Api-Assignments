using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DesignPatternAssignment.Controllers
{
    public class HotelController : ApiController
    {
        public IEnumerable<Hotel> GetValues()
        {
            using (ProductsEntities entity = new ProductsEntities())
            {
                return entity.Hotels.ToList();
            }

        }
        /*public IEnumerable<Hotel> GetValue(string operation)
        {

            using (ProductsEntities entity = new ProductsEntities())
            {
                if (operation.Equals("Book"))
                {
                    var query = from value in entity.Hotels
                                where value.IsBooked == "true"
                                select value;
                    return query.ToList();
                }
                else
                {
                    var query = from value in entity.Hotels
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
