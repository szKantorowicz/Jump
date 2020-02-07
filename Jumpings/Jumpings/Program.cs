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
                Console.WriteLine("Nie można wczytać bazy bo lista jest pusta");
                Console.Read();
                throw new Exception();
            }

            foreach (var jumper in jumpers)
            {
                var jumperResult = randomDataService.GetResult();

                if (jumperResult == null)
                {
                    Console.WriteLine("Nie można wyświetlić skoczka o imiu {0} i nazwisku {1} ", jumper.FirstName, jumper.LastName);
                    continue;
                }
                Console.WriteLine("Przygotowuje się do skoku");
                Console.WriteLine("Wystartował");
                if(jumperResult.IsFall==false && jumperResult.Length>115)
                {
                    Console.WriteLine("Piękny skok.");
                }
                if(jumperResult.IsFall== true && jumperResult.Length>115)
                {
                    Console.WriteLine("Dobry skok ale nieustany.");
                }
                else
                {
                    Console.WriteLine("Słaby skok");
                }

                Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}", jumper.ID, jumper.ToString(), jumperResult.Note,
                    jumperResult.Length, jumperResult.IsFall, jumperResult.Summary);
            }

            Console.Read();
        }

        private static void DataInitialize(JumpingsContext jumpingsContext)
        {
            try
            {
                IDataInitializer dataInitializer = new DataInitializer();
                dataInitializer.InitializeData(jumpingsContext);
            }
            catch (DataInitializerFailedException ex)
            {
                Console.WriteLine("Nie można zainicjalizować danych, należy spróbwać ponownie.");
                Console.Read();
                throw ex;
            }
        }
    }
}
 