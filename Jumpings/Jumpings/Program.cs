using Jumpings.Repos;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

            foreach (var jumper in jumpers)
            {
                Console.WriteLine(jumper.ToString());
            }

            Console.Read();
        }

        private static List<Jumper> GetAllJumpers(JumpingsContext jumpingsContext)
        {
            // pobieram skoczkow 
            using (var repo = new JumperRepo(jumpingsContext))
            {
                var jumpers = repo.GetAll()
                    .OrderBy(jumper => jumper.LastName)
                    .ToList();

                return jumpers;
            }
            // pobieranie ukonczone
        }
        private static void DataInitialize(JumpingsContext jumpingsContext)
        {
            IDataInitializer dataInitializer = new DataInitializer();
            dataInitializer.InitializeData(jumpingsContext);
        }

        // create jumper result message
        // var message = new jumper result message
    }
}
 