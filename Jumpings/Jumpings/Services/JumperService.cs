using System.Collections.Generic;
using System.Linq;
using Jumpings.Repos;
using Jumpings.Services.Base;

namespace Jumpings.Services
{
    public class JumperService : IJumperService
    {
        private readonly JumperRepo _jumperRepo;

        public JumperService(JumperRepo jumperRepo)
        {
            _jumperRepo = jumperRepo;
        }

        public List<Jumper> GetAllJumpers()
        {
            var jumpers = _jumperRepo.GetAll()
                .OrderBy(jumper => jumper.LastName)
                .ToList();

            return jumpers;
        }
    }
}