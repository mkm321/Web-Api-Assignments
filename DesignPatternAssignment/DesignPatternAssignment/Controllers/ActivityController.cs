﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DesignPatternAssignment.Controllers
{
    public class ActivityController : ApiController
    {
        [HttpGet]
        public IEnumerable<Activity> GetValues()
        {
            using (ProductsEntities entity = new ProductsEntities())
            {
                return entity.Activities.ToList();
            }

        }
        [HttpPut]
        public void PutValues(int id, [FromBody] string operation)
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
