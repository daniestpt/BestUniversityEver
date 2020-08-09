using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BestUniversityEver.Models;
using BestUniversityEver.DAL;

namespace BestUniversity.DAL
{
    public class BestUniversityEverInitializer : System.Data.Entity.DropCreateDatabaseAlways<BestUniversityEverContext>
    {
        protected override void Seed(BestUniversityEverContext context)
        {
        }            
    }
}