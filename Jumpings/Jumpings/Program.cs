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
            
            IRandomDataService rad = new RandomDataService();
            var jumpingsContext = new JumpingsContext();
            DataInitialize(jumpingsContext);
            IJumperService jumperservice = new JumperService();
            

            var jumpers = jumperservice.GetAllJumpers(jumpingsContext);

            foreach (var jumper in jumpers)
            {

               // Console.WriteLine("{0} {1}", jumper.ID, jumper.ToString());
                rad.RandomFall();
                rad.RandomLength();
                rad.RandomNote();
                //rad.SumResult();
                Console.WriteLine("{0}  {1}  {2}", jumper.ID, jumper.ToString(),rad.SumResult());
                //var message = new jumper result message
                
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
 