using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpings.Services
{
    public interface IRandomDataService
    {
        bool RandomFall();
        int RandomLength();
        int RandomNote();
        int SumResult();

    }
}
