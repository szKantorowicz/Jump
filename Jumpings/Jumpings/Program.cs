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
                Console.WriteLine("Nie można wczytać skoczków, ponieważ lista jest pusta");
                Console.Read();
                Environment.Exit(0);
            }

            foreach (var jumper in jumpers)
            {
                Console.Read();

                var jumperResult = randomDataService.GetResult();

                if (jumperResult == null)
                {
                    Console.WriteLine($"Nie można wyświetlić skoczka o imiu {jumper.FirstName} i nazwisku {jumper.LastName}.");
                    continue;
                }

                Console.WriteLine("Przygotowuje się do skoku");
                Console.WriteLine("Wystartował");

                if (!jumperResult.IsFall && jumperResult.Length > 115)
                {
                    Console.WriteLine("Piękny skok.");
                }
                else if (jumperResult.IsFall && jumperResult.Length > 115)
                {
                    Console.WriteLine("Dobry skok ale nieustany.");
                }
                else
                {
                    Console.WriteLine("Słaby skok.");
                }

                Console.WriteLine($"Skoczek: {jumper.ToString()} Nota: {jumperResult.Note} Długość skoku: {jumperResult.Length} Upadek: {jumperResult.IsFall} Wynik końcowy: {jumperResult.Summary}");         
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
                Console.WriteLine($"Nie można zainicjalizować danych, należy spróbwać ponownie, aplikacja zostanie zamknięta po naciśnięciu ENTER. {ex.Message}");
                Console.Read();
                Environment.Exit(0);
            }
        }
    }
}
