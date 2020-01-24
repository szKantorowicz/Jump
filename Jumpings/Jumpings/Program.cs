using Jumpings.Repos;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpings
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            RegisterDataInitializers();

            var jumpers = GetAllJumpers();

            foreach(Jumper jumper in jumpers)
            {
                Console.WriteLine(jumper.ToString());
            }

            Console.Read();
        }

        private static void RegisterDataInitializers()
        {
            Database.SetInitializer(new DataInitializer());
        }

        private static List<Jumper> GetAllJumpers()
        {
            using (var repo = new JumpRepo())
            {
                var jumpers = repo.GetAll();
                return jumpers;
            }
        }
        
    }
}
