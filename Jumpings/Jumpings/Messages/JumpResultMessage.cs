using Jumpings.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpings.Messages
{
    public class JumpResultMessage
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Country { get; private set; }
        public JumperResult Result { get; set; }

        public JumpResultMessage(string firstName, string lastName, string country, JumperResult result) 
        {
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Result = result;
        }
    }
}
