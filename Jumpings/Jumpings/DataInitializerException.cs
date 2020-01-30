using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpings
{
    public class DataInitializerFailedException : Exception
    {
        public DataInitializerFailedException(string message)
            : base(message) { }
    }
}
