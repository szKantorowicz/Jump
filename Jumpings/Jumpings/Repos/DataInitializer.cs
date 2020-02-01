using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Jumpings.Repos
{
    public class DataInitializer : IDataInitializer
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void InitializeData(JumpingsContext context)
        {
            try
            {
                if (context == null)
                {
                    throw new ArgumentNullException("Zmienna context nie możę być null'em.");
                }

                var isJumperExists = context.Jumper.Any();

                if (isJumperExists)
                {
                    Logger.Info("Dane zostały już zainicjalizowane.");
                    return;
                }

                var jumpers = new List<Jumper>
                {
                    new Jumper("Clemens", "Aigner", "Austria"),
                    new Jumper("Philipp", "Aschenwald", "Austria"),
                    new Jumper("Manuel", "Fettner", "Austria"),
                    new Jumper("Michael", "Haybóck", "Austria"),
                    new Jumper("Jan", "Hórl", "Austria"),
                    new Jumper("Thomas", "Hofer", "Austria"),
                    new Jumper("Daniel", "Huber", "Austria"),
                    new Jumper("Stefan", "Huber", "Austria"),
                    new Jumper("Stefan", "Kraft", "Austria"),
                    new Jumper("Clemens", "Leitner", "Austria"),
                    new Jumper("Stefan", "Rainer", "Austria"),
                    new Jumper("Markus", "Schiffner", "Austria"),
                    new Jumper("Gregor", "Schlierenzauer", "Austria"),
                    new Jumper("Władimir", "Zografski", "Bułgaria"),
                    new Jumper("Roman", "Koudelka", "Czechy"),
                    new Jumper("Ćestmir", "Kożiśek", "Czechy"),
                    new Jumper("Viktor", "Polaśek", "Czechy"),
                    new Jumper("Filip", "Sakala", "Czechy"),
                    new Jumper("Vojtech", "Śtursa", "Czechy"),
                    new Jumper("Artti", "Aigro", "Estonia"),
                    new Jumper("Martti", "Nomme", "Estonia"),
                    new Jumper("Antti", "Aalto", "Finlandia"),
                    new Jumper("Andreas", "Alamommo", "Finlandia"),
                    new Jumper("Niko", "Kytósaho", "Finlandia"),
                    new Jumper("Jarkko", "Maatta", "Finlandia"),
                    new Jumper("Eetu", "Nousiainen", "Finlandia"),
                    new Jumper("Juho", "Ojala", "Finlandia"),
                    new Jumper("Arttu", "Pohjola", "Finlandia"),
                    new Jumper("Jonne", "Vetelainen", "Finlandia"),
                    new Jumper("Mathis", "Contamine", "Francja"),
                    new Jumper("Jonathan", "Learoyd", "Francja"),
                    new Jumper("Daiki", "Itó", "Japonia"),
                    new Jumper("Kenshiró", "Itó", "Japonia"),
                    new Jumper("Yuken", "Iwasa", "Japonia"),
                    new Jumper("Noriaki", "Kasai", "Japonia"),
                    new Jumper("Junshiró", "Kobayashi", "Japonia"),
                    new Jumper("Ryóyu", "Kobayashi", "Japonia"),
                    new Jumper("Naoki", "Nakamura", "Japonia"),
                    new Jumper("Keiichi", "Sató", "Japonia"),
                    new Jumper("Yukiya", "Sató", "Japonia"),
                    new Jumper("Taku", "Takeuchi", "Japonia"),
                    new Jumper("Shóhei", "Tochimoto", "Japonia"),
                    new Jumper("Mackenzie", "Boyd-Clowes", "Kanada"),
                    new Jumper("Matthew", "Soukup", "Kanada"),
                    new Jumper("Sabirżan", "Muminow", "Kazachstan"),
                    new Jumper("Siergiej", "Tkaczenko", "Kazachstan"),
                    new Jumper("Choi", "Heung-chul", "Korea Płd"),
                    new Jumper("Choi", "Seou", "Korea Płd"),
                    new Jumper("Moritz", "Baer", "Niemcy"),
                    new Jumper("Markus", "Eisenbichler", "Niemcy"),
                    new Jumper("Richard", "Freitag", "Niemcy"),
                    new Jumper("Karl", "Geiger", "Niemcy"),
                    new Jumper("Martin", "Hamann", "Niemcy"),
                    new Jumper("Felix", "Hoffmann", "Niemcy"),
                    new Jumper("Stephan", "Leyhe", "Niemcy"),
                    new Jumper("Kilian", "Marki", "Niemcy"),
                    new Jumper("Pius", "Paschke", "Niemcy"),
                    new Jumper("Philipp", "Raimund", "Niemcy"),
                    new Jumper("Luca", "Roth", "Niemcy"),
                    new Jumper("Adrian", "Sell", "Niemcy"),
                    new Jumper("Constantin", "Schmid", "Niemcy"),
                    new Jumper("Andreas", "Granerud", "Norwegia"),
                    new Jumper("Johann", "Andre", "Norwegia"),
                    new Jumper("Anders", "Hare", "Norwegia"),
                    new Jumper("Robert", "Johansson", "Norwegia"),
                    new Jumper("Marius", "Lindvik", "Norwegia"),
                    new Jumper("Thomas", "Aasen", "Norwegia"),
                    new Jumper("Robin", "Pedersen", "Norwegia"),
                    new Jumper("Sondre", "Ringen", "Norwegia"),
                    new Jumper("Daniel-Andre", "Tande", "Norwegia"),
                    new Jumper("Stefan", "Hula", "Polska"),
                    new Jumper("Kacper", "Juroszek", "Polska"),
                    new Jumper("Maciej", "Kot", "Polska"),
                    new Jumper("Dawid", "Kubacki", "Polska"),
                    new Jumper("Klemens", "Murańka", "Polska"),
                    new Jumper("Adam", "Niżnik", "Polska"),
                    new Jumper("Tomasz", "Pilch", "Polska"),
                    new Jumper("Andrzej", "Stękała", "Polska"),
                    new Jumper("Kamil", "Stoch", "Polska"),
                    new Jumper("Paweł", "Wąsek", "Polska"),
                    new Jumper("Jakub", "Wolny", "Polska"),
                    new Jumper("Aleksander", "Zniszczoł", "Polska"),
                    new Jumper("Piotr", "Żyła", "Polska"),
                    new Jumper("Aleksandr", "Bażenow", "Rosja"),
                    new Jumper("llmir", "Chazietdinow", "Rosja"),
                    new Jumper("Jewgienij", "Klimów", "Rosja"),
                    new Jumper("Dienis", "Korniłow", "Rosja"),
                    new Jumper("Michaił", "Maksimoczkin", "Rosja"),
                    new Jumper("Michaił", "Nazarów", "Rosja"),
                    new Jumper("Wadim", "Szyszkin", "Rosja"),
                    new Jumper("Roman", "Trofimow", "Rosja"),
                    new Jumper("Dmitrij", "Wasiljew", "Rosja"),
                    new Jumper("Tilen", "Bartol", "Słowenia"),
                    new Jumper("Rok", "Justin", "Słowenia"),
                    new Jumper("Anże", "Laniśek", "Słowenia"),
                    new Jumper("Cene", "Prevc", "Słowenia"),
                    new Jumper("Domen", "Prevc", "Słowenia"),
                    new Jumper("Peter", "Prevc", "Słowenia"),
                    new Jumper("Anźe", "Semenie", "Słowenia"),
                    new Jumper("Timi", "Zajc", "USA"),
                    new Jumper("Kevin", "Bickner", "USA"),
                    new Jumper("Decker", "Dean", "USA"),
                    new Jumper("Patrick", "Gąsienicą", "USA"),
                    new Jumper("Casey", "Larson", "USA"),
                    new Jumper("Andrew", "Urlaub", "USA"),
                    new Jumper("Simon", "Ammann", "Szwajcaria"),
                    new Jumper("Gregor", "Deschwanden", "Szwajcaria"),
                    new Jumper("Gabriel", "Karlen", "Szwajcaria"),
                    new Jumper("Killian", "Peier", "Szwajcaria"),
                    new Jumper("Dominik", "Peter", "Szwajcaria"),
                    new Jumper("Andreas", "Schuler", "Szwajcaria"),
                    new Jumper("Witalij", "Kaliniczenko", "Ukraina"),
                    new Jumper("Jewhen", "Marusiak", "Ukraina"),
                    new Jumper("Giovanni", "Bresadola", "Włochy"),
                    new Jumper("Federico", "Cecon", "Włochy"),
                    new Jumper("Alex", "Insam", "Włochy"),
                };

                var transaction = context.Database.BeginTransaction();

                jumpers.ForEach(jumper =>
                {
                    Logger.Info($"Dodaje skoczka: {jumper.ToString()}.");
                    context.Jumper.Add(jumper);
                    Logger.Info($"Pomyślnie dodano skoczka: {jumper.ToString()}.");
                });

                context.CommitTransaction(transaction);
            }

            catch (Exception ex)
            {
                Logger.Error(ex, $"Został zgłoszony wyjątek { ex.GetType().Name}.");
                throw new DataInitializerFailedException("Zainicjowanie domyślnych danych nie powiodło się");
            }
        }
    }
}




