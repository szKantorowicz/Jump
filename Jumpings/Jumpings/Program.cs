using Jumpings.Repos;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Jumpings
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            RegisterDataInitializers();

            var jumpers = GetAllJumpers();

            foreach (Jumper jumper in jumpers)
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
            //var context = new JumpingsContext();
            using (var repo = new JumperRepo(new JumpingsContext()))
            {
                var jumpers = repo.GetAll();
                return jumpers;
            }
        }
    }
}
 