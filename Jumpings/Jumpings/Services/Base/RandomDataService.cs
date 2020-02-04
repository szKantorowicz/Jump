using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpings.Services.Base
{
    public class RandomDataService : IRandomDataService
    {
        public bool boolFall;
        public int length;
        public int note;
        public int sum;

        public bool RandomFall()
        {
            int min = 0;
            int max = 2;
            Random nrand = new Random();
            int fall = nrand.Next(min, max);
            if (fall == 0)
            {
                return boolFall = false;
            }
            else
            {
                return boolFall = true;
            }

        }

        public int RandomLength()
        {
            int min = 100;
            int max = 140;
            Random nrand = new Random();
            return length = nrand.Next(min, max);

        }

        public int RandomNote()
        {
            int min = 0;
            int max = 0;
            if (boolFall == true)
            {
                min = 1;
                max = 12;
            }
            else
            {
                min = 13;
                max = 20;
            }
            Random nrand = new Random();
            return note = nrand.Next(min, max);
        }

        public int SumResult()
        {
            return sum = note + length;
        }
    }
}
