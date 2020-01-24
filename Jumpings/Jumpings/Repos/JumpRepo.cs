using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jumpings.Repos
{
    public class JumpRepo : BaseRepo<Jumper>, IRepo<Jumper>
    {
        public JumpRepo()
        {
            Context = new JumpingsContext();
            Table = Context.Jumper;
        }

    }
}
