using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpings
{
    public class Jumper
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Country { get; private set; }

        public Jumper() { }

        public Jumper(string firstName, string lastName, string country)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetCountry(country);
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
                throw new ArgumentException("Nazwa kraju nie może być pusta.");
            }

            if (country.Length > 100)
            {
                throw new ArgumentException("Nazwa kraju nie może być dłuższa niż 100 znaków.");
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
