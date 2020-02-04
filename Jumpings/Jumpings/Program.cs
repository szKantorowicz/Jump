using Jumpings.Repos;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Jumpings.Services.Base;
using Jumpings.Services;

namespace Jumpings
{
    class Program : RandomDataService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            
            IRandomDataService radomDataService = new RandomDataService();
            var jumpingsContext = new JumpingsContext();
            DataInitialize(jumpingsContext);
            IJumperService jumperservice = new JumperService(jumpingsContext);
            

            var jumpers = jumperservice.GetAllJumpers(jumpingsContext);

            foreach (var jumper in jumpers)
            {
                radomDataService.RandomFall();
                radomDataService.RandomLength();
                radomDataService.RandomNote();
                radomDataService.SumResult();
                Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}", jumper.ID, jumper.ToString(), radomDataService.SumResult(),
                    radomDataService.RandomFall(), radomDataService.RandomLength(), radomDataService.RandomNote());
            }
            Console.Read();

        }
        
        private static void DataInitialize(JumpingsContext jumpingsContext)
        {
            IDataInitializer dataInitializer = new DataInitializer();
            dataInitializer.InitializeData(jumpingsContext);
        }

        // send jumper result message
        // var message = new jumper result message
    }
}
 