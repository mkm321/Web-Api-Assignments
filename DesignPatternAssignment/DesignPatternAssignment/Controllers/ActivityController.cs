using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DesignPatternAssignment.Controllers
{
    public class ActivityController : ApiController
    {
        public IEnumerable<Activity> GetValues()
        {
            using (ProductsEntities entity = new ProductsEntities())
            {
                return entity.Activities.ToList();
            }

        }
        /*public IEnumerable<Activity> GetValue(string operation)
        {

            using (ProductsEntities entity = new ProductsEntities())
            {
                if (operation.Equals("Book"))
                {
                    var query = from value in entity.Activities
                                where value.IsBooked == "true"
                                select value;
                    return query.ToList();
                }
                else
                {
                    var query = from value in entity.Activities
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

                    entity.Activities.Find(id).IsBooked = "true";
                    entity.SaveChanges();
                }
                else if (operation.Equals("Save"))
                {
                    entity.Activities.Find(id).IsSaved = "true";
                    entity.SaveChanges();
                }
            }

        }
        [HttpPost]
        public void InsertValues([FromBody]Activity act)
        {
            using (ProductsEntities entity = new ProductsEntities())
            {
                entity.Activities.Add(act);
                entity.SaveChanges();
            }

        }
    }
}
