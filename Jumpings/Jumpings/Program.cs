using Jumpings.Repos;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Jumpings
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var jumpingsContext = new JumpingsContext();
            DataInitialize(jumpingsContext);

            var jumpers = GetAllJumpers(jumpingsContext);

            foreach (Jumper jumper in jumpers)

            {
                Console.WriteLine(jumper.ToString());
            }  

            Console.Read();
        }

        private static List<Jumper> GetAllJumpers(JumpingsContext jumpingsContext)
        {
            using (var repo = new JumperRepo(jumpingsContext))
            {
                var jumpers = repo.GetAll();
                return jumpers;
            }
        }
        private static void DataInitialize(JumpingsContext jumpingsContext)
        {
            IDataInitializer dataInitializer = new DataInitializer();
            dataInitializer.InitializeData(jumpingsContext);
        }
    }
}
 