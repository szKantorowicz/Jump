using Jumpings.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpings.Services.Base
{
    public class JumperService : IJumperService
    {
        public JumperService() { }
        public List<Jumper> GetAllJumpers(JumpingsContext jumpingsContext)
        {
            using (var repo = new JumperRepo(jumpingsContext))
            {
                var jumpers = repo.GetAll()
                    .OrderBy(jumper => jumper.LastName)
                    .ToList();

                return jumpers;
            }
        }
        public void JumperResult()
        { }
    }
}
