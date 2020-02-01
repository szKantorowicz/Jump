using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpings.Services
{
    public interface IRandomDataService
    {
        void RandomFall();
        void RandomLength();
        void RandomNote();
        int SumResult();

    }
}
