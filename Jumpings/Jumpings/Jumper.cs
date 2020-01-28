using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpings
{
    public class Jumper
    {
        public int ID { get; set; }
        // zmiana na private seta, ponieważ nie chcemy przypisywać wartości wprost
        public string FirstName { get; set; }
        // zmiana na private seta, ponieważ nie chcemy przypisywać wartości wprost
        public string LastName { get; set; }
        // zmiana na private seta, ponieważ nie chcemy przypisywać wartości wprost
        public string Country { get; set; }

        public Jumper() { }

        public Jumper(string firstName, string lastName, string country)
        {
            SetFirstName(firstName);
            // Użycie metody zamiast przypisania
            LastName = lastName;
            // Użycie metody zamiast przypisania
            Country = country;
        }

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("Imie nie może być puste.");
            }

            if (firstName.Length > 100)
            {
                throw new ArgumentException("Imie nie może być dłuższe niż 100 znaków.");
            }

            if (FirstName == firstName)
            {
                return;
            }

            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("Nazwisko nie może być puste.");
            }

            if (lastName.Length > 100)
            {
                throw new ArgumentException("Nazwisko nie może być dłuższe niż 100 znaków.");
            }

            if (LastName == lastName)
            {
                return;
            }

            LastName = lastName;
        }

        public void SetCountry(string country)
        {
            if (string.IsNullOrEmpty(country))
            {
                // zmień na country
                throw new ArgumentException("Nazwisko nie może być puste.");
            }

            if (country.Length > 100)
            {
                // zmień na country
                throw new ArgumentException("Nazwisko nie może być dłuższe niż 100 znaków.");
            }

            if (Country == country)
            {
                return;
            }

            Country = country;
        }

        public override string ToString()
        {
            return $"{FirstName}, {LastName}, {Country}";
        }
    }
}
