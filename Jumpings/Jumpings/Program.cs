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
            JumpingsContext jumpingsContext = new JumpingsContext();
            IRandomDataService randomDataService = new RandomDataService();
            IJumperService jumperService = new JumperService(new JumperRepo(jumpingsContext));

            DataInitialize(jumpingsContext);

            var jumpers = jumperService.GetAllJumpers();

            if (jumpers.Count == 0)
            {
                // jakis console writeline, ze nie mona wyswietlic wynikow bo lista skoczkow jest pusta, read i thow
            }

            foreach (var jumper in jumpers)
            {
                var jumperResult = randomDataService.GetResult();

                if (jumperResult == null)
                {
                    // jakis console writeline, ze nie mona wyswietlic wynikow dla skoczka o iminie i nazwisku
                    continue;
                }
                
                // todo 
                Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}", jumper.ID, jumper.ToString(), jumperResult.Note,
                    jumperResult.Length, jumperResult.IsFall, jumperResult.Summary);
            }
            
            Console.Read();
        }
        
        private static void DataInitialize(JumpingsContext jumpingsContext)
        {
            // try catch zlapac DataInitialize 
            // dla catcha z DataInitialize wypisac w consoli wiadomosc ze nie udalo sie zainicjalizowac danych, sproboj ponownie. Po nacisnieciu enter,m okno zostanie zamkniete Console.Read throw
            IDataInitializer dataInitializer = new DataInitializer();
            dataInitializer.InitializeData(jumpingsContext);
        }

        // send jumper result message
        // var message = new jumper result message
    }
}
 