using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpings.Repos
{
    public class DataInitializer : DropCreateDatabaseAlways<JumpingsContext>
    {
        protected override void Seed (JumpingsContext context)
        {
            var jumper= new List<Jumper>
            {
                new Jumper{ID=1,FirstName=""}
            }

        }
        
    }
}
